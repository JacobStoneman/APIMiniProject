using NUnit.Framework;
using RestSharp;

namespace APIMiniProject
{
    public class ProjectEditTests
    {
        ProjectCreateService _createService = new ProjectCreateService(new ProjectCreateCallManager(new RestClient(AppConfigReader.BaseUrl)));

        [Test]
        public void PostCallSuccessfullyEditsName()
        {
            
        }
    }
}
