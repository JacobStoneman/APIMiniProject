using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
        public void WhenCreateTaskIsCalled_WithNoName_StatusIsBadRequest()
        {
            _createService.CreateTaskDueDateString("");
            Assert.That(_createService.StatusMessage, Is.EqualTo("BadRequest"));
        }

        [Test]
        public void WhenCreateTaskIsCalled_WithNoProjectId_ProjectIsInboxDefault()
        {
            const long inboxId = 2257376455;

            _createService.CreateTaskDueDateString(_defaultName);
            _createdTaskId = _createService.TaskDTO.Task.Id;
            Assert.That(_createService.TaskDTO.Task.Project_id, Is.EqualTo(inboxId));
        }

        [Test]
        public void WhenCreateTaskIsCalled_WithInvalidProjectId_BadRequestReturned()
        {
            const int invalidProjectId = -1;

            _createService.CreateTaskDueDateString(_defaultName, projectId: invalidProjectId);
            Assert.That(_createService.StatusMessage, Is.EqualTo("BadRequest"));
        }

        [Test]
        public void WhenCreateTaskIsCalled_WithProjectId_ProjectIsCorrect()
        {
            _createService.CreateTaskDueDateString(_defaultName, projectId : _createdProjectId);
            _createdTaskId = _createService.TaskDTO.Task.Id;
            Assert.That(_createService.TaskDTO.Task.Project_id, Is.EqualTo(_createdProjectId));
        }

        [Test]
        public void WhenCreateTaskIsCalled_WithNoSectionID_SectionIDIsZero()
        {
            _createService.CreateTaskDueDateString(_defaultName);
            _createdTaskId = _createService.TaskDTO.Task.Id;
            Assert.That(_createService.TaskDTO.Task.Section_id, Is.Zero);
        }

        [Test]
        public void WhenCreateTaskIsCalled_WithInvalidSectionID_BadRequestReturned()
        {
            const int invalidSectionId = -1;

            _createService.CreateTaskDueDateString(_defaultName, sectionId: invalidSectionId);
            Assert.That(_createService.StatusMessage, Is.EqualTo("BadRequest"));
        }

        [Test]
        public void WhenCreateTaskIsCalled_WithASectionID_SectionIDCorrect()
        {
            // Create a section - section is automatically removed with project
            RestRequest request = new RestRequest($"sections?project_id={_createdProjectId}", Method.POST);
            request.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");
            request.AddParameter("name", "TestSection");
            var restClient = new RestClient(AppConfigReader.BaseUrl);

            var responseContent = restClient.Execute(request).Content;
            JObject jsonResponse = JObject.Parse(responseContent);
            var created_sectionId = long.Parse(jsonResponse["id"].ToString());

            _createService.CreateTaskDueDateString(_defaultName, sectionId : created_sectionId);
            _createdTaskId = _createService.TaskDTO.Task.Id;
            Assert.That(_createService.TaskDTO.Task.Section_id, Is.EqualTo(created_sectionId));
        }

        [Test]
        public void WhenCreateTaskIsCalled_WithNoParentID_ParentIDIsZero()
        {
            _createService.CreateTaskDueDateString(_defaultName);
            _createdTaskId = _createService.TaskDTO.Task.Id;
            Assert.That(_createService.TaskDTO.Task.Parent_id, Is.Zero);
        }

        [Test]
        public void WhenCreateTaskIsCalled_WithAParentID_ParentIDIsCorrect()
        {
            RestRequest request = new RestRequest("tasks", Method.POST);
            request.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new JObject(new JProperty("content", "ParentTask"), new JProperty("project_id", _createdProjectId)).ToString());
            var restClient = new RestClient(AppConfigReader.BaseUrl);

            var response = restClient.Execute(request);
            var responseContent = response.Content;
            JObject jsonResponse = JObject.Parse(responseContent);
            var parentTaskId = long.Parse(jsonResponse["id"].ToString());

            _createService.CreateTaskDueDateString(_defaultName, parentId : parentTaskId);
            _createdTaskId = _createService.TaskDTO.Task.Id;
            Assert.That(_createService.TaskDTO.Task.Parent_id, Is.EqualTo(parentTaskId));
        }

        [Test]
        public void WhenCreateTaskIsCalled_WithValidPriorityID_TaskPriorityIsCorrect()
        {
            const int priorityLevel = 4;

            _createService.CreateTaskDueDateString(_defaultName, priority : priorityLevel);
            _createdTaskId = _createService.TaskDTO.Task.Id;
            Assert.That(_createService.TaskDTO.Task.Priority, Is.EqualTo(priorityLevel));
        }

        [Test]
        public void WhenCreateTaskIsCalled_WithInvalidPriorityID_BadRequestReturned()
        {
            const int invalidPriorityLevel = 5;

            _createService.CreateTaskDueDateString(_defaultName, priority : invalidPriorityLevel);
            Assert.That(_createService.StatusMessage, Is.EqualTo("BadRequest"));
        }

        [Test]
        public void WhenCreateTaskIsCalled_WithValidDueString_DueDateIsCorrect()
        {
            _createService.CreateTaskDueString(_defaultName, dueString : "Tomorrow");
            _createdTaskId = _createService.TaskDTO.Task.Id;
            Assert.That(_createService.TaskDTO.Task.Due.Date, Is.EqualTo(DateTime.Today.AddDays(1).Date.ToString("yyyy-MM-dd")));
        }

        [Test]
        public void WhenCreateTaskIsCalled_WithInvalidDueString_BadRequestReturned()
        {
            _createService.CreateTaskDueString(_defaultName, dueString: "abc");
            Assert.That(_createService.StatusMessage, Is.EqualTo("BadRequest"));
        }

        [Test]
        public void WhenCreateTaskIsCalled_WithValidDueDateString_DueDateIsCorrect()
        {
            const string specifiedDate = "2020-12-25";

            _createService.CreateTaskDueDateString(_defaultName, dueDate: specifiedDate);
            _createdTaskId = _createService.TaskDTO.Task.Id;
            Assert.That(_createService.TaskDTO.Task.Due.Date, Is.EqualTo(specifiedDate));
        }

        [Test]
        public void WhenCreateTaskIsCalled_WithInvalidDueDateString_BadRequestReturned()
        {
            _createService.CreateTaskDueDateString(_defaultName, dueDate: "abc");
            Assert.That(_createService.StatusMessage, Is.EqualTo("BadRequest"));
        }

        [Test]
        public void WhenCreateTaskIsCalled_WithValidDueDateTime_DueDateIsCorrect()
        {
            // Convert to RFC3339 format in UTC using XmlConvert
            var RFCDateTime = XmlConvert.ToString(DateTime.UtcNow, XmlDateTimeSerializationMode.Utc);
            _createService.CreateTaskDueDateTime(_defaultName, dueDateTime: RFCDateTime);
            _createdTaskId = _createService.TaskDTO.Task.Id;
            Assert.That(_createService.TaskDTO.Task.Due.Date, Is.EqualTo(DateTime.UtcNow.Date.ToString("yyyy-MM-dd")));
        }

        [Test]
        public void WhenCreateTaskIsCalled_WithinValidDueDateTime_BadRequestReturned()
        {
            _createService.CreateTaskDueDateTime(_defaultName, dueDateTime: "abc");
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
