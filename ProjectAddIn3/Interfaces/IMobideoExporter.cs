using ProjectAddIn3.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAddIn3.Interfaces
{
    public interface IMobideoExporter
    {
        Task ExportDataFromMobideoToMsp(IEnumerable<SubProjectWrapper> selectedSubProjects);
    }
}
