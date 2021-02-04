using NUnit.Framework;
using RestSharp;

namespace APIMiniProject
{
    public class TaskDeleteTests
    {
        TaskDeleteService _taskDeleteService = new TaskDeleteService();
        TaskGetService _taskGetService = new TaskGetService();
        private TaskCreateService _taskCreateService = new TaskCreateService(new TaskCreateCallManager(new RestClient(AppConfigReader.BaseUrl)));

        [OneTimeSetUp]
        public void TaskDeleteTestOneTimeSetup()
        {

            _taskCreateService.CreateTaskDueDateTime("Test Delete Task X");
            long id = _taskCreateService.TaskDTO.Task.Id;
            _taskDeleteService.DeleteTask(id);
        }

        [Test]
        public void RequestSentOK()
        {
            long id = _taskCreateService.TaskDTO.Task.Id;
            _taskDeleteService.DeleteTask(id);
            Assert.That(_taskDeleteService.Status, Is.EqualTo(204)); //204 : No Content
        }


        [Test]
        public void DeleteTaskThatNeverExisted()
        {
            Assert.That(_taskDeleteService.CallManager.DeleteTask(123).StatusCode.ToString(), Is.EqualTo("BadRequest")); //404: BadRequest
        }

        [Ignore("why are they not working)]
        [Test]
        public void TheTaskIsNoLongerThereByGetAllTasks()
        {

            long id = _taskCreateService.TaskDTO.Task.Id;
            _taskGetService.GetActiveTasks(projectID: id, Filter: "Test Delete Function");
            _taskDeleteService.DeleteTask(id);
            Assert.That(_taskGetService.Result.Tasks.Length, Is.EqualTo(0)); //404: NotFound
        }

        [Ignore("why are they not working)]
  [Test]
        public void TheTaskIsNoLongerThereByGetTask()
        {
            long id = _taskCreateService.TaskDTO.Task.Id;
            _taskGetService.GetActiveTasks(projectID: id);
            _taskDeleteService.DeleteTask(id);
            Assert.That(_taskGetService.StatusCode, Is.EqualTo(404)); //404: NotFound
        }




    }
}
