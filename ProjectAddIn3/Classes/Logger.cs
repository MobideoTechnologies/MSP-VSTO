using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAddIn3.Classes
{
    public static class Logger
    {
        public static NLog.ILogger NLogger { get; set; }

        public  static void Debug(string message, params object[] parameters)
        {
            NLogger?.Debug(message, parameters);
        }

        public static void Info(string message, params object[] parameters)
        {
            NLogger?.Info(message, parameters);
        }

        public static void Error(Exception exception, string logMessage, params object[] replacements)
        {
            NLogger?.Error(exception, logMessage, replacements);
        }

        //Seperated from Error to support send email when required.
        public static void Email(string message)
        {
            NLogger?.Fatal(message);
        }
    }
}
