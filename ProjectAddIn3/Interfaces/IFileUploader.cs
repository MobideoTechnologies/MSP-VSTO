using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAddIn3.Interfaces
{
    public interface IFileUploader
    {
         Task UploadFile(string path, Stream stream, string targetFolder, bool addTimeStamp=false);
    }
}
