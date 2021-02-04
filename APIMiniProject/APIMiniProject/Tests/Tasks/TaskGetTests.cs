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

		[Test]
		[Ignore("Waiting for create and delete task services")]
		public void GetActiveTasksByProjectID()
		{
			//Create task

			_taskGetService.GetActiveTasks(projectID: testProjID);
			Assert.That(_taskGetService.Result.Tasks.Length, Is.GreaterThan(0));

			//Delete task
		}

		[Test]
		[Ignore("Waiting for create and delete task services")]
		public void GetSingleActiveTaskByID()
		{
			//Create task

			_taskGetService.GetActiveTasks();
			Assert.That(_taskGetService.Result.Tasks.Length, Is.GreaterThan(0));

			//Delete task
		}

		[Test]
		[Ignore("Waiting for create and delete task services")]
		public void GetActiveTasksByIDs()
		{
			//Create tasks

			//get task ids
			long[] taskIDs = new long[0];

			_taskGetService.GetActiveTasks(IDs: taskIDs);
			Assert.That(_taskGetService.Result.Tasks.Length, Is.GreaterThan(0));

			//Delete tasks
		}

		[Test]
		[Ignore("Waiting for create and delete task services")]
		public void GetActiveTasksByFilter()
		{
			//Create task

			_taskGetService.GetActiveTasks(Filter: "TestTask");
			Assert.That(_taskGetService.Result.Tasks.Length, Is.GreaterThan(0));

			//Delete task
		}

		[Test]
		[Ignore("Waiting for create and delete task services")]
		public void GetActiveTasksByFilterAndProjectID()
		{
			//Create task

			_taskGetService.GetActiveTasks(projectID: testProjID,Filter: "TestTask");
			Assert.That(_taskGetService.Result.Tasks.Length, Is.GreaterThan(0));

			//Delete task
		}
	}
}
