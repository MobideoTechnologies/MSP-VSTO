using Microsoft.Office.Interop.MSProject;
using Mobideo.Integration.ProjectVSTOAddIn;
using ProjectAddIn3.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exception = System.Exception;
using Task = System.Threading.Tasks.Task;

namespace ProjectAddIn3.Classes
{
    public class MspVSTOManager : IMspVSTOManager
    {
        public ILoginManager LoginManager { get; set; }
        public IMobideoImporter MobideoImporter { get; set; }
        public IMobideoExporter  MobideoExporter { get; set; }

        public IEnumerable<SubProjectWrapper> SubProjects { get; set; }

        public MspVSTOManager(ILoginManager loginManager, IMobideoImporter mobideoImporter, IMobideoExporter mobideoExporter)
        {
            LoginManager = loginManager;
            MobideoImporter= mobideoImporter;
            MobideoExporter= mobideoExporter;

        }


        public Task GetAllSubProjects(object subProjectsListBox)
        {
            var subProjectsList = subProjectsListBox as CheckedListBox;
            SubProjects = new List<SubProjectWrapper>();
            foreach (var subProject in Globals.ThisAddIn.Application.ActiveProject.Subprojects)
            {
                var currrentSubProject = subProject as Subproject;
                var newSubProjectWrapper = new SubProjectWrapper(currrentSubProject);
                subProjectsList.Items.Add(newSubProjectWrapper);
            }

            return Task.CompletedTask;
        }

        public async Task Export(object subProjectsListBox, object exportProgressBar)
        {
            try
            {
              var selectedSubProjects = GetSelectedSubProjects(subProjectsListBox);
              await MobideoExporter.ExportDataFromMobideoToMsp(selectedSubProjects, exportProgressBar);
              MessageBox.Show(ConfigurationManager.AppSettings["ExportCompletedText"]);
            }
            catch (System.Exception exception)
            {
                var errorMessage = string.Format("An error occured during VSTO export for {0}\n: {1}", ConfigurationManager.AppSettings["MobideoEnvironmentUrl"], exception.Message);
                Logger.Error(exception, "An error occured during VSTO export");
                Logger.Email(errorMessage); 
            }
            

        }


        public async Task Import(object subProjectsListBox, object importProgressBar)
        {
            try
            {
                var selectedSubProjects = GetSelectedSubProjects(subProjectsListBox);
                await MobideoImporter.ImportFilesToMobideo(selectedSubProjects, importProgressBar);
                MessageBox.Show(ConfigurationManager.AppSettings["ImportCompletedText"]);
            }
            catch(System.Exception exception)
            {
                var errorMessage = string.Format("An error occured during VSTO import for {0}\n: {1}", ConfigurationManager.AppSettings["MobideoEnvironmentUrl"], exception.Message);
                Logger.Error(exception, "An error occured during VSTO import");
                Logger.Email(errorMessage);
            }
        }

        private  List<SubProjectWrapper> GetSelectedSubProjects(object subProjectsListBox)
        {
            var subProjectsList = subProjectsListBox as CheckedListBox;
            var selectedMppFiles = subProjectsList.CheckedItems.Cast<SubProjectWrapper>().ToList();
            return selectedMppFiles;
        }

        public async Task<bool> Login(string username, string password)
        {
           return await LoginManager.Login(username, password);
        }

        public async Task UploadLogFile()
        {
            try
            {
                Logger.Info("*** Uploading log file to customer files");
                var logFilePath = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).LocalPath + "\\logs\\MSP-VSTO-Info.txt";
                var customerFilesFileUploader = new CustomerFilesFileUploader();
                using (FileStream fileStream = new FileStream(logFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var memoryStream = new MemoryStream();
                    fileStream.CopyTo(memoryStream);
                    await customerFilesFileUploader.UploadFile(logFilePath, memoryStream, ConfigurationManager.AppSettings["LogsFolderInCustomerFiles"], true);
                }

                if (bool.Parse(ConfigurationManager.AppSettings["DeleteLocalLogFile"]))
                {
                    File.Delete(logFilePath);
                }

                Logger.Info("*** Done Uploading log file to customer files");
            }
            catch (Exception exception)
            {
                var errorMessage = string.Format("An error occured during VSTO log file upload for {0}\n: {1}", ConfigurationManager.AppSettings["MobideoEnvironmentUrl"], exception.Message);
                Logger.Error(exception, "An error occured during VSTO log file upload");
                Logger.Email(errorMessage);
            }
        }
    }
}
