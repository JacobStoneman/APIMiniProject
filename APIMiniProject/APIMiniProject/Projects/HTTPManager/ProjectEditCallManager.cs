using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace APIMiniProject
{
	public class ProjectEditCallManager : CallManager
	{
		public ProjectEditCallManager(IRestClient _client) : base(_client)
		{
		}

		public IRestResponse PostProject(long id, JObject jsonbody)
		{
			IRestRequest request = new RestRequest(Method.POST);
			request.Resource = $"projects/{id}";
			request.AddJsonBody(jsonbody.ToString());
			request.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");


			return ExecuteRequest(request);
		}


	}
}
