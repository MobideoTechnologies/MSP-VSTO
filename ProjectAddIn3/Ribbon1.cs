using Microsoft.Office.Tools.Ribbon;
using NLog;
using ProjectAddIn3;
using ProjectAddIn3.Classes;
using ProjectAddIn3.Interfaces;
using ProjectAddIn3.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logger = ProjectAddIn3.Classes.Logger;

namespace Mobideo.Integration.ProjectVSTOAddIn
{
    public partial class Ribbon1
    {
        
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void RunBtn_Click(object sender, RibbonControlEventArgs e)
        {
            Logger.NLogger = new LogFactory().GetCurrentClassLogger();
            ServiceProvider.Add<IMspVSTOManager>(new MspVSTOManager(new LoginManager(), new MobideoImporter(), new MobideoExporter()));
            var loginForm = new LoginForm();
            loginForm.ShowDialog();

        }

    }
}
