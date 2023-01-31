using HouseRentingSystem.Services.Houses.Models;

namespace HouseRentingSystem.Services.Houses
{
    public interface IHouseService
    {
        HouseQueryServiceModel All(string? categoryName = null,
                                    string? searchTerm = null,
                                    HouseSorting sortingValue = HouseSorting.Newest,
                                    int currentPage = 1,
                                    int housesPerPage = 1);

        IEnumerable<HouseCategoryServiceModel> AllCategories();

        IEnumerable<string> AllCategoriesNames();

        IEnumerable<HouseServiceModel> AllHousesByAgentId(int agentId);

        IEnumerable<HouseServiceModel> AllHousesByUserId(string userId);

        bool CategoryExists(int categoryId);

        int Create(string title, string address, string description,
                    string imageUrl, decimal price, int categoryId, int agentId);

        void Delete(int houseId);

        void Edit(int houseId, string title, string address, string description,
                    string imageUrl, decimal price, int categoryId);

        bool Exists(int id);

        int GetHouseCategoryId(int houseId);

        bool HasAgentWithId(int houseId, string userId);

        HouseDetailsServiceModel HouseDetailsById(int id);

        bool IsRented(int houseId);

        bool IsRentedByUserWithId(int houseId, string userId);

        IEnumerable<HouseIndexServiceModel> LastThreeHouses();

        void Leave(int houseId);

        void Rent(int houseId, string userId);
    }
}
