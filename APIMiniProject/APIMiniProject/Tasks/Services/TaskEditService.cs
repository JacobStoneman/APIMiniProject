using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace APIMiniProject
{
	public class TaskEditService
	{
		public TaskEditCallManager TaskEditCallManager { get; set; }
		public int Status { get; set; }
		public string ResponseContent { get; set; }
		public TaskEditService(TaskEditCallManager taskEditCallManager)
		{
			TaskEditCallManager = taskEditCallManager;
		}

		public void EditTask(long id, string content = "", int? priority = null, string due_string = null, string due_date = null, string due_datetime = null, string due_lang = null, long? assignee = null)
		{
			JObject jsonbody = new JObject();
			if (content != "")
			{
				jsonbody.Add("content", content);
			}
			if (priority != null)
			{
				jsonbody.Add("priority", priority);
			}
			if (due_string != null)
			{
				jsonbody.Add("due_string", due_string);
			}
			if (due_date != null)
			{
				jsonbody.Add("due_date", due_date);
			}
			if (due_datetime != null)
			{
				jsonbody.Add("due_datetime", due_datetime);
			}
			if (due_lang != null)
			{
				jsonbody.Add("due_lang", due_lang);
			}
			if (assignee != null)
			{
				jsonbody.Add("assignee", assignee);
			}
			var response = TaskEditCallManager.PostTask(id, jsonbody);
			Status = (int)response.StatusCode;
			ResponseContent = response.Content;
		}

		public void CompleteTask(long id)
		{
			var response = TaskEditCallManager.CompleteTask(id);
			Status = (int)response.StatusCode;
			ResponseContent = response.Content;
		}
	}
}
