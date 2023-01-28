using HouseRentingSystem.Services.Houses.Models;

namespace HouseRentingSystem.Services.Models
{
    public class HouseIndexServiceModel : IHouseModel
    {
        public int Id { get; init; }

        public string Title { get; init; } = null!;

        public string ImageUrl { get; init; } = null!;

        public string Address { get; init; } = null!;
    }
}
