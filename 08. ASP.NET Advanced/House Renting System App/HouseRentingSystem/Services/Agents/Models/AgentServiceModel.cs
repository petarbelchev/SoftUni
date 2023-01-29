using System.ComponentModel;

namespace HouseRentingSystem.Services.Agents.Models
{
	public class AgentServiceModel
	{
		public string Email { get; init; } = null!;

		[DisplayName("Phone Number")]
		public string PhoneNumber { get; init; } = null!;

		public string FullName { get; init; } = null!;
	}
}
