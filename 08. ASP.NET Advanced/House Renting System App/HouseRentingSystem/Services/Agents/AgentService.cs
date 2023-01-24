using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Entities;

namespace HouseRentingSystem.Services.Agents
{
    public class AgentService : IAgentService
    {
        private readonly HouseRentingDbContext data;

        public AgentService(HouseRentingDbContext context)
            => data = context;

        public void Create(string userId, string phoneNumber)
        {
            var newAgent = new Agent()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            data.Agents.Add(newAgent);
            data.SaveChanges();
        }

        public bool ExistsById(string userId)
            => data.Agents.Any(a => a.UserId == userId);

        public int GetAgentId(string userId)
            => data.Agents.FirstOrDefault(a => a.UserId == userId).Id;

        public bool UserHasRents(string userId)
            => data.Houses.Any(h => h.RenterId== userId);

        public bool UserWithPhoneNumberExists(string phoneNumber)
            => data.Agents.Any(a => a.PhoneNumber == phoneNumber);
    }
}
