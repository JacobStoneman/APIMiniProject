using RestSharp;

namespace APIMiniProject
{
	public class TaskGetService : ProjectService
	{
		public TaskGetCallManager CallManager { get; set; } = new TaskGetCallManager(new RestClient(AppConfigReader.BaseUrl));

		public void ProcessResult(IRestResponse response)
		{
			SetStatus(response);
			//if (StatusMessage == "OK") Result.DeserialiseProjectList(response.Content, isArray);
		}

		public void GetActiveTasksByID(long? projectID = null, long? labelID = null, string Filter = null, string Lang = null, long[] IDs = null)
		{
			TaskParameter newParameters = new TaskParameter(projectID, labelID, Filter, Lang, IDs);
			ProcessResult(CallManager.GetActiveTasksByID(newParameters));
		}
	}
}
