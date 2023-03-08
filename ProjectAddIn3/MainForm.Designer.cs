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
            this.subProjectsList = new System.Windows.Forms.CheckedListBox();
            this.exportBtn = new System.Windows.Forms.Button();
            this.importBtn = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // subProjectsList
            // 
            this.subProjectsList.DisplayMember = "FileName";
            this.subProjectsList.FormattingEnabled = true;
            this.subProjectsList.Location = new System.Drawing.Point(392, 110);
            this.subProjectsList.Name = "subProjectsList";
            this.subProjectsList.Size = new System.Drawing.Size(357, 211);
            this.subProjectsList.TabIndex = 3;
            this.subProjectsList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.subProjectsList_ItemCheck);
            // 
            // exportBtn
            // 
            this.exportBtn.Enabled = false;
            this.exportBtn.Location = new System.Drawing.Point(392, 362);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(357, 48);
            this.exportBtn.TabIndex = 4;
            this.exportBtn.Text = "Export data from Mobideo to project";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // importBtn
            // 
            this.importBtn.Enabled = false;
            this.importBtn.Location = new System.Drawing.Point(392, 435);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(357, 51);
            this.importBtn.TabIndex = 5;
            this.importBtn.Text = "Import data from project to Mobideo";
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // importProgressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(392, 553);
            this.progressBar.Name = "importProgressBar";
            this.progressBar.Size = new System.Drawing.Size(357, 61);
            this.progressBar.TabIndex = 6;
            this.progressBar.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(388, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Please select files";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.subProjectsList);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Mobideo Integration VSTO";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckedListBox subProjectsList;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label1;
    }
}