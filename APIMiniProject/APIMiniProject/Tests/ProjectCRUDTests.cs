using NUnit.Framework;

namespace APIMiniProject
{
	public class ProjectCRUDTests
	{
		ProjectGetService _projectGetService = new ProjectGetService();

		[OneTimeSetUp]
		public void Setup()
		{
			_projectGetService.GetAllProjects();
		}

		[Test]
		public void RequestSentOK()
		{
			Assert.That(_projectGetService.Result.ProjectList.Length, Is.GreaterThan(0));
		}
	}
}
