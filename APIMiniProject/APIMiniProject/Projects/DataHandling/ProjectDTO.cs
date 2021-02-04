using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMiniProject
{
    public class ProjectDTO
    {
        public Project Project { get; set; }
        public void DeserialiseProject(string projectJsonString)
        {
            Project = JsonConvert.DeserializeObject<Project>(projectJsonString);
        }
    }
}
