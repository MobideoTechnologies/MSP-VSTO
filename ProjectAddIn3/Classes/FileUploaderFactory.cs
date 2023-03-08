using ProjectAddIn3.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAddIn3.Classes
{
    public static class FileUploaderFactory
    {
        public static IFileUploader CreateFileUploader()
        {
            var uploadFileTarget = ConfigurationManager.AppSettings["UploadFileTarget"];
            switch(uploadFileTarget.ToUpper().Trim())
            {
               case "CUSTOMERFILES":
                    return new CustomerFilesFileUploader();
                default:
                    return new CustomerFilesFileUploader(); 
            }
            
        }
    }
}
