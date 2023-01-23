using Microsoft.AspNetCore.Mvc;
using HouseRentingSystem.Models.Houses;
using Microsoft.AspNetCore.Authorization;
using static Humanizer.In;

namespace HouseRentingSystem.Controllers
{
	public class HousesController : Controller
	{
		public IActionResult All()
			=> View(new AllHousesQueryModel());

		public IActionResult Details(int id)
			=> View(new HouseDetailsViewModel());

		[Authorize]
		public IActionResult Add()
			=> View();

		[Authorize]
		[HttpPost]
		public IActionResult Add(HouseFormModel model)
		{
			return RedirectToAction(nameof(Details), new { id = 1 });
		}

		[Authorize]
		public IActionResult Edit(int id)
		{
			return View(new HouseFormModel());
		}

		[Authorize]
		[HttpPost]
		public IActionResult Edit(HouseFormModel model)
		{
			return RedirectToAction(nameof(Details), new { id = 1 });
		}

		[Authorize]
		public IActionResult Delete(int id)
		{
			return View(new HouseDetailsViewModel());
		}

		[Authorize]
		[HttpPost]
		public IActionResult Delete(HouseDetailsViewModel model)
		{
			return RedirectToAction(nameof(All));
		}

		//[Authorize]
		//[HttpPost]
		//public IActionResult Rent(int id)
		//{
		//	return RedirectToAction(nameof(Mine));
		//}

		//[Authorize]
		//[HttpPost]
		//public IActionResult Leave(int id)
		//{
		//	return RedirectToAction(nameof(Mine));
		//}
	}
}
