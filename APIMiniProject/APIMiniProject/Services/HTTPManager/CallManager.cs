using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMiniProject
{
	public abstract class CallManager
	{
		protected IRestClient _client;

		public CallManager()
		{
			_client = new RestClient(AppConfigReader.BaseUrl);
		}

		public abstract string ExecuteRequest();
	}
}
