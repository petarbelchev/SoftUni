using HouseRentingSystem.Data;

namespace HouseRentingSystem.Services.Agents
{
    public class AgentService : IAgentService
    {
        private readonly HouseRentingDbContext data;

        public AgentService(HouseRentingDbContext context)
            => data = context;

        public bool ExistsById(string userId)
            => data.Agents.Any(a => a.UserId == userId);
    }
}
