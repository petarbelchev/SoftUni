using HouseRentingSystem.Data;
using HouseRentingSystem.Services.Models;

namespace HouseRentingSystem.Services.Houses
{
	public class HouseService : IHouseService
	{
		private readonly HouseRentingDbContext data;

		public HouseService(HouseRentingDbContext context)
			=> data = context;

		public IEnumerable<HouseIndexServiceModel> LastThreeHouses()
		{
			return data.Houses
				.OrderByDescending(h => h.Id)
				.Take(3)
				.Select(h => new HouseIndexServiceModel
				{
					Id = h.Id,
					Title= h.Title,
					ImageUrl = h.ImageUrl
				});
		}
	}
}
