﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Office.Interop.MSProject;
using Mobideo.Core;
using Mobideo.Core.Extensions;
using Mobideo.Integration.ProjectVSTOAddIn;
using Newtonsoft.Json;
using ProjectAddIn3.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exception = System.Exception;
using Task = System.Threading.Tasks.Task;
using View = Microsoft.Office.Interop.MSProject.View;

namespace ProjectAddIn3.Classes
{
    public class MobideoImporter : IMobideoImporter
    {
        public async Task ImportFilesToMobideo(IEnumerable<SubProjectWrapper> selectedSubProjects, object importProgressBar)
        {
            Logger.Info("*** Start import files to mobideo");
            var subProjectsFiles = CreateSubProjectFiles(selectedSubProjects, out var filesToDelete);
            var importProgress = importProgressBar as ProgressBar;
            importProgress.Visible = true;
            importProgress.Maximum = 120;
            bool hasErrorOccured = false;
            var errorMessage = new StringBuilder();
            importProgress.Value = 20;
            int fileRelativePercentage = (1 / subProjectsFiles.Count) * 100;
            foreach(var subProjectFile in subProjectsFiles)
            {
                try
                {
                    Logger.Info("*** Uploading file {0} to customer files", subProjectFile.Item1);
                    await UploadFileToMobideo(subProjectFile.Item1, subProjectFile.Item2);
                    subProjectFile.Item2.Close();
                    subProjectFile.Item2.Dispose();
                    Logger.Info("*** Done Uploading file {0} to customer files", subProjectFile.Item1);
                }
                catch(Exception exception)
                {
                    var fileErrorMessage = string.Format("An error occured while uploading file {0} to customer files", subProjectFile.Item1);
                    Logger.Error(exception, fileErrorMessage, subProjectFile.Item1);
                    hasErrorOccured = true;
                    errorMessage.AppendLine(fileErrorMessage);
                }
                finally
                {
                    importProgress.Value += fileRelativePercentage;
                    Thread.Sleep(2000);
                }

            }

            //filesToDelete.ForEach(file => File.Delete(file));
            importProgress.Visible= false;

            if (hasErrorOccured)
            {
                Logger.Email(errorMessage.ToString());
            }

            Logger.Info("*** Done import all files to mobideo");

        }

        private async Task UploadFileToMobideo(string filePath, Stream stream)
        {
            IFileUploader mobideoFileUploader = FileUploaderFactory.CreateFileUploader();
            await mobideoFileUploader.UploadFile(filePath, stream, ConfigurationManager.AppSettings["CustomerFilesUploadFolderName"]);
        }

        private List<Tuple<string,Stream>> CreateSubProjectFiles(IEnumerable<SubProjectWrapper> selectedSubProjects, out List<string> filesToDelete)
        {
            var subProjectFiles = new List<Tuple<string,Stream>>();
            filesToDelete = new List<string>();
           
            var tempFolderPath = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).LocalPath + "\\TempFiles";
            if (!Directory.Exists(tempFolderPath))
            {
                Directory.CreateDirectory(tempFolderPath);
            }

            var application = Globals.ThisAddIn.Application;
            application.AppMinimize();
            foreach (var subProject in selectedSubProjects)
            {
                var currentSubProject = subProject.SubProjectLegacyObject;
                var currentSubProjectPath = currentSubProject.Path;
                using (FileStream fileStream = new FileStream(currentSubProjectPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    
                    var newFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + "." + "temp");
                    fileStream.ToFile(newFilePath);
                    application.FileOpenEx(newFilePath);
                    application.FilterClear();
                    application.FileSaveAs(newFilePath);
                    using (FileStream newFileStream = new FileStream(newFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        var memoryStream = new MemoryStream();
                        newFileStream.CopyTo(memoryStream);
                        subProjectFiles.Add(new Tuple<string, Stream>(currentSubProjectPath, memoryStream));

                    }

                }

                application.ActiveWindow.Close();
            }

            return subProjectFiles;
        }
    }
}
