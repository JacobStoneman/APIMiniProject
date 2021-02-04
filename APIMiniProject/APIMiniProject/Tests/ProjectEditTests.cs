using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace APIMiniProject
{
    public class ProjectEditTests
    {
        IRestClient _client;
        ProjectEditService _editService;
        string createdProjectId;

        [OneTimeSetUp]
        public void SetupMethod()
        {
            _client = new RestClient(AppConfigReader.BaseUrl);
            _editService = new ProjectEditService(new ProjectEditCallManager(_client));
            RestRequest createRequest = new RestRequest("projects", Method.POST);
            createRequest.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");
            createRequest.AddParameter("name", "TestName");
            string createResponse = _client.Execute(createRequest).Content;
            JObject jsonResponse = JObject.Parse(createResponse);
            createdProjectId = jsonResponse["id"].ToString();

            

        }


        [Test]
        public void PostCallReturnsSuccesful()
        {
            _editService.EditProject(long.Parse(createdProjectId), "NewTestName");
            Assert.That(_editService.Status, Is.EqualTo(204));

        }

        [Test]
        public void PostCallSuccessfullyUpdatesName()
        {
            _editService.EditProject(long.Parse(createdProjectId), "NewTestName");
            RestRequest getRequest = new RestRequest(Method.GET);
            getRequest.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");
            getRequest.Resource = $"projects/{createdProjectId}";
            string getResponse = _client.Execute(getRequest).Content;
            JObject jsonResponse = JObject.Parse(getResponse);
            string updatedName = jsonResponse["name"].ToString();

            Assert.That(updatedName, Is.EqualTo("NewTestName"));

        }



        [OneTimeTearDown]
        public void TearDownMethod()
        {
            _client = new RestClient(AppConfigReader.BaseUrl);
            _editService = new ProjectEditService(new ProjectEditCallManager(_client));
            RestRequest deleteRequest = new RestRequest("projects", Method.DELETE);
            deleteRequest.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");
            deleteRequest.Resource = $"projects/{createdProjectId}";
            _client.Execute(deleteRequest);
        }
    }
}
