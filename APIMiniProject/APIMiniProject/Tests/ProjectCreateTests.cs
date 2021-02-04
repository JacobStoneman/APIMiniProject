using NUnit.Framework;
using RestSharp;

namespace APIMiniProject
{
    public class ProjectCreateTests
    {
        private ProjectCreateService _createService = new ProjectCreateService(new ProjectCreateCallManager(new RestClient(AppConfigReader.BaseUrl)));
        private long _createdId = -1;

        [Test]
        public void CreateCallSuccessfullyCreates_WithName()
        {
            _createService.CreateProject("CreateTest");
            _createdId = _createService.ProjectDTO.Project.Id;
            Assert.That(_createService.Status, Is.EqualTo("OK"));
        }
    
        [TearDown]
        public void RemoveCreatedTearDown()
        {
            if(_createdId != -1)
            {
                // build a request and then delete

            }
        }

    }
}
