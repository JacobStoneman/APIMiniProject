using NUnit.Framework;
using RestSharp;

namespace APIMiniProject
{
    public class ProjectDeleteTests
    {
            ProjectDeleteService _projectDeleteService = new ProjectDeleteService();
            ProjectGetService _projectGetService = new ProjectGetService();

        [OneTimeSetUp]
        public void ProjectDeleteTestOneTimeSetup()
        {
            // create a test 
            ProjectCreateService _createService = new ProjectCreateService(new ProjectCreateCallManager(new RestClient(AppConfigReader.BaseUrl)));
            _createService.CreateProjectWithName("Test Delete Function");
            if (_projectGetService.CallManager.GetProjectByID()

        }

        [Test]
        public void GetProjectByNameIsNotThere()
        {
            _projectGetService.GetAllByName("Test Delete Function");
            Assert.That(_projectGetService.Result.ProjectList[].
                
                Is.EqualTo("Inbox"));
        }


        [Test]
        public void RequestSentOK()
        {
            Assert.That(_projectDeleteService.Status, Is.EqualTo(204)); //204 : No Content
        }

        [Test]
        public void TheTaskIsNoLongerThere()
        {
            Assert.That(_projectGetService.GetProjectByID(2257480369).Status, Is.EqualTo(404)); //404: NotFound

        }

        [Test]
        public void DeleteTaskThatNeverExisted()
        { 
           Assert.That(_projectDeleteService.CallManager.DeleteProject(123).StatusCode.ToString(), Is.EqualTo("400")); //404: BadRequest
        }

    }
}
