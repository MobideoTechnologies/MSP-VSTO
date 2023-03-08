using Mobideo.Integration.ProjectVSTOAddIn;
using ProjectAddIn3.Classes;
using ProjectAddIn3.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAddIn3
{
    public partial class LoginForm : Form
    {
        public IMspVSTOManager MspVSTOManager { get; set; }
        public LoginForm()
        {
            InitializeComponent();
            MspVSTOManager = ServiceProvider.GetService<IMspVSTOManager>();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool isUserLoggedIn = MspVSTOManager.Login(userTextBox.Text?.Trim(), PasswordTextBox.Text).GetAwaiter().GetResult();
            if (isUserLoggedIn)
            {
                LoggedInUser.Username = userTextBox.Text.Trim();
                LoggedInUser.Password = PasswordTextBox.Text;
                this.Hide();
                var mainForm = new MainForm();
                mainForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Login failed. Please check username or password");
            }
        }
    }
}
