using HouseRentingSystem.Services.Rents;
using HouseRentingSystem.Services.Rents.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static HouseRentingSystem.Services.Data.DataConstants.AdminConstants;

namespace HouseRentingSystem.Web.Areas.Admin.Controllers
{
	public class RentsController : AdminController
	{
		private readonly IRentService rentService;
		private readonly IMemoryCache cache;

		public RentsController(
			IRentService rentService,
			IMemoryCache cache)
		{
			this.rentService = rentService;
			this.cache = cache;
		}

		[Route("Rents/All")]
		public IActionResult All()
		{
			var rents = cache.Get<IEnumerable<RentServiceModel>>(RentsCacheKey);

			if (rents == null)
			{
				rents = rentService.All();
				cache.Set(RentsCacheKey, rents, TimeSpan.FromMinutes(5));
			}

			return View(rents);
		}
	}
}
