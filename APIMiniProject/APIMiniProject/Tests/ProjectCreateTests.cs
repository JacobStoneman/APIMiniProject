using NUnit.Framework;
using RestSharp;

namespace APIMiniProject
{
    public class ProjectCreateTests
    {
        [Test]
        public void CreateCallSuccessfullyCreates()
        {
            ProjectCreateService createService = new ProjectCreateService(new ProjectCreateCallManager(new RestClient(AppConfigReader.BaseUrl)));
            createService.CreateProjectWithName("Testing");
            Assert.That(createService.ResponseAsString, Is.True);
        }
    }
}
