using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HouseRentingSystem.Data.DataConstants.House;

namespace HouseRentingSystem.Data.Entities
{
    public class House
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(HouseTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(HouseAddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(HouseDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public decimal PricePerMonth { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        [ForeignKey(nameof(Agent))]
        public int AgentId { get; set; }
        public Agent Agent { get; set; } = null!;

        public string? RenterId { get; set; }
    }
}
