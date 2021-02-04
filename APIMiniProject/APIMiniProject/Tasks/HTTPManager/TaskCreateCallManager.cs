using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMiniProject
{
    public class TaskCreateCallManager : CallManager
    {
        public TaskCreateCallManager(IRestClient restClient) : base(restClient) { }

        public IRestResponse CreateTask(JObject parameters)
        {
            RestRequest request = new RestRequest("tasks", Method.POST);

            request.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(parameters.ToString());
            return ExecuteRequest(request);
        }
    }
}
