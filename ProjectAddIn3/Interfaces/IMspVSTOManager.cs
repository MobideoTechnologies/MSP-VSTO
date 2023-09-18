using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAddIn3.Interfaces
{
    public  interface IMspVSTOManager
    {
        Task<bool> Login(string username, string password);
        Task GetAllSubProjects(object subProjectsListBox);
        Task<Tuple<int, int>> Import(object subProjectsListBox, BackgroundWorker backgroundService, bool validateOnly = false);
        Task Export(object subProjectsListBox, BackgroundWorker exportService);
        Task UploadLogFile();


    }
}
