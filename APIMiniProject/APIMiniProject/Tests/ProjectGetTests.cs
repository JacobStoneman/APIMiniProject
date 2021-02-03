﻿using NUnit.Framework;

namespace APIMiniProject
{
	public class ProjectGetTests
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
			Assert.That(_projectGetService.Status, Is.EqualTo(200));
		}
	}
}
