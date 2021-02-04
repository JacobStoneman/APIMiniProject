using RestSharp;

namespace APIMiniProject
{
    public class TaskDeleteCallManager : CallManager
    {
        public TaskDeleteCallManager(IRestClient restClient) : base(restClient) { }

        public IRestResponse DeleteTask(long id)
        {
            RestRequest request = new RestRequest("tasks/" + id, Method.DELETE);
            request.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");

            return ExecuteRequest(request);
        }
    }
}
