using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseRentingSystem.Services.Data;
using HouseRentingSystem.Services.Rents.Models;

namespace HouseRentingSystem.Services.Rents
{
	public class RentService : IRentService
	{
		private readonly HouseRentingDbContext data;
		private readonly IMapper mapper;

		public RentService(
			HouseRentingDbContext data, 
			IMapper mapper)
		{
			this.data = data;
			this.mapper = mapper;
		}

		public IEnumerable<RentServiceModel> All()
		{
			return data.Houses
				.Where(h => h.RenterId != null)
				.ProjectTo<RentServiceModel>(mapper.ConfigurationProvider)
				.ToList();
		}
	}
}
