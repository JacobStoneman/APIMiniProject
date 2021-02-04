using RestSharp;

namespace APIMiniProject
{
	public abstract class ProjectService
	{
		public int StatusCode { get; set; }
		public string StatusMessage { get; set; }

		public void SetStatus(IRestResponse response)
		{
			StatusCode = (int)response.StatusCode;
			StatusMessage = response.StatusCode.ToString();
		}
	}
}
