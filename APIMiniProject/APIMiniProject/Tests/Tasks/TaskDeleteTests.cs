using NUnit.Framework;
using RestSharp;

namespace APIMiniProject
{
    public class TaskDeleteTests
    {
        TaskDeleteService _taskDeleteService = new TaskDeleteService();
        TaskGetService _taskGetService = new TaskGetService();
      //  TaskCreateService _taskCreateService = new TaskCreateService();
        
        [OneTimeSetUp]
        public void TaskDeleteTestOneTimeSetup()
        {

            // create task
            //find task id 
            // delete task

            //_taskCreateService.CreateTask("Test Delete Task");
            //long id = _taskCreateService.ProjectDTO.Project.Id;

        //    _taskDeleteService.DeleteTask(id);
        }

        [Test]
        public void RequestSentOK()
        {
            _taskDeleteService.DeleteTask(4552300072);
            Assert.That(_taskDeleteService.Status, Is.EqualTo(204)); //204 : No Content
        }


        [Test]
        public void DeleteTaskThatNeverExisted()
        {
            Assert.That(_taskDeleteService.CallManager.DeleteTask(123).StatusCode.ToString(), Is.EqualTo("BadRequest")); //404 : BadRequest
        }

        [Ignore("waiting for get methods")]
        [Test]
        public void TheTaskIsNoLongerThereByGetAllTasks()
        {
            // get all by ??
            _taskGetService.GetActiveTasks.
            Assert.That(_taskGetService.Result.Tasks.Length, Is.EqualTo(0)); //404: NotFound
        }

        [Ignore("waiting for get methods")]
        [Test]
        public void TheTaskIsNoLongerThereByGetTask()
        {
            //test to check when you search id it doesnt show up

            //long id = _taskcreateService.tasktDTO.Task.Id;
            //_taskprojectGetService.GetProjectByID(id);
            Assert.That(_taskGetService.StatusCode, Is.EqualTo(404)); //404: NotFound
        }

    }
}
