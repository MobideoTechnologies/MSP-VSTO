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
            this.label1 = new System.Windows.Forms.Label();
            this.subProjectsControl1 = new ProjectAddIn3.Controls.SubProjectsControl();
            this.subProjectsList = new System.Windows.Forms.CheckedListBox();
            this.exportBtn = new ProjectAddIn3.Controls.SubProjectsControl();
            this.exportBtnTxt = new System.Windows.Forms.TextBox();
            this.importBtn = new ProjectAddIn3.Controls.SubProjectsControl();
            this.importBtnTxt = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TT Commons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(294, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Please select files";
            // 
            // subProjectsControl1
            // 
            this.subProjectsControl1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.subProjectsControl1.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.subProjectsControl1.BorderWidth = 5F;
            this.subProjectsControl1.Location = new System.Drawing.Point(283, 138);
            this.subProjectsControl1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.subProjectsControl1.Name = "subProjectsControl1";
            this.subProjectsControl1.Radius = 10;
            this.subProjectsControl1.Size = new System.Drawing.Size(668, 386);
            this.subProjectsControl1.TabIndex = 8;
            // 
            // subProjectsList
            // 
            this.subProjectsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.subProjectsList.DisplayMember = "FileName";
            this.subProjectsList.Font = new System.Drawing.Font("TT Commons", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subProjectsList.ForeColor = System.Drawing.SystemColors.MenuText;
            this.subProjectsList.FormattingEnabled = true;
            this.subProjectsList.Location = new System.Drawing.Point(316, 166);
            this.subProjectsList.Margin = new System.Windows.Forms.Padding(4);
            this.subProjectsList.Name = "subProjectsList";
            this.subProjectsList.Size = new System.Drawing.Size(514, 300);
            this.subProjectsList.TabIndex = 9;
            this.subProjectsList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.subProjectsList_ItemCheck);
            // 
            // exportBtn
            // 
            this.exportBtn.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.exportBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exportBtn.BorderColor = System.Drawing.Color.Transparent;
            this.exportBtn.BorderWidth = 1F;
            this.exportBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exportBtn.Location = new System.Drawing.Point(283, 540);
            this.exportBtn.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Radius = 10;
            this.exportBtn.Size = new System.Drawing.Size(332, 80);
            this.exportBtn.TabIndex = 10;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // exportBtnTxt
            // 
            this.exportBtnTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.exportBtnTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exportBtnTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exportBtnTxt.Font = new System.Drawing.Font("TT Commons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportBtnTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(111)))), ((int)(((byte)(239)))));
            this.exportBtnTxt.Location = new System.Drawing.Point(343, 573);
            this.exportBtnTxt.Margin = new System.Windows.Forms.Padding(4);
            this.exportBtnTxt.Name = "exportBtnTxt";
            this.exportBtnTxt.Size = new System.Drawing.Size(256, 28);
            this.exportBtnTxt.TabIndex = 11;
            this.exportBtnTxt.Text = "Export data to project";
            this.exportBtnTxt.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // importBtn
            // 
            this.importBtn.BackColor = System.Drawing.Color.White;
            this.importBtn.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(111)))), ((int)(((byte)(239)))));
            this.importBtn.BorderColor = System.Drawing.Color.Transparent;
            this.importBtn.BorderWidth = 1F;
            this.importBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.importBtn.Font = new System.Drawing.Font("TT Commons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBtn.Location = new System.Drawing.Point(624, 542);
            this.importBtn.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.importBtn.Name = "importBtn";
            this.importBtn.Radius = 10;
            this.importBtn.Size = new System.Drawing.Size(327, 78);
            this.importBtn.TabIndex = 12;
            this.importBtn.Load += new System.EventHandler(this.importBtn_Load);
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // importBtnTxt
            // 
            this.importBtnTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(111)))), ((int)(((byte)(239)))));
            this.importBtnTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.importBtnTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.importBtnTxt.Font = new System.Drawing.Font("TT Commons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBtnTxt.ForeColor = System.Drawing.SystemColors.Window;
            this.importBtnTxt.Location = new System.Drawing.Point(683, 573);
            this.importBtnTxt.Margin = new System.Windows.Forms.Padding(0);
            this.importBtnTxt.Name = "importBtnTxt";
            this.importBtnTxt.Size = new System.Drawing.Size(249, 28);
            this.importBtnTxt.TabIndex = 13;
            this.importBtnTxt.Text = "Import data to Mobideo";
            this.importBtnTxt.Click += new System.EventHandler(this.importBtn_Click);
            this.importBtnTxt.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.SystemColors.Window;
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(111)))), ((int)(((byte)(239)))));
            this.progressBar.Location = new System.Drawing.Point(393, 704);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(384, 47);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 15;
            this.progressBar.Visible = false;
            this.progressBar.Click += new System.EventHandler(this.progressBar_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1281, 900);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.importBtnTxt);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.exportBtnTxt);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.subProjectsList);
            this.Controls.Add(this.subProjectsControl1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mobideo Integration VSTO";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private SubProjectsControl subProjectsControl1;
        private System.Windows.Forms.CheckedListBox subProjectsList;
        private SubProjectsControl exportBtn;
        private System.Windows.Forms.TextBox exportBtnTxt;
        private SubProjectsControl importBtn;
        private System.Windows.Forms.TextBox importBtnTxt;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}