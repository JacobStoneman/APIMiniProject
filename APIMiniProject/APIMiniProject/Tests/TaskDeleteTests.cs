using NUnit.Framework;
using RestSharp;

namespace APIMiniProject
{
    public class TaskDeleteTests
    {
        TaskDeleteService _taskDeleteService = new TaskDeleteService();

        [Test]
        public void RequestSentOK()
        {
            _taskDeleteService.DeleteProject(4552300072);
            Assert.That(_taskDeleteService.Status, Is.EqualTo(204)); //204 : No Content
        }


        [Test]
        public void DeleteTaskThatNeverExisted()
        {
            Assert.That(_taskDeleteService.CallManager.DeleteTask(123).StatusCode.ToString(), Is.EqualTo("BadRequest")); //404: BadRequest
        }

    }
}
