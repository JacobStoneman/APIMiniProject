using NUnit.Framework;
using RestSharp;

namespace APIMiniProject
{
    public class ProjectCreateTests
    {
        ProjectCreateService _createService = new ProjectCreateService(new ProjectCreateCallManager(new RestClient(AppConfigReader.BaseUrl)));

        [Test]
        public void CreateCallSuccessfullyCreates_WithName()
        {
            _createService.CreateProjectWithName("Test");
            Assert.That(_createService.Status, Is.EqualTo("OK"));
        }
    }
}
