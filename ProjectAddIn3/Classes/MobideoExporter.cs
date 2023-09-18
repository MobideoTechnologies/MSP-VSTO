using Aspose.Tasks;
using Microsoft.Office.Interop.MSProject;
using Mobideo.Core;
using Mobideo.Core.Extensions;
using Mobideo.Integration.ProjectVSTOAddIn;
using ProjectAddIn3.Interfaces;
using ProjectAddIn3.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exception = System.Exception;
using Task = System.Threading.Tasks.Task;

namespace ProjectAddIn3.Classes
{
    public class MobideoExporter : IMobideoExporter
    {
        public async Task ExportDataFromMobideoToMsp(IEnumerable<SubProjectWrapper> selectedSubProjects, BackgroundWorker exportService)
        {
            try
            {
                Logger.Info("*** Start export data from mobideo");
                double progressPerecentage = 1.0 / selectedSubProjects.Count() * 100 / 3;
                foreach(var subProject in selectedSubProjects)
                {
                    var subProjectTaskReferenceIds = GetSubProjectTasksReferenceIds(subProject);
                    exportService.ReportProgress((int)progressPerecentage);
                    var subProjectMobideoTasks = await GetSubProjectTasksFromMobideo(subProjectTaskReferenceIds);
                    exportService.ReportProgress((int)progressPerecentage);
                    UpdateMspRecords(subProject, subProjectMobideoTasks);
                    exportService.ReportProgress((int)progressPerecentage);
                }

                Thread.Sleep(2000);
                Logger.Info("*** Done export data from mobideo");

            }
            catch(Exception)
            {
                throw;
            }
        }

        private Dictionary<string,ExportObject> GetSubProjectStartedTasks(Dictionary<string, object> subProjectMobideoTasks)
        {
            var subProjectStartedMobdieoTasks = new Dictionary<string,ExportObject>();
            subProjectMobideoTasks?.ForEach(task =>
            {
                var exportObject = task.Value as ExportObject;
                if (exportObject.Started.HasValue)
                {
                    subProjectStartedMobdieoTasks.Add(task.Key,exportObject);
                }
            });

            return subProjectStartedMobdieoTasks;
        }

        private async Task<Dictionary<string, object>> GetSubProjectTasksFromMobideo(IEnumerable<string> subProjectTaskReferenceIds)
        {
            ITaskService taskService = new TaskService();
            var projectMobideoTasks = await taskService.GetTasksFromMobideo(subProjectTaskReferenceIds);
            return projectMobideoTasks;
        }
        
        private  IEnumerable<string> GetSubProjectTasksReferenceIds(SubProjectWrapper subProject)
        {
            var projectTaskReferenceIds = new HashSet<string>();
            var currentSubProject = subProject.SubProjectLegacyObject.SourceProject;
            foreach (Microsoft.Office.Interop.MSProject.Task syncline in currentSubProject.Tasks)
            {
                if (syncline.OutlineLevel >= int.Parse(ConfigurationManager.AppSettings["MinTaskOutlineLevel"]) && !bool.Parse(syncline.Summary?.ToString()))
                {
                    var rowTaskReferenceId = GetRowTaskReferenceId(syncline).ToUpper().Trim();
                    if (!projectTaskReferenceIds.Contains(rowTaskReferenceId))
                    {
                        projectTaskReferenceIds.Add(rowTaskReferenceId);
                    }
                }
            }
            return projectTaskReferenceIds.ToList();
        }

        private void UpdateMspRecords(SubProjectWrapper subProject, Dictionary<string, object> subProjectMobideoTasks)
        {
            var mspFieldToUpdateMapping = new Dictionary<string, string>();
            var mspFieldsToUpdateArray = ConfigurationManager.AppSettings["MspFieldsToUpdate"].Split(',').Select(mapping => mapping.Trim());
            mspFieldsToUpdateArray.ForEach(mapping =>
            {
                var mspField = mapping.Split('|')[0].Trim();
                var mobideoProperty = mapping.Split('|')[1].Trim();
                mspFieldToUpdateMapping.Add(mspField, mobideoProperty);

            });

            var currentSubProject = subProject.SubProjectLegacyObject.SourceProject;
            foreach (Microsoft.Office.Interop.MSProject.Task syncline in currentSubProject.Tasks)
            {
                
                if (syncline.OutlineLevel >= int.Parse(ConfigurationManager.AppSettings["MinTaskOutlineLevel"]) && !bool.Parse(syncline.Summary?.ToString()))
                {
                    string rowTaskReferenceIdUpper = GetRowTaskReferenceId(syncline).ToUpper().Trim();
                    if (subProjectMobideoTasks.ContainsKey(rowTaskReferenceIdUpper))
                    {
                        var taskInformation = subProjectMobideoTasks[rowTaskReferenceIdUpper] as ExportObject;
                        if (ShouldUpdateMspRecord(taskInformation, syncline))
                        {

                            mspFieldToUpdateMapping.Keys.ForEach(mspFieldToUpdate =>
                            {
                                var mobideoProperty = mspFieldToUpdateMapping[mspFieldToUpdate];
                                var exitingMobideoPropertyValue = taskInformation.GetPropertyValue(mobideoProperty);
                                var propertyInfo = taskInformation.GetType().GetProperty(mobideoProperty);
                                if (exitingMobideoPropertyValue.IsNotNull() && (propertyInfo.PropertyType == typeof(DateTime) || propertyInfo.PropertyType == typeof(DateTime?)))
                                {
                                    exitingMobideoPropertyValue = ConvertUtcToCustomerTimeZone(exitingMobideoPropertyValue);
                                }

                                syncline.SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant(mspFieldToUpdate), exitingMobideoPropertyValue?.ToString());
                            });
                        }
                    }
                }
            }
        }

        private bool ShouldUpdateMspRecord(ExportObject taskInformation, Microsoft.Office.Interop.MSProject.Task syncline)
        {
            if(!taskInformation.Started.HasValue) // task is not started
            {
                return false;
            }

            if (taskInformation.Completed.HasValue && !syncline.Date10.ToString().CaseInsensitiveEquals("NA")) // task is completed in msp
            {
                return false;
            }

            return true;
        }

        private object ConvertUtcToCustomerTimeZone(object exitingMobideoPropertyValue)
        {
            var propertyDateTimeValue = exitingMobideoPropertyValue as DateTime?;
            var customerTimeZone = ConfigurationManager.AppSettings["CustomerTimeZone"];
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(customerTimeZone);
            DateTime convertedDateTime = TimeZoneInfo.ConvertTimeFromUtc(propertyDateTimeValue.Value, timeZoneInfo);
            return convertedDateTime;
        }

   

        private string GetRowTaskReferenceId(Microsoft.Office.Interop.MSProject.Task syncline)
        {
            var taskReferenceIdSourceFieldsArray = ConfigurationManager.AppSettings["TaskReferenceIdSourceFields"].Split(',').Select(field => field.Trim()).ToArray();
            var taskReferecneIdSourceFieldsByLevel = taskReferenceIdSourceFieldsArray.Select(sourceField => new KeyValuePair<string,int>(sourceField.Split('|')[0].Trim(),int.Parse(sourceField.Split('|')[1].Trim())));
            var taskReferenceIdSourceFieldsValues = new List<string>();
            taskReferecneIdSourceFieldsByLevel.ForEach(sourceField =>
            {
                var sourceFieldName = sourceField.Key;
                var sourceFieldLevel = sourceField.Value;
                var sourceFieldValue = string.Empty;
                if(sourceFieldLevel > 0)
                {
                    var parent = syncline;
                    for(int i=0; i<sourceFieldLevel; i++)
                    {
                         parent = parent.OutlineParent;
                    }
                    
                    sourceFieldValue = parent.GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant(sourceFieldName));
                }
                else
                {
                    sourceFieldValue = syncline.GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant(sourceFieldName));

                }
                
                taskReferenceIdSourceFieldsValues.Add(sourceFieldValue.NotNullOrEmpty() ? sourceFieldValue : string.Empty);
            });

            var rowTaskReferenceId = string.Format(ConfigurationManager.AppSettings["TaskReferenceIdFormat"], taskReferenceIdSourceFieldsValues.ToArray());
            return rowTaskReferenceId;
        }
    }
}
