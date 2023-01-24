using HouseRentingSystem.Infrastructure;
using HouseRentingSystem.Models.Agents;
using HouseRentingSystem.Services.Agents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
    public class AgentsController : Controller
    {
        private readonly IAgentService agentService;

        public AgentsController(IAgentService agentService)
            => this.agentService = agentService;

        [Authorize]
        public IActionResult Become()
        {
            if (agentService.ExistsById(User.Id() ?? string.Empty))
                return BadRequest();

            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Become(BecomeAgentFormModel model)
        {
            string userId = User.Id() ?? string.Empty;

            if (agentService.ExistsById(userId))
                return BadRequest();

            if (agentService.UserWithPhoneNumberExists(model.PhoneNumber))
                ModelState.AddModelError(nameof(model.PhoneNumber),
                    "Phone number already exists. Enter another one.");

            if (agentService.UserHasRents(User.Id() ?? string.Empty))
                ModelState.AddModelError("Error",
                    "You should have no rents to become an agent!");
            
            if (!ModelState.IsValid)
                return View(model);

            agentService.Create(userId, model.PhoneNumber);

            return RedirectToAction(nameof(HousesController.All), "Houses");
        }
    }
}
