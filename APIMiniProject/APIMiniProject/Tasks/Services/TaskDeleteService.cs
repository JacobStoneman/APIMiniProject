using RestSharp;

namespace APIMiniProject
{
	public class TaskDeleteService
	{
		public TaskDeleteCallManager CallManager { get; set; } = new TaskDeleteCallManager(new RestClient(AppConfigReader.BaseUrl));
		public TaskDTO Result { get; set; } = new TaskDTO();
		public int Status { get; set; }

		public void DeleteTask(long id)
		{
			IRestResponse response = CallManager.DeleteTask(id);
			Status = (int)response.StatusCode;
			Result.DeserialiseTask(response.Content);
		}

	}
}