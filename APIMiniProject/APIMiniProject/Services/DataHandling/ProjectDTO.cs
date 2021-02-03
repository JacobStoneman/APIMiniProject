using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMiniProject.Services.DataHandling
{
    public class ProjectDTO
    {
        public ProjectDTO Project { get; set; }
        public void DeserialiseProject(string projectJsonString)
        {
            Project = JsonConvert.DeserializeObject<ProjectDTO>(projectJsonString);
        }
    }
}
