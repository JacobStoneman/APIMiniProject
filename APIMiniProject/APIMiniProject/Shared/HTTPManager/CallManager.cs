﻿using RestSharp;

namespace APIMiniProject
{
	public abstract class CallManager
	{
		protected IRestClient client;
		

		public CallManager(IRestClient _client)
		{
			client = _client;
		}

		public IRestResponse ExecuteRequest(IRestRequest request) => client.Execute(request);

	}
}
