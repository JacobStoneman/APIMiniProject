using RestSharp;

namespace APIMiniProject
{
    public class ProjectDeleteCallManager : CallManager
    {
        public ProjectDeleteCallManager(IRestClient restClient) : base(restClient) { }

        public IRestResponse DeleteProject(long id)
        {
            RestRequest request = new RestRequest("projects/" + id, Method.DELETE);
            request.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");

            return ExecuteRequest(request);
        }
    }
}
