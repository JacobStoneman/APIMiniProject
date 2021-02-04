using RestSharp;

namespace APIMiniProject
{
	public class ProjectGetCallManager : CallManager
	{
		public ProjectGetCallManager(IRestClient _client) : base(_client) {}

		public IRestResponse GetProjectByID(long id)
		{
			RestRequest request = new RestRequest(Method.GET);
			request.Resource = $"projects/{id}";
			request.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");
			return ExecuteRequest(request);
		}
		public IRestResponse GetAllProjects()
		{
			RestRequest request = new RestRequest(Method.GET);
			request.Resource = "projects";
			request.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");
			return ExecuteRequest(request);
		}
	}
}
