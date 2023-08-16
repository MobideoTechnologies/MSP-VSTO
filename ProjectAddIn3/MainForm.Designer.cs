using ProjectAddIn3.Controls;
using System.Configuration;
using System.Windows.Forms.VisualStyles;

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
            this.loadingImage = new System.Windows.Forms.PictureBox();
            this.loadingTextBox = new System.Windows.Forms.TextBox();
            this.importService = new System.ComponentModel.BackgroundWorker();
            this.validationService = new System.ComponentModel.BackgroundWorker();
            this.exportService = new System.ComponentModel.BackgroundWorker();
            this.importPicBox = new System.Windows.Forms.PictureBox();
            this.exportPicBox = new System.Windows.Forms.PictureBox();
            this.validatePicBox = new System.Windows.Forms.PictureBox();
            this.subProjectsControl1 = new ProjectAddIn3.Controls.SubProjectsControl();
            this.importBtn = new ProjectAddIn3.Controls.SubProjectsControl();
            this.exportBtn = new ProjectAddIn3.Controls.SubProjectsControl();
            this.validateBtn = new ProjectAddIn3.Controls.SubProjectsControl();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exportPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.validatePicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TT Commons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(102, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Please select files:";
            // 
            // subProjectsList
            // 
            this.subProjectsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.subProjectsList.CheckOnClick = true;
            this.subProjectsList.DisplayMember = "FileName";
            this.subProjectsList.Font = new System.Drawing.Font("TT Commons", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subProjectsList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(131)))), ((int)(((byte)(134)))));
            this.subProjectsList.FormattingEnabled = true;
            this.subProjectsList.Location = new System.Drawing.Point(128, 137);
            this.subProjectsList.Margin = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.subProjectsList.Name = "subProjectsList";
            this.subProjectsList.Size = new System.Drawing.Size(567, 168);
            this.subProjectsList.TabIndex = 9;
            this.subProjectsList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.subProjectsList_ItemCheck);
            // 
            // exportBtnTxt
            // 
            this.exportBtnTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.exportBtnTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exportBtnTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exportBtnTxt.Font = new System.Drawing.Font("TT Commons", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportBtnTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(111)))), ((int)(((byte)(239)))));
            this.exportBtnTxt.Location = new System.Drawing.Point(351, 348);
            this.exportBtnTxt.Name = "exportBtnTxt";
            this.exportBtnTxt.Size = new System.Drawing.Size(137, 18);
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
            this.importBtnTxt.Font = new System.Drawing.Font("TT Commons", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBtnTxt.ForeColor = System.Drawing.SystemColors.Window;
            this.importBtnTxt.Location = new System.Drawing.Point(568, 348);
            this.importBtnTxt.Margin = new System.Windows.Forms.Padding(0);
            this.importBtnTxt.Name = "importBtnTxt";
            this.importBtnTxt.Size = new System.Drawing.Size(143, 18);
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
            this.validateTextBox.Font = new System.Drawing.Font("TT Commons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.validateTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(131)))), ((int)(((byte)(134)))));
            this.validateTextBox.Location = new System.Drawing.Point(147, 348);
            this.validateTextBox.Name = "validateTextBox";
            this.validateTextBox.Size = new System.Drawing.Size(86, 19);
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
            this.selectAllBtn.Font = new System.Drawing.Font("TT Commons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectAllBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(111)))), ((int)(((byte)(239)))));
            this.selectAllBtn.Location = new System.Drawing.Point(611, 97);
            this.selectAllBtn.Name = "selectAllBtn";
            this.selectAllBtn.Size = new System.Drawing.Size(101, 28);
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
            this.unselectBtn.Font = new System.Drawing.Font("TT Commons", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unselectBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(111)))), ((int)(((byte)(239)))));
            this.unselectBtn.Location = new System.Drawing.Point(465, 96);
            this.unselectBtn.Name = "unselectBtn";
            this.unselectBtn.Size = new System.Drawing.Size(115, 28);
            this.unselectBtn.TabIndex = 19;
            this.unselectBtn.Text = "−  Unselect All";
            this.unselectBtn.UseVisualStyleBackColor = false;
            this.unselectBtn.Click += new System.EventHandler(this.unselectBtn_Click);
            // 
            // loadingImage
            // 
            this.loadingImage.Image = ((System.Drawing.Image)(resources.GetObject("loadingImage.Image")));
            this.loadingImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("loadingImage.InitialImage")));
            this.loadingImage.Location = new System.Drawing.Point(252, 454);
            this.loadingImage.Name = "loadingImage";
            this.loadingImage.Size = new System.Drawing.Size(317, 31);
            this.loadingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loadingImage.TabIndex = 20;
            this.loadingImage.TabStop = false;
            this.loadingImage.Visible = false;
            // 
            // loadingTextBox
            // 
            this.loadingTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loadingTextBox.Font = new System.Drawing.Font("TT Commons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingTextBox.ForeColor = System.Drawing.Color.Black;
            this.loadingTextBox.Location = new System.Drawing.Point(287, 491);
            this.loadingTextBox.Name = "loadingTextBox";
            this.loadingTextBox.Size = new System.Drawing.Size(254, 19);
            this.loadingTextBox.TabIndex = 21;
            this.loadingTextBox.Text = "Please wait while files are in process... ";
            this.loadingTextBox.Visible = false;
            // 
            // importService
            // 
            this.importService.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RunImport);
            this.importService.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DoWhenImportCompleted);
            // 
            // validationService
            // 
            this.validationService.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RunValidation);
            this.validationService.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DoWhenImportCompleted);
            // 
            // exportService
            // 
            this.exportService.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RunExport);
            this.exportService.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DoWhenExportCompleted);
            // 
            // importPicBox
            // 
            this.importPicBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.importPicBox.Image = ((System.Drawing.Image)(resources.GetObject("importPicBox.Image")));
            this.importPicBox.Location = new System.Drawing.Point(529, 338);
            this.importPicBox.Name = "importPicBox";
            this.importPicBox.Size = new System.Drawing.Size(193, 36);
            this.importPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.importPicBox.TabIndex = 22;
            this.importPicBox.TabStop = false;
            this.importPicBox.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // exportPicBox
            // 
            this.exportPicBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exportPicBox.Image = ((System.Drawing.Image)(resources.GetObject("exportPicBox.Image")));
            this.exportPicBox.Location = new System.Drawing.Point(312, 338);
            this.exportPicBox.Name = "exportPicBox";
            this.exportPicBox.Size = new System.Drawing.Size(187, 37);
            this.exportPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exportPicBox.TabIndex = 23;
            this.exportPicBox.TabStop = false;
            this.exportPicBox.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // validatePicBox
            // 
            this.validatePicBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.validatePicBox.Image = ((System.Drawing.Image)(resources.GetObject("validatePicBox.Image")));
            this.validatePicBox.Location = new System.Drawing.Point(101, 337);
            this.validatePicBox.Name = "validatePicBox";
            this.validatePicBox.Size = new System.Drawing.Size(141, 37);
            this.validatePicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.validatePicBox.TabIndex = 24;
            this.validatePicBox.TabStop = false;
            this.validatePicBox.Click += new System.EventHandler(this.validateBtn_Click);
            // 
            // subProjectsControl1
            // 
            this.subProjectsControl1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.subProjectsControl1.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.subProjectsControl1.BorderWidth = 5F;
            this.subProjectsControl1.Location = new System.Drawing.Point(92, 73);
            this.subProjectsControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.subProjectsControl1.Name = "subProjectsControl1";
            this.subProjectsControl1.Radius = 10;
            this.subProjectsControl1.Size = new System.Drawing.Size(635, 257);
            this.subProjectsControl1.TabIndex = 8;
            // 
            // importBtn
            // 
            this.importBtn.BackColor = System.Drawing.Color.White;
            this.importBtn.BackgroundColor = System.Drawing.Color.White;
            this.importBtn.BorderColor = System.Drawing.Color.Transparent;
            this.importBtn.BorderWidth = 1F;
            this.importBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.importBtn.Font = new System.Drawing.Font("TT Commons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBtn.Location = new System.Drawing.Point(519, 340);
            this.importBtn.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.importBtn.Name = "importBtn";
            this.importBtn.Radius = 10;
            this.importBtn.Size = new System.Drawing.Size(193, 43);
            this.importBtn.TabIndex = 12;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // exportBtn
            // 
            this.exportBtn.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.exportBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exportBtn.BorderColor = System.Drawing.Color.Transparent;
            this.exportBtn.BorderWidth = 1F;
            this.exportBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exportBtn.Location = new System.Drawing.Point(323, 340);
            this.exportBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Radius = 10;
            this.exportBtn.Size = new System.Drawing.Size(176, 32);
            this.exportBtn.TabIndex = 10;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // validateBtn
            // 
            this.validateBtn.BackgroundColor = System.Drawing.Color.White;
            this.validateBtn.BorderColor = System.Drawing.Color.White;
            this.validateBtn.BorderWidth = 1F;
            this.validateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.validateBtn.Location = new System.Drawing.Point(92, 336);
            this.validateBtn.Name = "validateBtn";
            this.validateBtn.Radius = 10;
            this.validateBtn.Size = new System.Drawing.Size(175, 48);
            this.validateBtn.TabIndex = 16;
            this.validateBtn.Click += new System.EventHandler(this.validateBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(854, 559);
            this.Controls.Add(this.importBtnTxt);
            this.Controls.Add(this.validateTextBox);
            this.Controls.Add(this.exportBtnTxt);
            this.Controls.Add(this.loadingTextBox);
            this.Controls.Add(this.unselectBtn);
            this.Controls.Add(this.selectAllBtn);
            this.Controls.Add(this.subProjectsList);
            this.Controls.Add(this.subProjectsControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loadingImage);
            this.Controls.Add(this.importPicBox);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.exportPicBox);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.validatePicBox);
            this.Controls.Add(this.validateBtn);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mobideo Bazan MSP Integration";
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).EndInit();
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
        private SubProjectsControl exportBtn;
        private System.Windows.Forms.TextBox exportBtnTxt;
        private System.Windows.Forms.TextBox importBtnTxt;
        private SubProjectsControl validateBtn;
        private System.Windows.Forms.TextBox validateTextBox;
        private System.Windows.Forms.Button selectAllBtn;
        private System.Windows.Forms.Button unselectBtn;
        private System.Windows.Forms.PictureBox loadingImage;
        private System.Windows.Forms.TextBox loadingTextBox;
        private SubProjectsControl importBtn;
        private System.ComponentModel.BackgroundWorker importService;
        private System.ComponentModel.BackgroundWorker validationService;
        private System.ComponentModel.BackgroundWorker exportService;
        private System.Windows.Forms.PictureBox importPicBox;
        private System.Windows.Forms.PictureBox exportPicBox;
        private System.Windows.Forms.PictureBox validatePicBox;
    }
}