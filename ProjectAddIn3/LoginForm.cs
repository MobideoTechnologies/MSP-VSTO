using Mobideo.ContentServicesClient;
using Mobideo.Integration.ProjectVSTOAddIn;
using Mobideo.Studio.Editor;
using Newtonsoft.Json.Linq;
using ProjectAddIn3.Classes;
using ProjectAddIn3.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAddIn3
{
    public partial class LoginForm : Form
    {
        public IMspVSTOManager MspVSTOManager { get; set; }
        public string UserName
        {
            get; private set;
        }

        public string Token
        {
            get; private set;
        }

        public LoginForm()
        {
            InitializeComponent();
            MspVSTOManager = ServiceProvider.GetService<IMspVSTOManager>();
        }



        private RemoteAuthenticator m_authenticator;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var authenticationUrl = ConfigurationManager.AppSettings["MobideoEnvironmentUrl"] + "/GuidePortal/Account/LogOn?RequestedRoles=ContentReadAccess,Admin";
            var fatalErrorHtml = GetFatalErrorHtml(authenticationUrl);

            m_authenticator = new RemoteAuthenticator(browser, authenticationUrl, fatalErrorHtml);
            m_authenticator.Authenticated += OnAuthenticated;
            m_authenticator.AuthenticationFailed += OnAuthenticatorOnAuthenticationFailed;
            m_authenticator.FatalError += OnAuthenticationFatalError;
        }

        private void OnAuthenticatorOnAuthenticationFailed(object sender, EventArgs eventArgs)
        {
            labelMessage.Visible = true;
            labelMessage.Text = Mobideo.Studio.Editor.Resources.AuthenticationFailed;
            m_authenticator.StartOver();
        }

        private string GetFatalErrorHtml(string authenticationUrl)
        {
            using (
                var stream =
                    typeof(RemoteAuthenticator)
                        .Assembly.GetManifestResourceStream(
                             typeof(RemoteAuthenticator).Namespace + ".Authentication.AuthenticationUnavailable.html"))
            using (var streamReader = new StreamReader(stream))
            {
                return streamReader.ReadToEnd().Replace("{{Url}}", authenticationUrl);
            }
        }

        private void OnAuthenticationFatalError(object sender, EventArgs e)
        {

        }

        private void OnAuthenticated(object sender, AuthenticatedEventArgs e)
        {
            LoggedInUser.Username = e.Username;
            LoggedInUser.Token = e.Token;
            LoggedInUser.Password = string.Empty;
            this.Hide();
            var mainForm = new MainForm();
            mainForm.ShowDialog();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
