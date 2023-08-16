
using ProjectAddIn3.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Aspose.Tasks.Connectivity;
using Project = Microsoft.Office.Interop.MSProject.Project;
using Task = Microsoft.Office.Interop.MSProject.Task;
using Microsoft.Office.Interop.MSProject;
using ProjectAddIn3.Interfaces;
using ProjectAddIn3.Classes;
using Mobideo.Core;
using System.Reflection;
using System.ServiceModel.Security;
using System.Drawing.Drawing2D;
using ProjectAddIn3.Controls;
using NLog.Filters;
using System.Windows;
using MessageBox = System.Windows.Forms.MessageBox;
using Application = System.Windows.Forms.Application;

namespace Mobideo.Integration.ProjectVSTOAddIn
{
    public partial class MainForm : Form
    {
        public IMspVSTOManager MspVSTOManager { get; set; }
        public int SuccessfulFiles { get; set; }
        public int FailedFiles { get; set; }

        public MainForm()
        {
            InitializeComponent();
            MspVSTOManager = ServiceProvider.GetService<IMspVSTOManager>();
            MspVSTOManager.GetAllSubProjects(subProjectsList);
 
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            OnExport();
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            OnImport();
        }

        private void validateBtn_Click(object sender, EventArgs e)
        {
            OnValidate();
        }
        private void OnExport()
        {
            if (exportBtn.Enabled)
            {
                DisableControls();
                exportService.RunWorkerAsync();
            }
        }

        private void OnImport()
        {
            if (importBtn.Enabled)
            {
                DisableControls();
                importService.RunWorkerAsync();
            }
        }

        private void DisableControls()
        {
            importBtn.Enabled = false;
            exportBtn.Enabled = false;
            validateBtn.Enabled = false;
            exportPicBox.Enabled = false;
            importPicBox.Enabled = false;
            var resourcesFolder = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).LocalPath + "\\Resources";
            exportPicBox.Image = Image.FromFile(resourcesFolder + "\\Export-btn-disabled.png");
            importPicBox.Image = Image.FromFile(resourcesFolder + "\\Import-btn-disabled.png");
            validatePicBox.Image = Image.FromFile(resourcesFolder + "\\validate-btn-disabled.png");
            importBtnTxt.BackColor = Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(177)))), ((int)(((byte)(255)))));
            exportBtnTxt.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            exportBtnTxt.ForeColor= Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(177)))), ((int)(((byte)(255)))));
            validateTextBox.ForeColor = Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(215)))));
            loadingImage.Visible = true;
            loadingTextBox.Visible = true;
        }

        private void OnValidate()
        {
            if (validateBtn.Enabled)
            {
                DisableControls();
                validationService.RunWorkerAsync();

            }
        }

        private void ResetFormControls()
        {
            exportBtn.Enabled = true;
            importBtn.Enabled = true;
            validateBtn.Enabled = true;
            exportPicBox.Enabled = true;
            importPicBox.Enabled = true;
            var resourcesFolder = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).LocalPath + "\\Resources";
            exportPicBox.Image = Image.FromFile(resourcesFolder + "\\btn-export.png");
            importPicBox.Image = Image.FromFile(resourcesFolder + "\\btn-import.png");
            validatePicBox.Image = Image.FromFile(resourcesFolder + "\\validate-btn.png");
            importBtnTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(111)))), ((int)(((byte)(239)))));
            exportBtnTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            exportBtnTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(111)))), ((int)(((byte)(239)))));
            validateTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(131)))), ((int)(((byte)(134)))));
            loadingImage.Visible = false;
            loadingTextBox.Visible = false;
        }

        private void subProjectsList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            subProjectsList.ClearSelected();
            if (subProjectsList.CheckedItems.Count > 1)
            {
                exportBtn.Enabled = true;
                importBtn.Enabled = true;
                validateBtn.Enabled= true;
                return;

            }

            //Last Item is uncheked
            if (subProjectsList.CheckedItems.Count == 1 && e.NewValue == CheckState.Unchecked)
            {
                exportBtn.Enabled = false;
                importBtn.Enabled = false;
                validateBtn.Enabled = false;
                return;
            }

            //First Item is checked
            if (subProjectsList.CheckedItems.Count == 0 && e.NewValue == CheckState.Checked)
            {
                exportBtn.Enabled = true;
                importBtn.Enabled = true;
                validateBtn.Enabled = true;
                return;
            }
        }

        private void unselectBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < subProjectsList.Items.Count; i++)
            {
                subProjectsList.SetItemChecked(i, false);
            }
        }

        private void selectAllBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < subProjectsList.Items.Count; i++)
            {
                subProjectsList.SetItemChecked(i, true);
            }
        }

        private void RunImport(object sender, DoWorkEventArgs e)
        {
            var uploadedFiles = MspVSTOManager.Import(subProjectsList).GetAwaiter().GetResult();
            SuccessfulFiles = uploadedFiles.Item1;
            FailedFiles = uploadedFiles.Item2;
        }

        private void RunValidation(object sender, DoWorkEventArgs e)
        {
            var uploadedFiles = MspVSTOManager.Import(subProjectsList,true).GetAwaiter().GetResult();
            SuccessfulFiles = uploadedFiles.Item1;
            FailedFiles = uploadedFiles.Item2;
        }

        private void RunExport(object sender, DoWorkEventArgs e)
        {
            MspVSTOManager.Export(subProjectsList).GetAwaiter().GetResult();
        }


        private void DoWhenImportCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ResetFormControls();
            MessageBox.Show(string.Format(ConfigurationManager.AppSettings["ImportCompletedText"], SuccessfulFiles, FailedFiles));
            MspVSTOManager.UploadLogFile().GetAwaiter().GetResult();
        }

        private void DoWhenExportCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ResetFormControls();
            MessageBox.Show(ConfigurationManager.AppSettings["ExportCompletedText"]);
            MspVSTOManager.UploadLogFile().GetAwaiter().GetResult();
        }
    }
}
