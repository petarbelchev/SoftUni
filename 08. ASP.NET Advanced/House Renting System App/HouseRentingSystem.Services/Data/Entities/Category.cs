using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Services.Data.DataConstants.Category;

namespace HouseRentingSystem.Services.Data.Entities
{
    public class Category
    {
        public int Id { get; init; }

        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<House> Houses { get; init; } 
            = new HashSet<House>();
    }
}