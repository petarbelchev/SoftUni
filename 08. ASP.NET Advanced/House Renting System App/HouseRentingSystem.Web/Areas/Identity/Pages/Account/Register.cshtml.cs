﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using HouseRentingSystem.Services.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Services.Data.DataConstants.User;
using static HouseRentingSystem.Services.Data.DataConstants.AdminConstants;

namespace HouseRentingSystem.Web.Areas.Identity.Pages.Account
{
	public class RegisterModel : PageModel
	{
		private readonly SignInManager<User> signInManager;
		private readonly UserManager<User> userManager;
		private readonly IMemoryCache cache;

		public RegisterModel(
			UserManager<User> userManager,
			SignInManager<User> signInManager,
			IMemoryCache cache)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.cache = cache;
		}

		[BindProperty]
		public InputModel Input { get; set; }

		public string ReturnUrl { get; set; }

		public class InputModel
		{
			[Required]
			[EmailAddress]
			[Display(Name = "Email")]
			public string Email { get; set; }

			[Required]
			[StringLength(100, MinimumLength = 6, 
				ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
			[DataType(DataType.Password)]
			[Display(Name = "Password")]
			public string Password { get; set; }

			[DataType(DataType.Password)]
			[Display(Name = "Confirm password")]
			[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
			public string ConfirmPassword { get; set; }

			[Required]
			[StringLength(UserFirstNameMaxLength, MinimumLength = UserFirstNameMinLength)]
			[Display(Name = "First Name")]
			public string FirstName { get; set; }

			[Required]
			[StringLength(UserLastNameMaxLength, MinimumLength = UserLastNameMinLength)]
			[Display(Name = "Last Name")]
			public string LastName { get; set; }
		}


		public void OnGetAsync(string returnUrl = null)
		{
			ReturnUrl = returnUrl;
		}

		public async Task<IActionResult> OnPostAsync(string returnUrl = null)
		{
			returnUrl ??= Url.Content("~/");

			if (ModelState.IsValid)
			{
				var user = new User
				{
					UserName = Input.Email,
					Email = Input.Email,
					FirstName = Input.FirstName,
					LastName = Input.LastName
				};

				var result = await userManager.CreateAsync(user, Input.Password);

				if (result.Succeeded)
				{
					cache.Remove(UsersCacheKey);
					await signInManager.SignInAsync(user, isPersistent: false);
					return LocalRedirect(returnUrl);
				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}

			return Page();
		}
	}
}
