using RestSharp;
using System.Collections.Generic;

namespace APIMiniProject
{
	public class ProjectGetService : Service
	{
		public ProjectGetCallManager CallManager { get; set; } = new ProjectGetCallManager(new RestClient(AppConfigReader.BaseUrl));
		public ProjectListDTO Result { get; set; } = new ProjectListDTO();

		public void ProcessResult(IRestResponse response, bool isArray)
		{
			SetStatus(response);
			if (StatusMessage == "OK") Result.DeserialiseProjectList(response.Content, isArray);
		}

		public void GetProjectByID(long id) => ProcessResult(CallManager.GetProjectByID(id), false);
		public void GetAllProjects() =>	ProcessResult(CallManager.GetAllProjects(), true);

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

		public void GetAllByFavourite()
		{
			GetAllProjects();

			List<Project> ProjectsByFavourite = new List<Project>();
			foreach (Project proj in Result.ProjectList)
			{
				if (proj.Favorite) ProjectsByFavourite.Add(proj);
			}

			Result.ProjectList = ProjectsByFavourite.ToArray();
		}

		public int GetProjectCount()
		{
			GetAllProjects();
			return Result.ProjectList.Length;
		}
	}
}