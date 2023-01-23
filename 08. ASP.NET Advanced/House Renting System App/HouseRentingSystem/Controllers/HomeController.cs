﻿using HouseRentingSystem.Models;
using HouseRentingSystem.Models.Home;
using HouseRentingSystem.Services.Houses;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HouseRentingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHouseService houseService;

        public HomeController(IHouseService houseService)
            => this.houseService = houseService;

        public IActionResult Index() 
            => View(houseService.LastThreeHouses());

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}