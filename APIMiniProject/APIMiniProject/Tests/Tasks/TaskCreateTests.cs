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
        private readonly string _defaultName = "TaskTest";
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
        public void WhenCreateTaskDueDateTimeIsCalledCorrectly_StatusIsOk()
        {
            _createService.CreateTaskDueDateTime(_defaultName);
            _createdTaskId = _createService.TaskDTO.Task.Id;
            Assert.That(_createService.StatusMessage, Is.EqualTo("OK"));
        }

        [Test]
        public void WhenCreateTaskDueStringIsCalledCorrectly_StatusIsOk()
        {
            _createService.CreateTaskDueString(_defaultName);
            _createdTaskId = _createService.TaskDTO.Task.Id;
            Assert.That(_createService.StatusMessage, Is.EqualTo("OK"));
        }

        [Test]
        public void WhenCreateTaskDueDateStringIsCalledCorrectly_StatusIsOk()
        {
            _createService.CreateTaskDueDateString(_defaultName);
            _createdTaskId = _createService.TaskDTO.Task.Id;
            Assert.That(_createService.StatusMessage, Is.EqualTo("OK"));
        }

        [Test]
        public void WhenCreateTaskIsCalledWithNoName_StatusIsBadRequest()
        {
            _createService.CreateTaskDueDateString(_defaultName);
            _createdTaskId = _createService.TaskDTO.Task.Id;
            Assert.That(_createService.StatusMessage, Is.EqualTo("BadRequest"));
        }

        [OneTimeTearDown]
        public void TearDownMethod()
        {
            if (_createdTaskId != 1)
            {
                RestRequest request = new RestRequest($"tasks/{_createdTaskId}", Method.DELETE);
                request.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");
                var restClient = new RestClient(AppConfigReader.BaseUrl);
                restClient.Execute(request);
            }
            if (_createdProjectId != -1)
            {
                RestRequest request = new RestRequest($"projects/{_createdProjectId}", Method.DELETE);
                request.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");
                var restClient = new RestClient(AppConfigReader.BaseUrl);
                restClient.Execute(request);
            }
        }
    }
}
