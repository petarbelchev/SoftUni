﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Services.Data.DataConstants.User;

namespace HouseRentingSystem.Services.Data.Entities
{
	public class User : IdentityUser
	{
		[Required]
		[MaxLength(UserFirstNameMaxLength)]
		public string FirstName { get; set; } = null!;

		[Required]
		[MaxLength(UserLastNameMaxLength)]
		public string LastName { get; set; } = null!;
	}
}
