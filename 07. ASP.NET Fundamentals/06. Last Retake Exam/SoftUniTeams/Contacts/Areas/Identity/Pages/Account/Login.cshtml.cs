#nullable disable

using Contacts.Data.Entities;
using Contacts.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using static Contacts.Constants.UserConstants;

namespace Contacts.Areas.Identity.Pages.Account
{
	public class LoginModel : PageModel
	{
		private readonly SignInManager<ApplicationUser> signInManager;

		public LoginModel(SignInManager<ApplicationUser> signInManager)
			=> this.signInManager = signInManager;

		[BindProperty]
		public InputModel Input { get; set; }

		[TempData]
		public string ErrorMessage { get; set; }

		public class InputModel
		{
			[Required]
			[StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength,
				ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
			public string Username { get; set; }

			[Required]
			[StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength,
				ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
			[DataType(DataType.Password)]
			public string Password { get; set; }
		}

		public async Task<IActionResult> OnGetAsync()
		{
			if (this.User.IsAuthenticated())
				return this.LocalRedirect("/");

			if (!string.IsNullOrEmpty(this.ErrorMessage))
				this.ModelState.AddModelError(string.Empty, this.ErrorMessage);

			await this.HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

			return this.Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (this.ModelState.IsValid)
			{
				var result = await this.signInManager.PasswordSignInAsync(
					this.Input.Username, this.Input.Password, isPersistent: false, lockoutOnFailure: false);

				if (result.Succeeded)
					return this.RedirectToAction("All", "Contacts");

				this.ModelState.AddModelError(string.Empty, "Invalid login attempt.");
			}

			return this.Page();
		}
	}
}
