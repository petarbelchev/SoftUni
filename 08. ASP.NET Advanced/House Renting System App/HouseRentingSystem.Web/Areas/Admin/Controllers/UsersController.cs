using HouseRentingSystem.Services.Users;
using HouseRentingSystem.Services.Users.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static HouseRentingSystem.Services.Data.DataConstants.AdminConstants;

namespace HouseRentingSystem.Web.Areas.Admin.Controllers
{
	public class UsersController : AdminController
	{
		private readonly IUserService userService;
		private readonly IMemoryCache cache;

		public UsersController(
			IUserService userService,
			IMemoryCache cache)
		{
			this.userService = userService;
			this.cache = cache;
		}

		[Route("Users/All")]
		public IActionResult All()
		{
			var users = cache.Get<IEnumerable<UserServiceModel>>(UsersCacheKey);

			if (users == null)
			{
				users = userService.All();
				cache.Set(UsersCacheKey, users, TimeSpan.FromMinutes(5));
			}

			return View(users);
		}
	}
}
