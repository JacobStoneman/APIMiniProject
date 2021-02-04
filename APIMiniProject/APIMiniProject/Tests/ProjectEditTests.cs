using NUnit.Framework;
using RestSharp;

namespace APIMiniProject
{
    public class ProjectEditTests
    {
        ProjectEditService _createService = new ProjectEditService(new ProjectEditCallManager(new RestClient(AppConfigReader.BaseUrl)));

        [Test]
        public void PostCallSuccessfullyEditsName()
        {
            
        }
    }
}
