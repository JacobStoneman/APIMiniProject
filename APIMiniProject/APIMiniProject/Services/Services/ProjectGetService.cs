using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMiniProject
{
	public class ProjectGetService
	{
		public ProjectGetCallManager CallManager { get; set; } = new ProjectGetCallManager(new RestClient(AppConfigReader.BaseUrl));
		public ProjectListDTO Result { get; set; } = new ProjectListDTO();

		public void GetProjectByID() =>  Result.DeserialiseProjectList(CallManager.GetProjectByID());
		public void GetAllProjects() => Result.DeserialiseProjectList(CallManager.GetAllProjects());
	}
}
