using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMiniProject
{
    public class ProjectCreateService
    {
        public ProjectCreateCallManager ProjectCreateCallManager;
        public string ResponseAsString;
        public ProjectCreateService(ProjectCreateCallManager projectCreateCallManager)
        {
            ProjectCreateCallManager = projectCreateCallManager;
        }

        public void CreateProjectWithName(string name)
        {
            var response = ProjectCreateCallManager.CreateProject(name);
        }
    }
}
