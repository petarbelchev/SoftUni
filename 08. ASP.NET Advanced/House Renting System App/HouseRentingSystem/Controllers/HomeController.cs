using HouseRentingSystem.Services.Houses;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHouseService houseService;

        public HomeController(IHouseService houseService)
            => this.houseService = houseService;

        public IActionResult Index() 
            => View(houseService.LastThreeHouses());

        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
                return View("Error400");

            if (statusCode == 401)
                return View("Error401");

            return View();
        }
    }
}