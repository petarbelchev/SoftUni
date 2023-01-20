using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Watchlist.Data.Entities;
using Watchlist.Models.User;

namespace Watchlist.Controllers
{
	public class UserController : BaseController
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

		[AllowAnonymous]
		public IActionResult Index()
		{
			if (User?.Identity?.IsAuthenticated ?? false)
				return RedirectToAction("Index", "Home");

			return RedirectToAction("Login");
		}

		[AllowAnonymous]
		public IActionResult Register()
		{
			if (User?.Identity?.IsAuthenticated ?? false)
				return RedirectToAction("Index", "Home");

			return View(new RegisterViewModel());
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			var newUser = new User
			{
				UserName = model.UserName,
				Email = model.Email
			};

			var result = await userManager.CreateAsync(newUser, model.Password);

			if (result.Succeeded)
				return RedirectToAction("Login");

			foreach (var error in result.Errors)
				ModelState.AddModelError("", error.Description);

			return View(model);
		}

		[AllowAnonymous]
		public IActionResult Login(string? returnUrl = null)
		{
			var model = new LoginViewModel();

			if (returnUrl != null)
				model.ReturnUrl = returnUrl;

			return View(model);
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			var result = await signInManager
				.PasswordSignInAsync(model.UserName, model.Password, true, false);

			if (result.Succeeded)
			{
				if (model.ReturnUrl != null)
					return Redirect(model.ReturnUrl);

				return RedirectToAction("All", "Movies");
			}
			else
			{
				ModelState.AddModelError("", "Invalid login!");
				return View(model);
			}
		}

		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();

			return RedirectToAction("Index", "Home");
		}
	}
}
