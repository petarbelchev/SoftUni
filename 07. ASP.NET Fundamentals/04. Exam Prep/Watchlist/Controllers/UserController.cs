using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Watchlist.Data.Models;
using Watchlist.Models;

namespace Watchlist.Controllers
{
    public class UserController : Controller
	{
		private readonly UserManager<User> userManager;
		private readonly SignInManager<User> signInManager;

		public UserController(
			UserManager<User> userManager,
			SignInManager<User> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		public IActionResult Register()
		{
			if (User.Identity?.IsAuthenticated ?? false)
			{
				return LocalRedirect("/");
			}

			return View(new RegisterFormModel());
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			User user = new User
			{
				Email = model.Email,
				UserName = model.UserName
			};

			var result = await userManager.CreateAsync(user, model.Password);

			if (result.Succeeded)
			{
				return RedirectToAction(nameof(Login));
			}

			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(string.Empty, error.Description);
			}

			return View(model);
		}

		public IActionResult Login()
		{
			if (User.Identity?.IsAuthenticated ?? false)
			{
				return LocalRedirect("/");
			}

			return View(new LoginFormModel());
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var result = await signInManager.PasswordSignInAsync(
				model.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);

			if (result.Succeeded)
			{
				return LocalRedirect("/");
			}

			ModelState.AddModelError(string.Empty, "Invalid login attempt.");

			return View(model);
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();

			return LocalRedirect("/");
		}
	}
}
