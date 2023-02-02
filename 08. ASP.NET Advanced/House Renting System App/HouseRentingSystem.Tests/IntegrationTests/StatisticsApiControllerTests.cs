using HouseRentingSystem.Tests.Mocks;
using HouseRentingSystem.Web.Controllers.Api;

namespace HouseRentingSystem.Tests.IntegrationTests
{
	[TestFixture]
	public class StatisticsApiControllerTests
	{
		private StatisticsApiController statisticsController;

		[OneTimeSetUp]
		public void SetUp()
		{
			statisticsController = new StatisticsApiController(StatisticsServiceMock.Instance);
		}

		[Test]
		public void Get_ShouldReturnCorrectData()
		{
			//Arrange

			//Act: invoke the service method
			var result = statisticsController.Get();

			//Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.TotalHouses, Is.EqualTo(10));
			Assert.That(result.TotalRents, Is.EqualTo(6));
		}
	}
}
