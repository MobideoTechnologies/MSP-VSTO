using ProjectAddIn3.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAddIn3.Interfaces
{
    public interface IMobideoImporter
    {
        Task<Tuple<int,int>> ImportFilesToMobideo(IEnumerable<SubProjectWrapper> selectedSubProjects, BackgroundWorker backgroundService, bool validateOnly = false);
    }
}
