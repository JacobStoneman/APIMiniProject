using RestSharp;
using System.Collections.Generic;

namespace APIMiniProject
{
    public class ProjectCreateCallManager : CallManager
    {
        public ProjectCreateCallManager(IRestClient restClient) : base(restClient) { }

        public IRestResponse CreateProject(Dictionary<string,object> parameters)
        {
            RestRequest request = new RestRequest("projects", Method.POST);
            request.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");
            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter.Key, parameter.Value);
            }
            return ExecuteRequest(request);
        }
    }
}
