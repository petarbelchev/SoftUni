#nullable disable

using Homies.Data.Entities;
using Homies.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Homies.Areas.Identity.Pages.Account
{
	public class LoginModel : PageModel
    {
		private readonly SignInManager<User> signInManager;

		public LoginModel(SignInManager<User> signInManager)
			=> this.signInManager = signInManager;

		[BindProperty]
		public InputModel Input { get; set; }

		[TempData]
		public string ErrorMessage { get; set; }

		public class InputModel
		{
			[Required]
			[EmailAddress]
			public string Email { get; set; }

			[Required]
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
					this.Input.Email, this.Input.Password, isPersistent: false, lockoutOnFailure: false);

				if (result.Succeeded)
					return this.RedirectToAction("All", "Event");

				this.ModelState.AddModelError(string.Empty, "Invalid login attempt.");
			}

			return this.Page();
		}
	}
}
