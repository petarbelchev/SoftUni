using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Data.DataConstants.Agent;

namespace HouseRentingSystem.Data.Entities
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
