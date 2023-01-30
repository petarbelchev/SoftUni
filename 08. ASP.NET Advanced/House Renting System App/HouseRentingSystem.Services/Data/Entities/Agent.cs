using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Services.Data.DataConstants.Agent;

namespace HouseRentingSystem.Services.Data.Entities
{
    public class Agent
    {
        [Key]
        public int Id { get; init; }
        
        [Required]
        [MaxLength(AgentPhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string UserId { get; init; } = null!;
        public User User { get; set; } = null!;
    }
}
