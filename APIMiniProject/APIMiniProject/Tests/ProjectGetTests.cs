using NUnit.Framework;

namespace APIMiniProject
{
	public class ProjectGetTests
	{
		ProjectGetService _projectGetService = new ProjectGetService();

		[Test]
		public void GetAllReturnsOK()
		{
			_projectGetService.GetAllProjects();
			Assert.That(_projectGetService.StatusCode, Is.EqualTo(200));
		}

		[Test]
		public void GetAllReturnsProjects()
		{
			_projectGetService.GetAllProjects();
			Assert.That(_projectGetService.Result.ProjectList[0].Name, Is.EqualTo("Inbox"));
		}

		[Test]
		public void GetByIDReturnsOk()
		{
			_projectGetService.GetProjectByID(2257376455);
			Assert.That(_projectGetService.StatusCode, Is.EqualTo(200));
		}

		[Test]
		public void GetByIDReturnsInbox()
		{
			_projectGetService.GetProjectByID(2257376455);
			Assert.That(_projectGetService.Result.ProjectList[0].Name, Is.EqualTo("Inbox"));
		}

		[Test]
		public void GetByInvalidIDReturns404()
		{
			_projectGetService.GetProjectByID(-1);
			Assert.That(_projectGetService.StatusCode, Is.EqualTo(404));
		}

		[Test]
		public void GetAllByColourID48ReturnsInbox()
		{
			_projectGetService.GetAllByColour(48);
			Assert.That(_projectGetService.Result.ProjectList[0].Name, Is.EqualTo("Inbox"));
		}

		[Test]
		public void GetAllByInvalidColourReturnsNoProjects()
		{
			_projectGetService.GetAllByColour(-1);
			Assert.That(_projectGetService.Result.ProjectList.Length, Is.EqualTo(0));
		}

		[Test]
		public void GetAllByNameInboxReturnsInbox()
		{
			_projectGetService.GetAllByName("Inbox");
			Assert.That(_projectGetService.Result.ProjectList[0].Name, Is.EqualTo("Inbox"));
		}

		[Test]
		public void GetAllByInvalidNameReturnsNoProjects()
		{
			_projectGetService.GetAllByName(string.Empty);
			Assert.That(_projectGetService.Result.ProjectList.Length, Is.EqualTo(0));
		}

		[Test]
		public void GetAllByNameNotCaseSensitive()
		{
			_projectGetService.GetAllByName("inBoX");
			Assert.That(_projectGetService.Result.ProjectList[0].Name, Is.EqualTo("Inbox"));
		}

		[Test]
		public void GetAllByNameIncludesInbReturnsInbox()
		{
			_projectGetService.GetAllByNameIncludes("Inb");
			Assert.That(_projectGetService.Result.ProjectList[0].Name, Is.EqualTo("Inbox"));
		}

		[Test]
		public void GetAllByNameIncludesNotCaseSensitive()
		{
			_projectGetService.GetAllByNameIncludes("iNb");
			Assert.That(_projectGetService.Result.ProjectList[0].Name, Is.EqualTo("Inbox"));
		}

		[Test]
		public void GetAllByNameIncludesEmpty()
		{
			_projectGetService.GetAllByNameIncludes(string.Empty);
			Assert.That(_projectGetService.Result.ProjectList[0].Name, Is.EqualTo("Inbox"));
		}
	}
}
