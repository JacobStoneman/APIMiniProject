using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace APIMiniProject
{
	public class TaskEditTests
	{
		IRestClient _client;
		TaskEditService _editService;
		string createdTaskId;

		[OneTimeSetUp]
		public void SetupMethod()
		{
			_client = new RestClient(AppConfigReader.BaseUrl);
			_editService = new TaskEditService(new TaskEditCallManager(_client));
			RestRequest createRequest = new RestRequest("tasks",Method.POST);
			createRequest.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");
			JObject jsonbody = new JObject(new JProperty("content", "TestTask"), new JProperty("project_id", 2257376455));
			createRequest.AddJsonBody(jsonbody.ToString());
			string createResponse = _client.Execute(createRequest).Content;
			JObject jsonResponse = JObject.Parse(createResponse);
			createdTaskId = jsonResponse["id"].ToString();
		}

		[Test]
		public void PostCallReturnsSuccesfulWhenTaskIdExists()
		{
			_editService.EditTask(long.Parse(createdTaskId), "NewTestName");
			Assert.That(_editService.Status, Is.EqualTo(204));

		}

		[Test]
		public void PostCallReturnsNotFoundWhenTaskIdDoesNotExist()
		{
			_editService.EditTask(-1, "NewTestName");
			Assert.That(_editService.Status, Is.EqualTo(404));

		}

		[OneTimeTearDown]
		public void TearDownMethod()
		{
			_editService = new TaskEditService(new TaskEditCallManager(_client));
			RestRequest deleteRequest = new RestRequest(Method.DELETE);
			deleteRequest.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");
			deleteRequest.Resource = $"tasks/{createdTaskId}";
			_client.Execute(deleteRequest);
		}

		
	}
}
