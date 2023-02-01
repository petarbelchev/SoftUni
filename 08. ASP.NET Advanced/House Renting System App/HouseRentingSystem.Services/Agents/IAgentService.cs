namespace HouseRentingSystem.Services.Agents
{
    public interface IAgentService
    {
        void Create(string userId, string phoneNumber);

        bool ExistsById(string userId);

        int GetAgentId(string userId);

        bool AgentWithPhoneNumberExists(string phoneNumber);
    }
}
