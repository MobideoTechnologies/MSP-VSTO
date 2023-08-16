using Aspose.Tasks;
using Microsoft.Office.Interop.MSProject;
using Mobideo.Core;
using Mobideo.Core.Extensions;
using Mobideo.Integration.ProjectVSTOAddIn;
using ProjectAddIn3.Interfaces;
using ProjectAddIn3.Query;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exception = System.Exception;
using Task = System.Threading.Tasks.Task;

namespace ProjectAddIn3.Classes
{
    public class MobideoExporter : IMobideoExporter
    {
        public async Task ExportDataFromMobideoToMsp(IEnumerable<SubProjectWrapper> selectedSubProjects)
        {
            try
            {
                Logger.Info("*** Start export data from mobideo");
                var projectTaskReferenceIds = GetProjectTasksReferenceIds(selectedSubProjects);
                var projectMobideoTasks = await GetProjectTasksFromMobideo(projectTaskReferenceIds);
                UpdateMspRecords(selectedSubProjects, projectMobideoTasks);
                Logger.Info("*** Done export data from mobideo");

            }
            catch(Exception)
            {
                throw;
            }
        }

        private async Task<Dictionary<string, object>> GetProjectTasksFromMobideo(IEnumerable<string> projectTaskReferenceIds)
        {
            ITaskService taskService = new TaskService();
            var projectMobideoTasks = await taskService.GetTasksFromMobideo(projectTaskReferenceIds);
            return projectMobideoTasks;
        }
        
        private  IEnumerable<string> GetProjectTasksReferenceIds(IEnumerable<SubProjectWrapper> selectedSubProjects)
        {
            var projectTaskReferenceIds = new HashSet<string>();
            foreach (var subProject in selectedSubProjects)
            {
                var currentSubProject = subProject.SubProjectLegacyObject.SourceProject;
                foreach (Microsoft.Office.Interop.MSProject.Task syncline in currentSubProject.Tasks)
                {
                    if (syncline.OutlineLevel >= int.Parse(ConfigurationManager.AppSettings["MinTaskOutlineLevel"]))
                    {
                        var rowTaskReferenceId = GetRowTaskReferenceId(syncline).ToUpper().Trim();
                        if (!projectTaskReferenceIds.Contains(rowTaskReferenceId))
                        {
                            projectTaskReferenceIds.Add(rowTaskReferenceId);
                        }
                    }
                }
            }

            return projectTaskReferenceIds.ToList();
        }

        private void UpdateMspRecords(IEnumerable<SubProjectWrapper> selectedSubProjects, Dictionary<string, object> projectMobideoTasks)
        {
            var mspFieldToUpdateMapping = new Dictionary<string, string>();
            var mspFieldsToUpdateArray = ConfigurationManager.AppSettings["MspFieldsToUpdate"].Split(',').Select(mapping => mapping.Trim());
            mspFieldsToUpdateArray.ForEach(mapping =>
            {
                var mspField = mapping.Split('|')[0].Trim();
                var mobideoProperty = mapping.Split('|')[1].Trim();
                mspFieldToUpdateMapping.Add(mspField, mobideoProperty);

            });

            foreach (var subProject in selectedSubProjects)
            {
                var currentSubProject = subProject.SubProjectLegacyObject.SourceProject;
                foreach (Microsoft.Office.Interop.MSProject.Task syncline in currentSubProject.Tasks)
                {
                    if (syncline.OutlineLevel >= int.Parse(ConfigurationManager.AppSettings["MinTaskOutlineLevel"]) && !bool.Parse(syncline.Summary?.ToString()))
                    {
                        string rowTaskReferenceIdUpper = GetRowTaskReferenceId(syncline).ToUpper().Trim();
                        if (projectMobideoTasks.ContainsKey(rowTaskReferenceIdUpper))
                        {
                            var taskInformation = projectMobideoTasks[rowTaskReferenceIdUpper] as ExportObject;
                            mspFieldToUpdateMapping.Keys.ForEach(mspFieldToUpdate =>
                            {
                                var mobideoProperty = mspFieldToUpdateMapping[mspFieldToUpdate];
                                var exitingMobideoPropertyValue = taskInformation.GetPropertyValue(mobideoProperty);
                                var propertyInfo = taskInformation.GetType().GetProperty(mobideoProperty);
                                if(exitingMobideoPropertyValue.IsNotNull() && (propertyInfo.PropertyType== typeof(DateTime) || propertyInfo.PropertyType == typeof(DateTime?)))
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
