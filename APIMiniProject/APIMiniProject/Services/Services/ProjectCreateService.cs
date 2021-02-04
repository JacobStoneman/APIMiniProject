﻿    using Newtonsoft.Json;
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

        public void CreateProject(string name, long? parentId = null, int? colour = null, bool favourite = false)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("name", name);
            if (parentId != null) { parameters.Add("parent_id", parentId); }
            if (colour != null) { parameters.Add("color", colour); }
            parameters.Add("favorite", favourite.ToString().ToLower());

            IRestResponse response = ProjectCreateCallManager.CreateProject(parameters);
            Status = response.StatusCode.ToString();
            
            string content = response.Content;
            if(Status.Equals("OK")){ 
                ProjectDTO.DeserialiseProject(content);
                ProjectJson = JsonConvert.DeserializeObject<JObject>(content);
            }
            
        }
    }
}
