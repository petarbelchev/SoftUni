using HouseRentingSystem.Tests.Mocks;
using HouseRentingSystem.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Tests.IntegrationTests
{
	public class HomeControllerTests
	{
		private HomeController homeController;

		[OneTimeSetUp]
		public void SetUp()
		{
			homeController = new HomeController(HouseServiceMock.Instance);
		}

		[Test]
		public void Error_ShouldReturnCorrectView()
		{
			//Arrange
			int statusCode = 500;

			//Act
			var result = homeController.Error(statusCode);

			//Assert the returned result is not null
			Assert.That(result, Is.Not.Null);

			//Assert the returned result is a view
			var viewResult = result as ViewResult;
			Assert.That(viewResult, Is.Not.Null);
		}
	}
}
