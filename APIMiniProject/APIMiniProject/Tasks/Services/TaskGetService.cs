﻿using RestSharp;

namespace APIMiniProject
{
	public class TaskGetService : Service
	{
		public TaskGetCallManager CallManager { get; set; } = new TaskGetCallManager(new RestClient(AppConfigReader.BaseUrl));
		public TaskListDTO Result { get; set; } = new TaskListDTO();

		public void ProcessResult(IRestResponse response)
		{
			SetStatus(response);
			if (StatusMessage == "OK") Result.DeserialiseTask(response.Content);
		}

		public void GetActiveTasks(long? projectID = null, long? labelID = null, string Filter = null, string Lang = null, long[] IDs = null)
		{
			TaskParameter newParameters = new TaskParameter(projectID, labelID, Filter, Lang, IDs);
			ProcessResult(CallManager.GetActiveTasks(newParameters));
		}
	}
}
