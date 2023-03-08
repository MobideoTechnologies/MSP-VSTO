using ProjectAddIn3.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAddIn3.Interfaces
{
    public interface IMobideoImporter
    {
        Task ImportFilesToMobideo(IEnumerable<SubProjectWrapper> selectedSubProjects, object importProgressBar);
    }
}
