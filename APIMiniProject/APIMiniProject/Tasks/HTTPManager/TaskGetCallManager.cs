using RestSharp;
using System.Collections.Generic;

namespace APIMiniProject
{
	public class TaskGetCallManager : CallManager
	{
		public TaskGetCallManager(IRestClient _client) : base(_client) {}

		public IRestResponse GetActiveTasks(Dictionary<string, object> parameters)
		{
			RestRequest request = new RestRequest(Method.GET);
			request.Resource = "tasks";
			request.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");
			request.AddHeader("Content-Type", "application/json");

			foreach (KeyValuePair<string,object> parameter in parameters)
			{
				request.AddJsonBody(parameter.Value.ToString());
			}

			return ExecuteRequest(request);
		}

		public IRestResponse GetActiveTaskByID(long id)
		{
			RestRequest request = new RestRequest(Method.GET);
			request.Resource = $"tasks/{id}";
			request.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");
			return ExecuteRequest(request);
		}
	}
}