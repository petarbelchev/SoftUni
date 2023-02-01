using HouseRentingSystem.Services.Statistics;
using HouseRentingSystem.Services.Statistics.Models;

namespace HouseRentingSystem.Tests.UnitTests
{
	[TestFixture]
	public class StatisticsServiceTests : UnitTestsBase
	{
		private IStatisticsService statisticsService;

		[OneTimeSetUp]
		public void SetUp()
		{
			statisticsService = new StatisticsService(data);
		}

		[Test]
		public void Total_ShouldReturnTotalHousesAndRents()
		{
			//Arrange
			var expectedResult = new StatisticsServiceModel
			{
				TotalHouses = data.Houses.Count(),
				TotalRents = data.Houses.Count(h => h.RenterId != null)
			};

			//Act
			var actualResult = statisticsService.Total();

			//Assert
			Assert.That(actualResult.TotalHouses, Is.EqualTo(expectedResult.TotalHouses));
			Assert.That(actualResult.TotalRents, Is.EqualTo(expectedResult.TotalRents));
		}
	}
}
