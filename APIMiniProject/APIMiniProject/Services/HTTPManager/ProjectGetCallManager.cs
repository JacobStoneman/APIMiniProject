using RestSharp;

namespace APIMiniProject
{
	public class ProjectGetCallManager : CallManager
	{
		public ProjectGetCallManager(IRestClient _client) : base(_client) {}

		public string GetProjectByID()
		{
			return string.Empty;
		}
		public string GetAllProjects()
		{
			RestRequest request = new RestRequest(Method.GET);
			request.Resource = "projects";
			request.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");
			return ExecuteRequest(request);
		}
	}
}
