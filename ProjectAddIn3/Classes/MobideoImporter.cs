using Microsoft.Extensions.DependencyInjection;
using Microsoft.Office.Interop.MSProject;
using Mobideo.Core.Extensions;
using Mobideo.Integration.ProjectVSTOAddIn;
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
            var subProjectsFiles = CreateSubProjectFiles(selectedSubProjects);
            var importProgress = importProgressBar as ProgressBar;
            importProgress.Style = ProgressBarStyle.Continuous;
            importProgress.Visible = true;
            importProgress.Maximum = subProjectsFiles.Count;
            bool hasErrorOccured = false;
            var errorMessage = new StringBuilder();
            foreach(var subProjectFile in subProjectsFiles)
            {
                try
                {
                    Logger.Info("*** Uploading file {0} to customer files", subProjectFile.Item1);
                    await UploadFileToMobideo(subProjectFile.Item1, subProjectFile.Item2);
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
                    importProgress.Increment(1);
                }

            }

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

        private List<Tuple<string,Stream>> CreateSubProjectFiles(IEnumerable<SubProjectWrapper> selectedSubProjects)
        {
            var subProjectFiles = new List<Tuple<string,Stream>>();
            var tempFolderPath = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).LocalPath + "\\TempFiles";
            foreach (var subProject in selectedSubProjects)
            {
                var currentSubProject = subProject.SubProjectLegacyObject;
                var currentSubProjectPath = currentSubProject.Path;
                var views = currentSubProject.SourceProject.Views;
                foreach (var view in views)
                {
                    var castedView = view as View;
                    if(!castedView.Name.CaseInsensitiveEquals("Gantt chart"))
                    {
                        castedView.Delete();
                    }
                }

                //currentSubProject.Application.FilterClear();
                //var taskFilters = currentSubProject.SourceProject.TaskFilters;
                if (currentSubProject.SourceProject.AutoFilter)
                {
                    currentSubProject.SourceProject.AutoFilter = false;
                }

                //foreach (var filter in taskFilters)
                //{
                //    var currentFitler = filter as Filter;
                //    if (!currentFitler.Name.CaseInsensitiveEquals("All Tasks") && !currentFitler.Name.CaseInsensitiveEquals("כל הפעילויות"))
                //    {
                //        currentFitler.Delete();
                //    }

                //}


                var newUnfilteredFilePath  = string.Format("{0}\\{1}.{2}",tempFolderPath, Guid.NewGuid().ToString(), "mpp");
                currentSubProject.SourceProject.SaveAs(newUnfilteredFilePath, PjFileFormat.pjMPP, Type.Missing, Type.Missing, Type.Missing, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                using (FileStream fileStream = new FileStream(newUnfilteredFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    
                    var memoryStream = new MemoryStream();
                    fileStream.CopyTo(memoryStream);
                    subProjectFiles.Add(new Tuple<string, Stream>(currentSubProjectPath, memoryStream));
                }
            }

            return subProjectFiles;
        }
    }
}
