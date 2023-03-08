
using System.Configuration;

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
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.environmentUrlLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(204, 88);
            this.userLabel.Name = "userLabel";
            this.userLabel.Text = ConfigurationManager.AppSettings["UsernameLabelText"];
            this.userLabel.Size = new System.Drawing.Size(0, 20);
            this.userLabel.TabIndex = 0;
            // 
            // userTextBox
            // 
            this.userTextBox.Location = new System.Drawing.Point(330, 88);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(208, 26);
            this.userTextBox.TabIndex = 1;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(204, 156);
            this.PasswordLabel.Name = "PasswordLabel";
             this.PasswordLabel.Text = ConfigurationManager.AppSettings["PasswordLabelText"];
            this.PasswordLabel.Size = new System.Drawing.Size(0, 20);
            this.PasswordLabel.TabIndex = 2;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(330, 156);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(208, 26);
            this.PasswordTextBox.TabIndex = 3;
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(218, 240);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(320, 44);
            this.LoginBtn.Text = ConfigurationManager.AppSettings["LoginBtnText"];
            this.LoginBtn.TabIndex = 4;
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // environmentUrlLbl
            // 
            this.environmentUrlLbl.AutoSize = true;
            this.environmentUrlLbl.Location = new System.Drawing.Point(353, 339);
            this.environmentUrlLbl.Name = "environmentUrlLbl";
            this.environmentUrlLbl.Text = ConfigurationManager.AppSettings["MobideoEnvironmentUrl"];
            this.environmentUrlLbl.Size = new System.Drawing.Size(0, 20);
            this.environmentUrlLbl.TabIndex = 5;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.environmentUrlLbl);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.userTextBox);
            this.Controls.Add(this.userLabel);
            this.Name = "LoginForm";
            this.Text = ConfigurationManager.AppSettings["UpperTabText"];
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Label environmentUrlLbl;
    }
}