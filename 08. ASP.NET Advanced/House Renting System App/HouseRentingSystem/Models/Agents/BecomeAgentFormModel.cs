﻿using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Data.DataConstants.Agent;

namespace HouseRentingSystem.Models.Agents
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
