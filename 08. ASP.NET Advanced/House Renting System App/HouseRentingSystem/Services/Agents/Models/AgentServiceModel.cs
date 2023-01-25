using System.ComponentModel;

namespace HouseRentingSystem.Services.Agents.Models
{
	public class AgentServiceModel
	{
		public string Email { get; set; } = null!;

		[DisplayName("Phone Number")]
		public string PhoneNumber { get; set; } = null!;
	}
}
