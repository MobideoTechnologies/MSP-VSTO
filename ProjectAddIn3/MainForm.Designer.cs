using Microsoft.VisualStudio.Utilities.Dpi;
using ProjectAddIn3.Controls;
using System.Configuration;
using System.Design;

namespace Mobideo.Integration.ProjectVSTOAddIn
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.subProjectsList = new System.Windows.Forms.CheckedListBox();
            this.exportBtnTxt = new System.Windows.Forms.TextBox();
            this.importBtnTxt = new System.Windows.Forms.TextBox();
            this.validateTextBox = new System.Windows.Forms.TextBox();
            this.selectAllBtn = new System.Windows.Forms.Button();
            this.unselectBtn = new System.Windows.Forms.Button();
            this.loadingTextBox = new System.Windows.Forms.TextBox();
            this.importService = new System.ComponentModel.BackgroundWorker();
            this.validationService = new System.ComponentModel.BackgroundWorker();
            this.exportService = new System.ComponentModel.BackgroundWorker();
            this.importPicBox = new System.Windows.Forms.PictureBox();
            this.exportPicBox = new System.Windows.Forms.PictureBox();
            this.validatePicBox = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.subProjectsControl1 = new ProjectAddIn3.Controls.SubProjectsControl();
            this.validateBtn = new ProjectAddIn3.Controls.SubProjectsControl();
            ((System.ComponentModel.ISupportInitialize)(this.importPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exportPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.validatePicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TT Commons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(178, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Please select files:";
            // 
            // subProjectsList
            // 
            this.subProjectsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.subProjectsList.CheckOnClick = true;
            this.subProjectsList.DisplayMember = "FileName";
            this.subProjectsList.Font = new System.Drawing.Font("TT Commons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subProjectsList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(131)))), ((int)(((byte)(134)))));
            this.subProjectsList.FormattingEnabled = true;
            this.subProjectsList.Location = new System.Drawing.Point(204, 209);
            this.subProjectsList.Margin = new System.Windows.Forms.Padding(8, 8, 8, 15);
            this.subProjectsList.Name = "subProjectsList";
            this.subProjectsList.Size = new System.Drawing.Size(1256, 320);
            this.subProjectsList.TabIndex = 9;
            this.subProjectsList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.subProjectsList_ItemCheck);
            // 
            // exportBtnTxt
            // 
            this.exportBtnTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.exportBtnTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exportBtnTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exportBtnTxt.Font = new System.Drawing.Font("TT Commons", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportBtnTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(111)))), ((int)(((byte)(239)))));
            this.exportBtnTxt.Location = new System.Drawing.Point(892, 637);
            this.exportBtnTxt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.exportBtnTxt.Name = "exportBtnTxt";
            this.exportBtnTxt.Size = new System.Drawing.Size(206, 23);
            this.exportBtnTxt.TabIndex = 11;
            this.exportBtnTxt.TabStop = false;
            this.exportBtnTxt.Text = "Export data to project";
            this.exportBtnTxt.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // importBtnTxt
            // 
            this.importBtnTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(111)))), ((int)(((byte)(239)))));
            this.importBtnTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.importBtnTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.importBtnTxt.Font = new System.Drawing.Font("TT Commons", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBtnTxt.ForeColor = System.Drawing.SystemColors.Window;
            this.importBtnTxt.Location = new System.Drawing.Point(1246, 637);
            this.importBtnTxt.Margin = new System.Windows.Forms.Padding(0);
            this.importBtnTxt.Name = "importBtnTxt";
            this.importBtnTxt.Size = new System.Drawing.Size(214, 23);
            this.importBtnTxt.TabIndex = 13;
            this.importBtnTxt.TabStop = false;
            this.importBtnTxt.Text = "Import data to Mobideo";
            this.importBtnTxt.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // validateTextBox
            // 
            this.validateTextBox.BackColor = System.Drawing.Color.White;
            this.validateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.validateTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.validateTextBox.Font = new System.Drawing.Font("TT Commons", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.validateTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(131)))), ((int)(((byte)(134)))));
            this.validateTextBox.Location = new System.Drawing.Point(250, 637);
            this.validateTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.validateTextBox.Name = "validateTextBox";
            this.validateTextBox.Size = new System.Drawing.Size(129, 23);
            this.validateTextBox.TabIndex = 17;
            this.validateTextBox.TabStop = false;
            this.validateTextBox.Text = "Validate Files";
            this.validateTextBox.Click += new System.EventHandler(this.validateBtn_Click);
            // 
            // selectAllBtn
            // 
            this.selectAllBtn.BackColor = System.Drawing.Color.Transparent;
            this.selectAllBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectAllBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.selectAllBtn.FlatAppearance.BorderSize = 0;
            this.selectAllBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.selectAllBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectAllBtn.Font = new System.Drawing.Font("TT Commons", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectAllBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(111)))), ((int)(((byte)(239)))));
            this.selectAllBtn.Location = new System.Drawing.Point(1264, 148);
            this.selectAllBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.selectAllBtn.Name = "selectAllBtn";
            this.selectAllBtn.Size = new System.Drawing.Size(195, 43);
            this.selectAllBtn.TabIndex = 18;
            this.selectAllBtn.Text = " ＋ Select All";
            this.selectAllBtn.UseVisualStyleBackColor = false;
            this.selectAllBtn.Click += new System.EventHandler(this.selectAllBtn_Click);
            // 
            // unselectBtn
            // 
            this.unselectBtn.BackColor = System.Drawing.Color.Transparent;
            this.unselectBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.unselectBtn.FlatAppearance.BorderSize = 0;
            this.unselectBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.unselectBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.unselectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unselectBtn.Font = new System.Drawing.Font("TT Commons", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unselectBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(111)))), ((int)(((byte)(239)))));
            this.unselectBtn.Location = new System.Drawing.Point(1042, 148);
            this.unselectBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.unselectBtn.Name = "unselectBtn";
            this.unselectBtn.Size = new System.Drawing.Size(213, 43);
            this.unselectBtn.TabIndex = 19;
            this.unselectBtn.Text = "−  Unselect All";
            this.unselectBtn.UseVisualStyleBackColor = false;
            this.unselectBtn.Click += new System.EventHandler(this.unselectBtn_Click);
            // 
            // loadingTextBox
            // 
            this.loadingTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loadingTextBox.Font = new System.Drawing.Font("TT Commons", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingTextBox.ForeColor = System.Drawing.Color.Black;
            this.loadingTextBox.Location = new System.Drawing.Point(702, 943);
            this.loadingTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loadingTextBox.Name = "loadingTextBox";
            this.loadingTextBox.Size = new System.Drawing.Size(348, 23);
            this.loadingTextBox.TabIndex = 21;
            this.loadingTextBox.Text = "Please wait while files are in process... ";
            this.loadingTextBox.Visible = false;
            // 
            // importService
            // 
            this.importService.WorkerReportsProgress = true;
            this.importService.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RunImport);
            this.importService.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.UpdateProgressBar);
            this.importService.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DoWhenImportCompleted);
            // 
            // validationService
            // 
            this.validationService.WorkerReportsProgress = true;
            this.validationService.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RunValidation);
            this.validationService.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.UpdateProgressBar);
            this.validationService.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DoWhenImportCompleted);
            // 
            // exportService
            // 
            this.exportService.WorkerReportsProgress = true;
            this.exportService.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RunExport);
            this.exportService.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.UpdateProgressBar);
            this.exportService.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DoWhenExportCompleted);
            // 
            // importPicBox
            // 
            this.importPicBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.importPicBox.Image = ((System.Drawing.Image)(resources.GetObject("importPicBox.Image")));
            this.importPicBox.Location = new System.Drawing.Point(1172, 620);
            this.importPicBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.importPicBox.Name = "importPicBox";
            this.importPicBox.Size = new System.Drawing.Size(308, 55);
            this.importPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.importPicBox.TabIndex = 22;
            this.importPicBox.TabStop = false;
            this.importPicBox.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // exportPicBox
            // 
            this.exportPicBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exportPicBox.Image = ((System.Drawing.Image)(resources.GetObject("exportPicBox.Image")));
            this.exportPicBox.Location = new System.Drawing.Point(816, 618);
            this.exportPicBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.exportPicBox.Name = "exportPicBox";
            this.exportPicBox.Size = new System.Drawing.Size(308, 57);
            this.exportPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exportPicBox.TabIndex = 23;
            this.exportPicBox.TabStop = false;
            this.exportPicBox.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // validatePicBox
            // 
            this.validatePicBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.validatePicBox.Image = ((System.Drawing.Image)(resources.GetObject("validatePicBox.Image")));
            this.validatePicBox.Location = new System.Drawing.Point(171, 618);
            this.validatePicBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.validatePicBox.Name = "validatePicBox";
            this.validatePicBox.Size = new System.Drawing.Size(230, 57);
            this.validatePicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.validatePicBox.TabIndex = 24;
            this.validatePicBox.TabStop = false;
            this.validatePicBox.Click += new System.EventHandler(this.validateBtn_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(645, 878);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(405, 40);
            this.progressBar.TabIndex = 25;
            this.progressBar.Visible = false;
            // 
            // subProjectsControl1
            // 
            this.subProjectsControl1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.subProjectsControl1.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.subProjectsControl1.BorderWidth = 5F;
            this.subProjectsControl1.Location = new System.Drawing.Point(158, 112);
            this.subProjectsControl1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.subProjectsControl1.Name = "subProjectsControl1";
            this.subProjectsControl1.Radius = 10;
            this.subProjectsControl1.Size = new System.Drawing.Size(1329, 478);
            this.subProjectsControl1.TabIndex = 8;
            // 
            // validateBtn
            // 
            this.validateBtn.BackgroundColor = System.Drawing.Color.White;
            this.validateBtn.BorderColor = System.Drawing.Color.White;
            this.validateBtn.BorderWidth = 1F;
            this.validateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.validateBtn.Location = new System.Drawing.Point(138, 517);
            this.validateBtn.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.validateBtn.Name = "validateBtn";
            this.validateBtn.Radius = 10;
            this.validateBtn.Size = new System.Drawing.Size(262, 74);
            this.validateBtn.TabIndex = 16;
            this.validateBtn.Click += new System.EventHandler(this.validateBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1650, 1094);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.importBtnTxt);
            this.Controls.Add(this.validateTextBox);
            this.Controls.Add(this.exportBtnTxt);
            this.Controls.Add(this.loadingTextBox);
            this.Controls.Add(this.unselectBtn);
            this.Controls.Add(this.selectAllBtn);
            this.Controls.Add(this.subProjectsList);
            this.Controls.Add(this.subProjectsControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.importPicBox);
            this.Controls.Add(this.exportPicBox);
            this.Controls.Add(this.validatePicBox);
            this.Controls.Add(this.validateBtn);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.MaximumSize = new System.Drawing.Size(1672, 1150);
            this.MinimumSize = new System.Drawing.Size(1294, 890);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mobideo Bazan MSP Integration";
            ((System.ComponentModel.ISupportInitialize)(this.importPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exportPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.validatePicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private SubProjectsControl subProjectsControl1;
        private System.Windows.Forms.CheckedListBox subProjectsList;
        private System.Windows.Forms.TextBox exportBtnTxt;
        private System.Windows.Forms.TextBox importBtnTxt;
        private SubProjectsControl validateBtn;
        private System.Windows.Forms.TextBox validateTextBox;
        private System.Windows.Forms.Button selectAllBtn;
        private System.Windows.Forms.Button unselectBtn;
        private System.Windows.Forms.TextBox loadingTextBox;
        private System.ComponentModel.BackgroundWorker importService;
        private System.ComponentModel.BackgroundWorker validationService;
        private System.ComponentModel.BackgroundWorker exportService;
        private System.Windows.Forms.PictureBox importPicBox;
        private System.Windows.Forms.PictureBox exportPicBox;
        private System.Windows.Forms.PictureBox validatePicBox;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}