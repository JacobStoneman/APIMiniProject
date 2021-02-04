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

		public void EditTask(long id, string content = "", long[] label_ids = null, int priority = -1, string due_string = "", string due_date = "", string due_datetime = "", string due_lang = "", long assignee = -1)
		{
			JObject jsonbody = new JObject();
			if (content != "")
			{
				jsonbody.Add("content", content);
			}
			if (priority > -1)
			{
				jsonbody.Add("priority", priority);
			}
			if (due_string != "")
			{
				jsonbody.Add("due_string", due_string);
			}
			if (due_date != "")
			{
				jsonbody.Add("due_date", due_date);
			}
			if (due_datetime != "")
			{
				jsonbody.Add("due_datetime", due_datetime);
			}
			if (due_lang != "")
			{
				jsonbody.Add("due_lang", due_lang);
			}
			if (assignee > -1)
			{
				jsonbody.Add("assignee", assignee);
			}
			var response = TaskEditCallManager.PostTask(id, jsonbody);
			Status = (int)response.StatusCode;
			ResponseContent = response.Content;
		}
	}
}
