
using Mobideo.Core.Extensions;
using ProjectAddIn3.Interfaces;
using ProjectAddIn3.Query;
using System;
using System.Collections.Generic;
using System.Configuration;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAddIn3.Classes
{
    public class TaskService : ITaskService
    {
        public async Task<Dictionary<string, object>> GetTasksFromMobideo(IEnumerable<string> taskReferneceIds)
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
                var getTasksByReferenceIdsQuery = new AllEntitiesQueryApi { StartIndex = 0, PageSize = pageSize };
                var getTasksExtendedPropertyQuery = new TasksQuery { StartIndex = 0, PageSize = pageSize, ExtendedPropertyName = "Hash", ReturnPrecondition = false };

                for (int i = 0; i < taskReferneceIds.Count(); i += pageSize)
                {
                    var currentTaskReferenceIds = taskReferneceIds.Skip(i).Take(pageSize).ToArray();
                    getTasksByReferenceIdsQuery.ReferenceIds = currentTaskReferenceIds;
                    getTasksExtendedPropertyQuery.ReferenceIds = currentTaskReferenceIds;
                    var getTasksByReferenceIdsThread  = queryServicesClient.GetTasksByReferenceIdsAsync(new TokenCredentials(), userCredentials, getTasksByReferenceIdsQuery);
                    var getTasksExtendedPropertyThread = GetTasksExtendedPropertyDictionary(queryServicesClient, userCredentials, getTasksExtendedPropertyQuery);
                    var getTasksByReferenceIdsResponse = await getTasksByReferenceIdsThread;
                    var getTasksExtendedPropertyDictionary = await getTasksExtendedPropertyThread;
                    getTasksByReferenceIdsResponse.GetTasksByReferenceIdsResult?.Items?.ForEach(item =>
                    {
                        var taskReferenceIdUpper = item?.ReferenceId?.ToUpper().Trim();
                        if (!result.ContainsKey(taskReferenceIdUpper))
                        {
                            if (getTasksExtendedPropertyDictionary.ContainsKey(taskReferenceIdUpper))
                            {
                                var taskInformationObject= getTasksExtendedPropertyDictionary[taskReferenceIdUpper];
                                var exportObject = new ExportObject()
                                {
                                    Started = item.Started,
                                    Completed = item.Completed,
                                    TaskProgressStatus = taskInformationObject.TaskProgressStatus,
                                    ReportedProgress= item.ReportedProgress
                                };

                                result.Add(taskReferenceIdUpper, exportObject);

                            }
                        }
                    });

                    Logger.Debug("Done loading tasks from mobideo, batch number {0}", i + 1);
                }

                Logger.Info("*** Done loading all tasks from mobideo");
                return result;

            }
            catch(Exception ex)
            {
                Logger.Error(ex, "An error occured while loading tasks from mobideo");
                throw;
            }
 
        }

        private async Task<Dictionary<string, TaskInformation>> GetTasksExtendedPropertyDictionary(GuideServicesQueryApiWebServiceClient queryServicesClient, UserCredentials userCredentials, TasksQuery getTasksExtendedPropertyQuery)
        {
            var getTasksExtendedPropertyResponse = await queryServicesClient.GetTasksExtendedPropertyAsync(new TokenCredentials(), userCredentials, getTasksExtendedPropertyQuery);
            var getTaskExtendedPropertyTasks = new Dictionary<string, TaskInformation>();
            getTasksExtendedPropertyResponse.GetTasksExtendedPropertyResult?.Items?.ForEach(item =>
            {
                if (item.TaskInformation.IsNotNull())
                {
                    if (!string.IsNullOrWhiteSpace(item.TaskInformation.ReferenceId) && !getTaskExtendedPropertyTasks.ContainsKey(item.TaskInformation.ReferenceId.ToUpper().Trim()))
                    {
                        getTaskExtendedPropertyTasks.Add(item.TaskInformation.ReferenceId.ToUpper().Trim(), item.TaskInformation);
                    }
                }

            });
            return getTaskExtendedPropertyTasks;
        }

    }
}
