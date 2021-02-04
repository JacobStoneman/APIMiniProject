using RestSharp;
using System.Reflection;

namespace APIMiniProject
{
	public class TaskParameter
	{
		public TaskParameter(long? projectID, long? labelID, string Filter, string Lang, long[] IDs)
		{
			project_id = projectID;
			label_id = labelID;
			filter = Filter;
			lang = Lang;
			ids = IDs;
		}

		long? project_id { get; set; } = null;
		long? label_id { get; set; } = null;
		string filter { get; set; } = null;
		string lang { get; set; } = null;
		long[] ids { get; set; } = null;
	}

	public class TaskGetCallManager : CallManager
	{
		public TaskGetCallManager(IRestClient _client) : base(_client) {}

		public IRestResponse GetActiveTasks(TaskParameter parameters)
		{
			RestRequest request = new RestRequest(Method.GET);
			request.Resource = $"tasks";

			foreach(PropertyInfo property in parameters.GetType().GetProperties())
			{
				if (property.GetValue(property.GetType()) != null) request.AddParameter(property.Name, property.GetValue(property.GetType()));
			}

			request.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");
			return ExecuteRequest(request);
		}
	}
}
