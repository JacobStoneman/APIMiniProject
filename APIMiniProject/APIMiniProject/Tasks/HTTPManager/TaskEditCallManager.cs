using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace APIMiniProject
{
	public class TaskEditCallManager : CallManager
	{
		public TaskEditCallManager(IRestClient _client) : base(_client)
		{
		}

		public IRestResponse PostTask(long id, JObject jsonbody)
		{
			IRestRequest request = new RestRequest(Method.POST);
			request.Resource = $"tasks/{id}";
			request.AddJsonBody(jsonbody.ToString());
			request.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");


			return ExecuteRequest(request);
		}

		public IRestResponse CompleteTask(long id)
		{
			IRestRequest request = new RestRequest(Method.POST);
			request.Resource = $"tasks/{id}/close";
			request.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");


			return ExecuteRequest(request);
		}


	}
}
