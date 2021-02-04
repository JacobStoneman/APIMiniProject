using RestSharp;

namespace APIMiniProject
{
    public class ProjectCreateCallManager : CallManager
    {
        public ProjectCreateCallManager(IRestClient restClient) : base(restClient) { }

        public IRestResponse CreateProject(string name, int parentId = -1, int colour = -1, bool favourite = false)
        {
            RestRequest request = new RestRequest("projects", Method.POST);
            request.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");
            request.AddParameter("name", name);
            request.AddParameter("favorite", favourite);
            if (parentId > 0) { request.AddParameter("parent_id", parentId); }
            if(colour > 0) { request.AddParameter("color", parentId); }

            return ExecuteRequest(request);
        }
    }
}
