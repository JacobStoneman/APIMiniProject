using RestSharp;
using System.Collections.Generic;

namespace APIMiniProject
{
	public class TaskGetService : Service
	{
		public TaskGetCallManager CallManager { get; set; } = new TaskGetCallManager(new RestClient(AppConfigReader.BaseUrl));
		public TaskListDTO Result { get; set; } = new TaskListDTO();

		public void ProcessResult(IRestResponse response, bool isArray)
		{
			SetStatus(response);
			if (StatusMessage == "OK") Result.DeserialiseTask(response.Content, isArray);
		}

		public void GetActiveTasks(long? projectID = null, long? labelID = null, string Filter = null, string Lang = null, long[] IDs = null)
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			if (projectID != null) { parameters.Add("project_id", projectID); }
			if (labelID != null) { parameters.Add("label_id", labelID); }
			if (Filter != null) { parameters.Add("filter", Filter); }
			if (Lang != null) { parameters.Add("lang", Lang); }
			if (IDs != null) { parameters.Add("ids", IDs); }

			ProcessResult(CallManager.GetActiveTasks(parameters), true);
		}

		public void GetActiveTaskByID(long id) => ProcessResult(CallManager.GetActiveTaskByID(id), false);
	}
}