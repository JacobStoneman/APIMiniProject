using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMiniProject.Services.DataHandling
{
	public class ProjectListDTO
	{
        public ProjectListDTO ProjectList { get; set; }
        public void DeserialiseProjectList(string projectListJsonString)
        {
            ProjectList = JsonConvert.DeserializeObject<ProjectListDTO>(projectListJsonString);
        }
    }
}
