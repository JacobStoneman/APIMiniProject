using NUnit.Framework;
using RestSharp;

namespace APIMiniProject
{
	public class TaskGetTests
	{
		TaskGetService _taskGetService = new TaskGetService();
		TaskDeleteService _taskDeleteService = new TaskDeleteService();
		TaskCreateService _taskCreateService = new TaskCreateService(new TaskCreateCallManager(new RestClient(AppConfigReader.BaseUrl)));
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

		long CreateTestTask() 
		{
			_taskCreateService.CreateTaskDueString(taskContent: "TestContent");
			return _taskCreateService.TaskDTO.Task.Id;
		}
		void DeleteTestTask(long id) => _taskDeleteService.DeleteTask(id);

		[Test]
		public void GetActiveTasksRequestOK()
		{
			_taskGetService.GetActiveTasks();
			Assert.That(_taskGetService.StatusCode, Is.EqualTo(200));
			Assert.That(_taskGetService.StatusMessage, Is.EqualTo("OK"));
		}

		[Test]
		public void GetActiveTaskByIDRequestOK()
		{
			long testTaskID = CreateTestTask();

			_taskGetService.GetActiveTaskByID(testTaskID);
			Assert.That(_taskGetService.StatusCode, Is.EqualTo(200));
			Assert.That(_taskGetService.StatusMessage, Is.EqualTo("OK"));

			DeleteTestTask(testTaskID);
		}

		[Test]
		public void GetActiveTaskByInvalidIDRequestNotFound()
		{
			_taskGetService.GetActiveTaskByID(-1);
			Assert.That(_taskGetService.StatusCode, Is.EqualTo(404));
			Assert.That(_taskGetService.StatusMessage, Is.EqualTo("NotFound"));
		}

		[Test]
		public void GetActiveTaskByIDReturnsCorrectContent()
		{
			long testTaskID = CreateTestTask();

			_taskGetService.GetActiveTaskByID(testTaskID);
			Assert.That(_taskGetService.Result.Tasks[0].Content, Is.EqualTo("TestContent"));

			DeleteTestTask(testTaskID);
		}

		[Test]
		public void GetActiveTasksByProjectID()
		{
			long testTaskID = CreateTestTask();

			_taskGetService.GetActiveTasks(projectID: testProjID);
			Assert.That(_taskGetService.Result.Tasks.Length, Is.GreaterThan(0));

			DeleteTestTask(testTaskID);
		}
	}
}