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
			Assert.That(_projectGetService.Status, Is.EqualTo(200));
		}

		[Test]
		public void GetByIDReturnsOk()
		{
			_projectGetService.GetProjectByID(2257376455);
			Assert.That(_projectGetService.Status, Is.EqualTo(200));
		}
	}
}
