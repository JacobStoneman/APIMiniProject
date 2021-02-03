using RestSharp;

namespace APIMiniProject
{
	public class ProjectGetService
	{
		public ProjectGetCallManager CallManager { get; set; } = new ProjectGetCallManager(new RestClient(AppConfigReader.BaseUrl));
		public ProjectListDTO Result { get; set; } = new ProjectListDTO();
		public int Status { get; set; }

		public void GetProjectByID(long id)
		{
			IRestResponse response = CallManager.GetProjectByID(id);
			Status = (int)response.StatusCode;
			Result.DeserialiseProjectList(response.Content, false);
		}
		public void GetAllProjects()
		{
			IRestResponse response = CallManager.GetAllProjects();
			Status = (int)response.StatusCode;
			Result.DeserialiseProjectList(response.Content, true);
		}
	}
}