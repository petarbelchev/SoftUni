using AutoMapper;
using HouseRentingSystem.Services.Infrastructure;

namespace HouseRentingSystem.Tests.Mocks
{
	public static class MapperMock
	{
		public static IMapper Instance
		{
			get
			{
				var config = new MapperConfiguration(cfg =>
					cfg.AddProfile<ServiceMappingProfile>());

				return new Mapper(config);
			}
		}
	}
}
