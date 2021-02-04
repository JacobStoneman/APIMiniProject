using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMiniProject
{
    public class TaskCreateTests
    {
        private TaskCreateService _createService = new TaskCreateService(new TaskCreateCallManager(new RestClient(AppConfigReader.BaseUrl)));
        private long _createdProjectId = -1;
        private long _createdTaskId = -1;

        [OneTimeSetUp]
        public void SetupMethod()
        {
            RestRequest request = new RestRequest("projects", Method.POST);
            request.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");
            request.AddParameter("name", "CreateTesting");
            var restClient = new RestClient(AppConfigReader.BaseUrl);

            var responseContent = restClient.Execute(request).Content;
            JObject jsonResponse = JObject.Parse(responseContent);
            _createdProjectId = long.Parse(jsonResponse["id"].ToString());
        }

        [Test]
        public void WhenCreateIsCalledCorrectly_StatusIsOk()
        {
            _createService.CreateTaskDueDateTime("Test");
            _createdTaskId = _createService.TaskDTO.Task.Id;
            Assert.That(_createService.StatusMessage, Is.EqualTo("OK"));
        }

        [OneTimeTearDown]
        public void TearDownMethod()
        {
            if (_createdProjectId != -1)
            {
                // build a request and then delete
                RestRequest request = new RestRequest($"projects/{_createdProjectId}", Method.DELETE);
                request.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");
                var restClient = new RestClient(AppConfigReader.BaseUrl);
                restClient.Execute(request);
            }
        }
    }
}
