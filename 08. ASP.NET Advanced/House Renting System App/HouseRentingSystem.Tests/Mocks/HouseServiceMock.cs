using HouseRentingSystem.Services.Houses;
using Moq;

namespace HouseRentingSystem.Tests.Mocks
{
	public static class HouseServiceMock
	{
		public static IHouseService Instance
		{
			get
			{
				var service = new Mock<IHouseService>();

				return service.Object;
			}
		}
	}
}
