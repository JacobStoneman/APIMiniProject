using NUnit.Framework;
using RestSharp;

namespace APIMiniProject
{
	public class TaskGetTests
	{
		TaskGetService _taskGetService = new TaskGetService();
		private long testProjID;

		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			ProjectCreateService projectCreateService = new ProjectCreateService(new ProjectCreateCallManager(new RestClient(AppConfigReader.BaseUrl)));
			projectCreateService.CreateProject("TaskTestProject");
			testProjID = projectCreateService.ProjectDTO.Project.Id;
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			ProjectDeleteService projectDeleteService = new ProjectDeleteService();
			projectDeleteService.DeleteProject(testProjID);
		}

		[Test]
		public void GetActiveTasksRequestOK()
		{
			_taskGetService.GetActiveTasks();
			Assert.That(_taskGetService.StatusCode, Is.EqualTo(200));
			Assert.That(_taskGetService.StatusMessage, Is.EqualTo("OK"));
		}
	}
}
