using NUnit.Framework;
using RestSharp;

namespace APIMiniProject
{
    public class ProjectCreateTests
    {
        private readonly string defaultName = "CreateTest";
        private ProjectCreateService _createService = new ProjectCreateService(new ProjectCreateCallManager(new RestClient(AppConfigReader.BaseUrl)));
        private long _createdId = -1;

        [TearDown]
        public void RemoveCreatedTearDown()
        {
            if (_createdId != -1)
            {
                // build a request and then delete
                RestRequest request = new RestRequest($"projects/{_createdId}", Method.DELETE);
                request.AddHeader("Authorization", $"Bearer {AppConfigReader.BearerToken}");
                var restClient = new RestClient(AppConfigReader.BaseUrl);
                restClient.Execute(request);
            }
        }

        [Test]
        public void WhenCreateIsCalledCorrectly_StatusIsOk()
        {
            _createService.CreateProject(defaultName);
            _createdId = _createService.ProjectDTO.Project.Id;
            Assert.That(_createService.Status, Is.EqualTo("OK"));
        }

        [Test]
        public void WhenCreateIsCalle_WithNoName_StatusIsBadRequest()
        {
            _createService.CreateProject("");
            Assert.That(_createService.Status, Is.EqualTo("BadRequest"));
        }

        [Test]
        public void WhenCreateIsCalled_WithNameAndInvalidColour_BadRequestReturned()
        {
            _createService.CreateProject(defaultName, colour : 10000);
            Assert.That(_createService.Status, Is.EqualTo("BadRequest"));
        }

        [Test]
        public void WhenCreateIsCalled_WithNameAndInvalidParentId_BadRequestReturned()
        {
            _createService.CreateProject(defaultName, parentId: 1);
            Assert.That(_createService.Status, Is.EqualTo("BadRequest"));
        }

        [Test]
        public void WhenCreateIsCalled_WithName_ObjectIsStoredWithAllParameters()
        {
            _createService.CreateProject(defaultName);
            _createdId = _createService.ProjectDTO.Project.Id;
            var responseDTO = _createService.ProjectDTO.Project;
            Assert.That(responseDTO.Name, Is.EqualTo(defaultName));
            Assert.That(responseDTO.Color, Is.Not.Null);
            Assert.That(responseDTO.Favorite, Is.Not.Null);
        }

        [Test]
        public void WhenCreateIsCalled_WithNameAndParentID_ObjectIsStoredWithAllParameters()
        {
            const long inboxId = 2257376455;

            _createService.CreateProject(defaultName, inboxId);
            _createdId = _createService.ProjectDTO.Project.Id;
            var responseDTO = _createService.ProjectDTO.Project;
            Assert.That(responseDTO.Name, Is.EqualTo(defaultName));
            Assert.That(responseDTO.Parent_id, Is.EqualTo(inboxId));
            Assert.That(responseDTO.Favorite, Is.Not.Null);
        }

        [Test]
        public void WhenCreateIsCalled_WithNameAndColour_ObjectIsStoredWithAllParameters()
        {
            _createService.CreateProject(defaultName, colour: 30);
            _createdId = _createService.ProjectDTO.Project.Id;
            var responseDTO = _createService.ProjectDTO.Project;
            Assert.That(responseDTO.Name, Is.EqualTo(defaultName));
            Assert.That(responseDTO.Color, Is.EqualTo(30));
            Assert.That(responseDTO.Favorite, Is.Not.Null);
        }

        [Test]
        public void WhenCreateIsCalled_WithNameAndFavourite_ObjectIsStoredWithAllParameters()
        {
            _createService.CreateProject(defaultName, favourite: true);
            _createdId = _createService.ProjectDTO.Project.Id;
            var responseDTO = _createService.ProjectDTO.Project;
            Assert.That(responseDTO.Name, Is.EqualTo(defaultName));
            Assert.That(responseDTO.Favorite, Is.True);
        }

        [Test]
        public void WhenCreateIsCalled_WithAllParameters_ObjectIsStoredWithAllParameters()
        {
            const long inboxId = 2257376455;

            _createService.CreateProject(defaultName, inboxId, 30, true);
            _createdId = _createService.ProjectDTO.Project.Id;
            var responseDTO = _createService.ProjectDTO.Project;
            Assert.That(responseDTO.Name, Is.EqualTo(defaultName));
            Assert.That(responseDTO.Color, Is.EqualTo(30));
            Assert.That(responseDTO.Parent_id, Is.EqualTo(inboxId));
            Assert.That(responseDTO.Favorite, Is.True);
        }
    }
}
