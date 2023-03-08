using ProjectAddIn3.Interfaces;
using ProjectAddIn3.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAddIn3.Classes
{
    public class LoginManager : ILoginManager
    {
        public Task<bool> Login(string username, string password)
        {
            var queryServicesClient = new GuideServicesQueryApiWebServiceClient("GuideServicesQueryApiWebService");
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                queryServicesClient.GetUtcNow(new TokenCredentials(), new UserCredentials() { UserName= username, Password = password });
                return Task.FromResult(true);
            }
            catch(Exception ex)
            {
                Logger.Error(ex, "Login failed for user {0}", username);
                return Task.FromResult(false);
            }


        }
    }
}
