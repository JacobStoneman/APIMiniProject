using RestSharp;

namespace APIMiniProject
{
	public class TaskGetService
	{
		public TaskGetCallManager CallManager { get; set; } = new TaskGetCallManager(new RestClient(AppConfigReader.BaseUrl));
		public void GetActiveTasksByID(long? projectID = null, long? labelID = null, string Filter = null, string Lang = null, long[] IDs = null)
		{
			TaskParameter newParameters = new TaskParameter(projectID, labelID, Filter, Lang, IDs);
			CallManager.GetActiveTasksByID(newParameters);
		}
	}
}
