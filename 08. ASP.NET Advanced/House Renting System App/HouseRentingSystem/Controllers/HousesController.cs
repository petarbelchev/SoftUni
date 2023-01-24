using HouseRentingSystem.Infrastructure;
using HouseRentingSystem.Models.Houses;
using HouseRentingSystem.Services.Agents;
using HouseRentingSystem.Services.Houses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
    public class HousesController : Controller
    {
        private readonly IHouseService houseService;
        private readonly IAgentService agentService;

        public HousesController(
            IHouseService houseService,
            IAgentService agentService)
        {
            this.houseService = houseService;
            this.agentService = agentService;
        }

        public IActionResult All([FromQuery] AllHousesQueryModel queryModel)
        {
            var queryResult = houseService.All(
                queryModel.Category, 
                queryModel.SearchTerm, 
                queryModel.Sorting, 
                queryModel.CurrentPage, 
                AllHousesQueryModel.HousesPerPage);

            queryModel.TotalHousesCount = queryResult.TotalHousesCount;
            queryModel.Houses = queryResult.Houses;
            queryModel.Categories = houseService.AllCategoriesNames();

            return View(queryModel);
        }

        public IActionResult Details(int id)
            => View(new HouseDetailsViewModel());

        [Authorize]
        public IActionResult Add()
        {
            if (!agentService.ExistsById(User.Id()))
                return RedirectToAction("Become", "Agents");

            var form = new HouseFormModel()
            {
                Categories = houseService.AllCategories()
            };

            return View(form);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(HouseFormModel model)
        {
            if (!agentService.ExistsById(User.Id()))
                return RedirectToAction("Become", "Agents");

            if (!houseService.CategoryExists(model.CategoryId))
                ModelState.AddModelError(nameof(model.CategoryId),
                    "Category does not exist.");

            if (!ModelState.IsValid)
            {
                model.Categories = houseService.AllCategories();

                return View(model);
            }

            int agentId = agentService.GetAgentId(User.Id());

            int newHouseId = houseService.Create(model.Title, model.Address,
                model.Description, model.ImageUrl, model.PricePerMonth,
                model.CategoryId, agentId);

            return RedirectToAction(nameof(Details), new { id = newHouseId });
        }

        [Authorize]
        public IActionResult Mine()
        {
            string userId = User.Id();

            if (agentService.ExistsById(userId))
            {
                int agentId = agentService.GetAgentId(userId);

                return View(houseService.AllHousesByAgentId(agentId));
            }

            return View(houseService.AllHousesByUserId(userId));
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
