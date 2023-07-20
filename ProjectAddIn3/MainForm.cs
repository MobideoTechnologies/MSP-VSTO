
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

namespace Mobideo.Integration.ProjectVSTOAddIn
{
    public partial class MainForm : Form
    {
        public IMspVSTOManager MspVSTOManager { get; set; }

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

        private void OnExport()
        {
            if (exportBtn.Enabled)
            {
                exportBtn.Enabled = false;
                importBtn.Enabled = false;
                progressBar.Visible = true;
                MspVSTOManager.Export(subProjectsList, progressBar).GetAwaiter().GetResult();
                MspVSTOManager.UploadLogFile().GetAwaiter().GetResult();
                ResetFormControls();
            }
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            OnImport();
        }

        private void OnImport()
        {
            if (importBtn.Enabled)
            {
                importBtn.Enabled = false;
                exportBtn.Enabled = false;
                importBtn.BackgroundColor = Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(151)))), ((int)(((byte)(204)))));
                importBtnTxt.BackColor = Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(151)))), ((int)(((byte)(204)))));
                progressBar.Visible = true;
                MspVSTOManager.Import(subProjectsList, progressBar).GetAwaiter().GetResult();
                MspVSTOManager.UploadLogFile().GetAwaiter().GetResult();
                ResetFormControls();
            }
        }

        private void ResetFormControls()
        {
            exportBtn.Enabled = true;
            importBtn.Enabled = true;
            importBtn.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(111)))), ((int)(((byte)(239)))));
            importBtnTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(111)))), ((int)(((byte)(239)))));
            progressBar.Visible = false;
            progressBar.Value = 0;
        }

        private void subProjectsList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (subProjectsList.CheckedItems.Count > 1)
            {
                exportBtn.Enabled = true;
                exportBtn.Enabled = true;
                return;

            }

            //Last Item is uncheked
            if (subProjectsList.CheckedItems.Count == 1 && e.NewValue == CheckState.Unchecked)
            {
                exportBtn.Enabled = false;
                exportBtn.Enabled = false;
                return;
            }

            //First Item is checked
            if (subProjectsList.CheckedItems.Count == 0 && e.NewValue == CheckState.Checked)
            {
                exportBtn.Enabled = true;
                exportBtn.Enabled = true;
                return;
            }
        }

        private void importBtn_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }

        private void customButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
