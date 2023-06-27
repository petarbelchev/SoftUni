#nullable disable

using Homies.Data.Entities;
using Homies.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Homies.Areas.Identity.Pages.Account
{
	public class RegisterModel : PageModel
    {
		private readonly UserManager<User> userManager;

		public RegisterModel(UserManager<User> userManager)
			=> this.userManager = userManager;

		[BindProperty]
		public InputModel Input { get; set; }

		public class InputModel
		{
			[Required]
			[EmailAddress]
			public string Email { get; set; }

			[Required]
			[DataType(DataType.Password)]
			public string Password { get; set; }

			[DataType(DataType.Password)]
			[Display(Name = "Confirm password")]
			[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
			public string ConfirmPassword { get; set; }
		}

		public IActionResult OnGetAsync() => this.User.IsAuthenticated()
			? this.LocalRedirect("/")
			: this.Page();

		public async Task<IActionResult> OnPostAsync()
		{
			if (this.ModelState.IsValid)
			{
				var user = new User
				{
					UserName = this.Input.Email,
					Email = this.Input.Email
				};

				IdentityResult result = await this.userManager.CreateAsync(user, this.Input.Password);

				if (result.Succeeded)
					return this.RedirectToPage("Login");

				foreach (IdentityError error in result.Errors)
					this.ModelState.AddModelError(string.Empty, error.Description);
			}

			return this.Page();
		}
	}
}
