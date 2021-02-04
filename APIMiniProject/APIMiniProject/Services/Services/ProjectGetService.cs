using RestSharp;
using System.Collections.Generic;

namespace APIMiniProject
{
	public class ProjectGetService
	{
		public ProjectGetCallManager CallManager { get; set; } = new ProjectGetCallManager(new RestClient(AppConfigReader.BaseUrl));
		public ProjectListDTO Result { get; set; } = new ProjectListDTO();
		public int Status { get; set; }

		public void ProcessResult(IRestResponse response, bool isArray)
		{
			Status = (int)response.StatusCode;
			Result.DeserialiseProjectList(response.Content, isArray);
		}

		public void GetProjectByID(long id)
		{
			IRestResponse response = CallManager.GetProjectByID(id);
			ProcessResult(response, false);
		}
		public void GetAllProjects()
		{
			IRestResponse response = CallManager.GetAllProjects();
			ProcessResult(response, true);
		}

		public void GetAllByColour(int colourID)
		{
			GetAllProjects();

			List<Project> ProjectsByColour = new List<Project>();
			foreach(Project proj in Result.ProjectList)
			{
				if (proj.Color == colourID) ProjectsByColour.Add(proj);
			}

			Result.ProjectList = ProjectsByColour.ToArray();
		}

		public void GetAllByName(string name)
		{
			GetAllProjects();

			List<Project> ProjectsByName = new List<Project>();
			foreach (Project proj in Result.ProjectList)
			{
				if (proj.Name.ToLower() == name.ToLower()) ProjectsByName.Add(proj);
			}

			Result.ProjectList = ProjectsByName.ToArray();
		}

		public void GetAllByNameIncludes(string name)
		{
			GetAllProjects();

			List<Project> ProjectsByName = new List<Project>();
			foreach (Project proj in Result.ProjectList)
			{
				if (proj.Name.ToLower().Contains(name.ToLower())) ProjectsByName.Add(proj);
			}

			Result.ProjectList = ProjectsByName.ToArray();
		}

		public int GetProjectCount()
		{
			GetAllProjects();
			return Result.ProjectList.Length;
		}
	}
}