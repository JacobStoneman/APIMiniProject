using RestSharp;

namespace APIMiniProject
{
	public class ProjectGetCallManager : CallManager
	{
		public ProjectGetCallManager(IRestClient _client) : base(_client)
		{
		}

		public string GetProjectByID()
		{
			return string.Empty;
		}
		public string GetAllProjects()
		{
			return string.Empty;
		}
	}
}
