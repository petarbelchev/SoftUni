using HouseRentingSystem.Data;
using HouseRentingSystem.Services.Statistics.Models;

namespace HouseRentingSystem.Services.Statistics
{
    public class StatisticsService : IStatisticsService
    {
        private readonly HouseRentingDbContext data;

        public StatisticsService(HouseRentingDbContext context)
            => this.data = context;

        public StatisticsServiceModel Total()
        {
            return new StatisticsServiceModel()
            {
                TotalHouses = data.Houses.Count(),
                TotalRents = data.Houses.Count(h => h.RenterId != null)
            };
        }
    }
}
