using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAddIn3.Interfaces
{
    public  interface ILoginManager
    {
        Task<bool> Login(string username, string password);
    }
}
