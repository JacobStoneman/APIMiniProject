using Newtonsoft.Json;

namespace APIMiniProject
{
	public class ProjectListDTO
	{
        public Project[] ProjectList { get; set; }
        public void DeserialiseProjectList(string projectListJsonString)
        {
            ProjectList = JsonConvert.DeserializeObject<Project[]>(projectListJsonString);
        }
    }
}