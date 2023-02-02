using HouseRentingSystem.Services.Statistics;
using HouseRentingSystem.Services.Statistics.Models;
using Moq;

namespace HouseRentingSystem.Tests.Mocks
{
	public class StatisticsServiceMock
	{
		public static IStatisticsService Instance
		{
			get
			{
				var service = new Mock<IStatisticsService>();
				
				service.Setup(m => m.Total())
				.Returns(new StatisticsServiceModel
				{
					TotalHouses = 10,
					TotalRents = 6
				});

				return service.Object;
			}
		}
	}
}
