﻿using Newtonsoft.Json;

namespace APIMiniProject
{
	public class ProjectListDTO
	{
        public Project[] ProjectList { get; set; } = new Project[1];
        public void DeserialiseProjectList(string projectListJsonString, bool isArray)
        {
            if (isArray)
            {
                ProjectList = JsonConvert.DeserializeObject<Project[]>(projectListJsonString);
            } else
			{
                ProjectList[0] = JsonConvert.DeserializeObject<Project>(projectListJsonString);
			}
        }
    }
}