
using Mobideo.Core.Extensions;
using ProjectAddIn3.Interfaces;
using ProjectAddIn3.Query;
using System;
using System.Collections.Generic;
using System.Configuration;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAddIn3.Classes
{
    public class TaskService : ITaskService
    {
        public Task<Dictionary<string, object>> GetTasksFromMobideo(IEnumerable<string> taskReferneceIds)
        {
            try
            {
                Logger.Info("*** Start loading all tasks from mobideo");
                var result = new Dictionary<string, object>();
                var pageSize = int.Parse(ConfigurationManager.AppSettings["GetTaskPageSize"]);
                var queryServicesClient = new GuideServicesQueryApiWebServiceClient("GuideServicesQueryApiWebService");
                var mobideoUser = ConfigurationManager.AppSettings["MobideoUserName"];
                var userPassword = ConfigurationManager.AppSettings["MobideoUserPassword"];
                var userCredentials = new UserCredentials() { UserName = mobideoUser, Password = userPassword };
                var tasksQuery = new TasksQuery { StartIndex = 0, PageSize = pageSize, ExtendedPropertyName = "Hash", ReturnPrecondition = false };

                for (int i = 0; i < taskReferneceIds.Count(); i += pageSize)
                {
                    var currentTaskReferenceIds = taskReferneceIds.Skip(i).Take(pageSize).ToArray();
                    tasksQuery.ReferenceIds = currentTaskReferenceIds;
                    var getTasksExtendedPropertyResponse = queryServicesClient.GetTasksExtendedProperty(new TokenCredentials(), userCredentials, tasksQuery);
                    getTasksExtendedPropertyResponse.Items?.ForEach(item =>
                    {
                        var taskReferenceIdUpper = item.TaskInformation?.ReferenceId?.ToUpper().Trim();
                        if (!result.ContainsKey(taskReferenceIdUpper))
                        {
                            result.Add(taskReferenceIdUpper, item.TaskInformation);
                        }
                    });

                    Logger.Debug("Done loading tasks from mobideo, batch number {0}", i + 1);
                }

                Logger.Info("*** Done loading all tasks from mobideo");
                return Task.FromResult(result);

            }
            catch(Exception ex)
            {
                Logger.Error(ex, "An error occured while loading tasks from mobideo");
                throw;
            }
 
        }
    }
}
