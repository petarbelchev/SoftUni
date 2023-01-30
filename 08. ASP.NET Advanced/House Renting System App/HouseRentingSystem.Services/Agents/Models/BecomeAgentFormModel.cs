using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Services.Data.DataConstants.Agent;

namespace HouseRentingSystem.Services.Agents.Models
{
	public class BecomeAgentFormModel
	{
		[Required]
		[StringLength(AgentPhoneNumberMaxLength, MinimumLength = AgentPhoneNumberMinLength)]
		[Display(Name = "Phone Number")]
		[Phone]
		public string PhoneNumber { get; init; } = null!;
	}
}
