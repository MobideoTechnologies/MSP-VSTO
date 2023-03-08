using Mobideo.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAddIn3.Classes
{
    public  class ServiceProvider
    {
        public static Dictionary<string,object> Services { get; set; }

        public static void Add<T>(object service) where T : class
        {
            if (Services.IsNull())
            {
                Services =new Dictionary<string,object>();
            }

            if (!Services.ContainsKey(typeof(T).Name))
            {
                Services.Add(typeof(T).Name, service);
            }
        }

        public static T GetService<T>() where T : class
        {
            return Services[typeof(T).Name] as T;
        }
    }
}
