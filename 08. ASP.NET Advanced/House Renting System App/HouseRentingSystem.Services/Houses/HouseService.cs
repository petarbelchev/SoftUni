using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseRentingSystem.Services.Data;
using HouseRentingSystem.Services.Data.Entities;
using HouseRentingSystem.Services.Houses.Models;
using HouseRentingSystem.Services.Users;

namespace HouseRentingSystem.Services.Houses
{
    public class HouseService : IHouseService
    {
        private readonly HouseRentingDbContext data;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public HouseService(
            HouseRentingDbContext context,
            IUserService userService,
            IMapper mapper)
        {
            this.data = context;
            this.userService = userService;
            this.mapper = mapper;
        }

        public HouseQueryServiceModel All(string? categoryName = null, string? searchTerm = null,
                                            HouseSorting sorting = HouseSorting.Newest,
                                            int currentPage = 1, int housesPerPage = 1)
        {
            var housesQuery = data.Houses.AsQueryable();

            if (!string.IsNullOrWhiteSpace(categoryName))
            {
                housesQuery = housesQuery
                    .Where(h => h.Category.Name == categoryName);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                string searchTermToLower = searchTerm.ToLower();

                housesQuery = housesQuery.Where(h =>
                    h.Title.ToLower().Contains(searchTermToLower) ||
                    h.Address.ToLower().Contains(searchTermToLower) ||
                    h.Description.ToLower().Contains(searchTermToLower));
            }

            housesQuery = sorting switch
            {
                HouseSorting.Price => housesQuery
                    .OrderBy(h => h.PricePerMonth),
                HouseSorting.NotRentedFirst => housesQuery
                    .OrderBy(h => h.RenterId != null)
                    .ThenByDescending(h => h.Id),
                _ => housesQuery.OrderByDescending(h => h.Id)
            };

            int allHousesCount = housesQuery.Count();

            var houses = housesQuery
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .ProjectTo<HouseServiceModel>(mapper.ConfigurationProvider)
                .ToList();

            return new HouseQueryServiceModel
            {
                Houses = houses,
                TotalHousesCount = allHousesCount,
            };
        }

        public IEnumerable<HouseCategoryServiceModel> AllCategories()
        {
            return data.Categories
                .ProjectTo<HouseCategoryServiceModel>(mapper.ConfigurationProvider)
                .ToList();
        }

        public IEnumerable<string> AllCategoriesNames()
            => data.Categories
                .Select(c => c.Name)
                .Distinct()
                .ToList();

        public IEnumerable<HouseServiceModel> AllHousesByAgentId(int agentId)
        {
            var houses = data.Houses
                .Where(h => h.AgentId == agentId)
                .ProjectTo<HouseServiceModel>(mapper.ConfigurationProvider)
                .ToList();

            return houses;
        }

        public IEnumerable<HouseServiceModel> AllHousesByUserId(string userId)
        {
            var houses = data.Houses
                .Where(h => h.RenterId == userId)
                .ProjectTo<HouseServiceModel>(mapper.ConfigurationProvider)
                .ToList();

            return houses;
        }

        public bool CategoryExists(int categoryId)
            => data.Categories.Any(c => c.Id == categoryId);

        public int Create(string title, string address, string description,
            string imageUrl, decimal price, int categoryId, int agentId)
        {
            var newHouse = new House()
            {
                Title = title,
                Address = address,
                Description = description,
                ImageUrl = imageUrl,
                PricePerMonth = price,
                CategoryId = categoryId,
                AgentId = agentId
            };

            data.Houses.Add(newHouse);
            data.SaveChanges();

            return newHouse.Id;
        }

        public void Delete(int houseId)
        {
            var house = data.Houses.Find(houseId);

            if (house == null)
                throw new ArgumentNullException("House does not exist.");

            data.Houses.Remove(house);
            data.SaveChanges();
        }

        public void Edit(int houseId, string title, string address, string description, string imageUrl, decimal price, int categoryId)
        {
            House house = data.Houses.First(h => h.Id == houseId);

            house.Title = title;
            house.Address = address;
            house.Description = description;
            house.ImageUrl = imageUrl;
            house.PricePerMonth = price;
            house.CategoryId = categoryId;

            data.SaveChanges();
        }

        public bool Exists(int id)
            => data.Houses.Any(h => h.Id == id);

        public int GetHouseCategoryId(int houseId)
        {
            var house = data.Houses.Find(houseId);

            if (house == null)
                throw new ArgumentNullException("House does not exist!");

            return house.Id;
        }

        public bool HasAgentWithId(int houseId, string userId)
        {
            int? agentId = data.Houses.Find(houseId)?.AgentId;
            var agent = data.Agents.FirstOrDefault(a => a.Id == agentId);

            if (agent == null)
                return false;

            return agent.UserId == userId;
        }

        public HouseDetailsServiceModel HouseDetailsById(int id)
        {
            var model = data.Houses
                .Where(h => h.Id == id)
                .ProjectTo<HouseDetailsServiceModel>(mapper.ConfigurationProvider)
                .First();

            string userId = data.Users.First(a => a.Email == model.Agent.Email).Id;
            model.Agent.FullName = userService.UserFullName(userId);

            return model;
        }

        public bool IsRented(int houseId)
        {
            var house = data.Houses.Find(houseId);

            if (house == null)
                return false;

            return house.RenterId != null;
        }

        public bool IsRentedByUserWithId(int houseId, string userId)
        {
            var house = data.Houses.Find(houseId);

            if (house == null)
                return false;

            return house.RenterId == userId;
        }

        public IEnumerable<HouseIndexServiceModel> LastThreeHouses()
        {
            return data.Houses
                .OrderByDescending(h => h.Id)
                .Take(3)
                .ProjectTo<HouseIndexServiceModel>(mapper.ConfigurationProvider)
                .ToList();
        }

        public void Leave(int houseId)
        {
            var house = data.Houses.First(h => h.Id == houseId);

            house.RenterId = null;

            data.SaveChanges();
        }

        public void Rent(int houseId, string userId)
        {
            var house = data.Houses.First(h => h.Id == houseId);

            house.RenterId = userId;

            data.SaveChanges();
        }
    }
}
