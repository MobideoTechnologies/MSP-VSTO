
using System.Configuration;
using System.Windows.Forms;

namespace ProjectAddIn3
{
    partial class LoginForm
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
            this.userLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.environmentUrlLbl = new System.Windows.Forms.Label();
            this.browser = new Mobideo.Studio.Editor.WebBrowser2();
            this.labelMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(204, 88);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(0, 13);
            this.userLabel.TabIndex = 0;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(204, 155);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(0, 13);
            this.PasswordLabel.TabIndex = 2;
            // 
            // environmentUrlLbl
            // 
            this.environmentUrlLbl.AutoSize = true;
            this.environmentUrlLbl.Location = new System.Drawing.Point(250, 338);
            this.environmentUrlLbl.Name = "environmentUrlLbl";
            this.environmentUrlLbl.Size = new System.Drawing.Size(0, 13);
            this.environmentUrlLbl.TabIndex = 5;
            // 
            // browser
            // 
            this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browser.Location = new System.Drawing.Point(0, 0);
            this.browser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.browser.MinimumSize = new System.Drawing.Size(30, 31);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(1401, 1167);
            this.browser.TabIndex = 0;
            // 
            // labelMessage
            // 
            this.labelMessage.Location = new System.Drawing.Point(0, 0);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(100, 23);
            this.labelMessage.TabIndex = 0;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1401, 1167);
            this.Controls.Add(this.browser);
            this.Controls.Add(this.environmentUrlLbl);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.userLabel);
            this.Name = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label environmentUrlLbl;
        private Mobideo.Studio.Editor.WebBrowser2 browser;
        private Label labelMessage;
    }
}