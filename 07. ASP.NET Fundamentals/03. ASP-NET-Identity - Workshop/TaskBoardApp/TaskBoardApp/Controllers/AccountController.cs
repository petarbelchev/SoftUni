using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskBoardApp.Data.Entities;
using TaskBoardApp.Models.Account;

namespace TaskBoardApp.Controllers
{
	public class AccountController : BaseController
	{
		private readonly UserManager<User> userManager;
		private readonly SignInManager<User> signInManager;

		public AccountController(
			UserManager<User> userManager,
			SignInManager<User> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		[AllowAnonymous]
		public IActionResult Index()
		{
			if (User.Identity?.IsAuthenticated ?? false)
				return RedirectToAction("Index", "Home");
			else
				return RedirectToAction("Login");
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Register()
		{
			RegisterViewModel model = new RegisterViewModel();

			return View(model);
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			var newUser = new User()
			{
				UserName = model.Username,
				Email = model.Email,
				FirstName = model.FirstName,
				LastName = model.LastName
			};

			var result = await userManager.CreateAsync(newUser, model.Password);

			if (result.Succeeded)
			{
				await signInManager.SignInAsync(newUser, true);

				return RedirectToAction("Index", "Home");
			}

			foreach (var error in result.Errors)
				ModelState.AddModelError("", error.Description);

			return View(model);
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Login(string? returnUrl = null)
		{
			LoginViewModel model = new LoginViewModel();

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

			await signInManager.SignOutAsync();

			var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, true, false);

			if (result.Succeeded)
			{
				if (model.ReturnUrl != null)
					return Redirect(model.ReturnUrl);

				return RedirectToAction("Index", "Home");
			}

			ModelState.AddModelError("", "Invalid login!");

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();

			return RedirectToAction("Index", "Home");
		}
	}
}
