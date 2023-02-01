using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseRentingSystem.Services.Data;
using HouseRentingSystem.Services.Users.Models;

namespace HouseRentingSystem.Services.Users
{
    public class UserService : IUserService
    {
        private readonly HouseRentingDbContext data;
        private readonly IMapper mapper;

        public UserService(
            HouseRentingDbContext data,
            IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public IEnumerable<UserServiceModel> All()
        {
            var allUsers = new List<UserServiceModel>();

            List<UserServiceModel> agents = data.Agents
                .ProjectTo<UserServiceModel>(mapper.ConfigurationProvider)
                .ToList();

            allUsers.AddRange(agents);

            List<UserServiceModel> users = data.Users
                .Where(u => !data.Agents.Any(a => a.UserId == u.Id))
                .ProjectTo<UserServiceModel>(mapper.ConfigurationProvider)
                .ToList();

            allUsers.AddRange(users);

            return allUsers;
        }

        public bool UserHasRents(string userId)
            => data.Houses.Any(h => h.RenterId == userId);

        public string UserFullName(string userId)
        {
            var user = data.Users.Find(userId);

            return user?.FirstName + " " + user?.LastName;
        }
    }
}
