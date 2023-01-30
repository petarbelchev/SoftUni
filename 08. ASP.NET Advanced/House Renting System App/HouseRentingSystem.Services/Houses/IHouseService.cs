using HouseRentingSystem.Services.Houses.Models;
using HouseRentingSystem.Services.Models;

namespace HouseRentingSystem.Services.Houses
{
	public interface IHouseService
	{
		IEnumerable<HouseIndexServiceModel> LastThreeHouses();

		IEnumerable<HouseCategoryServiceModel> AllCategories();

		HouseQueryServiceModel All(string? categoryName = null,
									string? searchTerm = null,
									HouseSorting sortingValue = HouseSorting.Newest,
									int currentPage = 1,
									int housesPerPage = 1);

		IEnumerable<string> AllCategoriesNames();

		bool CategoryExists(int categoryId);

		bool Exists(int id);

		bool HasAgentWithId(int houseId, string userId);

		int GetHouseCategoryId(int houseId);

		int Create(string title, string address, string description,
					string imageUrl, decimal price, int categoryId, int agentId);

		void Edit(int houseId, string title, string address, string description,
					string imageUrl, decimal price, int categoryId);

		IEnumerable<HouseServiceModel> AllHousesByAgentId(int agentId);

		IEnumerable<HouseServiceModel> AllHousesByUserId(string userId);

		HouseDetailsServiceModel HouseDetailsById(int id);

		void Delete(int houseId);

		bool IsRented(int houseId);

		bool IsRentedByUserWithId(int houseId, string userId);

		void Rent(int houseId, string userId);

		void Leave(int houseId);
	}
}
