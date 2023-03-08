using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAddIn3.Interfaces
{
    public  interface IMspVSTOManager
    {
        Task<bool> Login(string username, string password);
        Task GetAllSubProjects(object subProjectsListBox);
        Task Import(object subProjectsListBox, object importProgressBar);
        Task Export(object subProjectsListBox, object exportProgressBar);
        Task UploadLogFile();


    }
}
