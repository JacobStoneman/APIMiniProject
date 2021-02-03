using RestSharp;

namespace APIMiniProject
{
	public abstract class CallManager
	{
		protected IRestClient _client;

		public CallManager()
		{
			_client = new RestClient(AppConfigReader.BaseUrl);
		}

		public string ExecuteRequest(IRestRequest request) => _client.Execute(request).Content;
	}
}
