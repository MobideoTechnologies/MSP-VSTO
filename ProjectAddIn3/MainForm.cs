
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
            importBtn.Enabled = false;
            exportBtn.Enabled = false;
            progressBar.Visible = true;
            MspVSTOManager.Export(subProjectsList, progressBar).GetAwaiter().GetResult();
            MspVSTOManager.UploadLogFile().GetAwaiter().GetResult();
            ResetFormControls();
        }


        private void importBtn_Click(object sender, EventArgs e)
        {
            importBtn.Enabled = false;
            exportBtn.Enabled = false;
            progressBar.Visible = true;
            MspVSTOManager.Import(subProjectsList, progressBar).GetAwaiter().GetResult();
            MspVSTOManager.UploadLogFile().GetAwaiter().GetResult();
            ResetFormControls();
        }

        private void ResetFormControls()
        {
            importBtn.Enabled = true;
            exportBtn.Enabled = true;
            progressBar.Visible = false;
            progressBar.Value = 0;
        }

        private void subProjectsList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (subProjectsList.CheckedItems.Count > 1)
            {
                importBtn.Enabled = true;
                exportBtn.Enabled = true;
                return;

            }

            //Last Item is uncheked
            if (subProjectsList.CheckedItems.Count == 1 && e.NewValue == CheckState.Unchecked)
            {
                importBtn.Enabled = false;
                exportBtn.Enabled = false;
                return;
            }

            //First Item is checked
            if (subProjectsList.CheckedItems.Count == 0 && e.NewValue == CheckState.Checked)
            {
                importBtn.Enabled = true;
                exportBtn.Enabled = true;
                return;
            }
        }
    }
}
