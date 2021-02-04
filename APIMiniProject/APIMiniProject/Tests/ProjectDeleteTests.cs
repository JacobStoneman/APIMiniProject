using NUnit.Framework;
using RestSharp;

namespace APIMiniProject
{
    public class ProjectDeleteTests
    {
        ProjectDeleteService _projectDeleteService = new ProjectDeleteService();
        ProjectGetService _projectGetService = new ProjectGetService();
        ProjectCreateService _createService = new ProjectCreateService(new ProjectCreateCallManager(new RestClient(AppConfigReader.BaseUrl)));

        [OneTimeSetUp]
        public void ProjectDeleteTestOneTimeSetup()
        {      
            _createService.CreateProject("Test Delete Function");
            long id = _createService.ProjectDTO.Project.Id;

            _projectDeleteService.DeleteProject(id);
        }

        [Test]
        public void TheProjectIsNoLongerThereByGetAllProjects()
        {
            _projectGetService.GetAllByName("Test Delete Function");
            Assert.That(_projectGetService.Result.ProjectList.Length, Is.EqualTo(0)); //404: NotFound
        }

        [Test]
        public void RequestSentOK()
        {
            Assert.That(_projectDeleteService.Status, Is.EqualTo(204)); //204 : No Content
        }

        [Test]
        public void TheProjectIsNoLongerThereByGetProject()
        {
            Assert.That(_projectGetService.GetProjectByID(2257480369).Status, Is.EqualTo(404)); //404: NotFound

        }

        [Test]
        public void DeleteTaskThatNeverExisted()
        { 
           Assert.That(_projectDeleteService.CallManager.DeleteProject(123).StatusCode.ToString(), Is.EqualTo("BadRequest")); //404: BadRequest
        }

    }
}
