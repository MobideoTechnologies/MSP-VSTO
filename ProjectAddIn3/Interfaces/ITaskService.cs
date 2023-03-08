using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAddIn3.Interfaces
{
    public interface ITaskService
    {
        Task<Dictionary<string, object>> GetTasksFromMobideo(IEnumerable<string> taskReferneceIds);
    }
}
