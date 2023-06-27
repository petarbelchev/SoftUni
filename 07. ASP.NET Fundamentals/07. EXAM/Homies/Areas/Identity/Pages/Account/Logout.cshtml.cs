#nullable disable

using Homies.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homies.Areas.Identity.Pages.Account
{
	[Authorize]
	public class LogoutModel : PageModel
	{
		private readonly SignInManager<User> signInManager;

		public LogoutModel(SignInManager<User> signInManager)
			=> this.signInManager = signInManager;

		public async Task<IActionResult> OnPost()
		{
			await this.signInManager.SignOutAsync();

			return this.LocalRedirect("/");
		}
	}
}
