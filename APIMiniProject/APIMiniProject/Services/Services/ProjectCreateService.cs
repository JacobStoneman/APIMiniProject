using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMiniProject
{
    public class ProjectCreateService
    {
        public ProjectCreateCallManager ProjectCreateCallManager { get; set; }
        public ProjectDTO ProjectDTO { get; set; } = new ProjectDTO();
        public JObject ProjectJson { get; set; }

        public string Status { get; set; }

        public ProjectCreateService(ProjectCreateCallManager projectCreateCallManager)
        {
            ProjectCreateCallManager = projectCreateCallManager;
        }

        public void CreateProjectWithName(string name)
        {
            IRestResponse response = ProjectCreateCallManager.CreateProject(name);
            Status = response.StatusCode.ToString();

            string content = response.Content;
            ProjectDTO.DeserialiseProject(content);
            ProjectJson = JsonConvert.DeserializeObject<JObject>(content);
        }
    }
}
