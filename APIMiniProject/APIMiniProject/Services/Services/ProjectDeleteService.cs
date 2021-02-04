using RestSharp;

namespace APIMiniProject
{
	public class ProjectDeleteService
	{
		public ProjectDeleteCallManager CallManager { get; set; } = new ProjectDeleteCallManager(new RestClient(AppConfigReader.BaseUrl));
		public ProjectDTO Result { get; set; } = new ProjectDTO();
		public int Status { get; set; }

		//public ProjectDeleteService(ProjectCrCallManager projectCreateCallManager)
		//{
		//	ProjectCreateCallManager = projectCreateCallManager;
		//}
		public void DeleteProject(long id)
		{
			IRestResponse response = CallManager.DeleteProject(id);
			Status = (int)response.StatusCode;
			Result.DeserialiseProject(response.Content);
		}

	}
}