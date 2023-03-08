using Microsoft.Office.Interop.MSProject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAddIn3.Classes
{
    public class SubProjectWrapper
    {
        public string FileName { get; set; }
        public Subproject SubProjectLegacyObject { get; set; }
        public SubProjectWrapper(Subproject subProjectLegacyObject)
        {
            SubProjectLegacyObject = subProjectLegacyObject;
            FileName = Path.GetFileName(subProjectLegacyObject.Path);
        }
    }
}
