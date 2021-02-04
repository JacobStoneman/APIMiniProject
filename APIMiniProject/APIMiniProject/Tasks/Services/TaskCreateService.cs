using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMiniProject
{
    public class TaskCreateService : Service
    {
        public TaskCreateCallManager TaskCreateCallManager { get; set; }
        public TaskDTO TaskDTO { get; set; } = new TaskDTO();
        public JObject TaskJson { get; set; }

        public TaskCreateService(TaskCreateCallManager taskCreateCallManager)
        {
            TaskCreateCallManager = taskCreateCallManager;
        }

        public void CreateTask(string taskContent, long? projectId = null, long? sectionId = null, bool completed = false, long? parentId = null,
            int? order = null, int? priority = null, string dueString = null, string dueDate = null, DateTime? dueDateTime = null, string dueLang = null)
        {
            JObject parameters = new JObject();
            parameters.Add("content", taskContent);
            if (projectId != null) { parameters.Add("project_id", projectId); }
            if (sectionId != null) { parameters.Add("section_id", sectionId); }
            if (parentId != null) { parameters.Add("parent_id", parentId); }
            if (order != null) { parameters.Add("order", order); }
            if (priority != null) { parameters.Add("priority", priority); }
            if (dueString != null) { parameters.Add("due_string", dueString); }
            if (dueDate != null) { parameters.Add("due_string", dueDate); }
            if (dueDateTime != null) { parameters.Add("due_date_time", dueDateTime); }
            if (dueLang != null) { parameters.Add("due_lang", dueLang); }
            parameters.Add("completed", completed.ToString().ToLower());

            IRestResponse response = TaskCreateCallManager.CreateTask(parameters);
            SetStatus(response);

            string content = response.Content;
            if (StatusMessage.Equals("OK"))
            {
                TaskDTO.DeserialiseTask(content);
                TaskJson = JsonConvert.DeserializeObject<JObject>(content);
            }
        }
    }
}
