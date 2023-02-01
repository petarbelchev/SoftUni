using HouseRentingSystem.Web.Infrastructure;
using HouseRentingSystem.Services.Agents;
using HouseRentingSystem.Services.Agents.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HouseRentingSystem.Services.Users;

namespace HouseRentingSystem.Web.Controllers
{
	public class AgentsController : Controller
	{
		private readonly IAgentService agentService;
		private readonly IUserService userService;

		public AgentsController(
			IAgentService agentService, 
			IUserService userService)
		{
			this.agentService = agentService;
			this.userService = userService;
		}

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

			if (agentService.AgentWithPhoneNumberExists(model.PhoneNumber))
				ModelState.AddModelError(nameof(model.PhoneNumber),
					"Phone number already exists. Enter another one.");

			if (userService.UserHasRents(User.Id() ?? string.Empty))
				ModelState.AddModelError("Error",
					"You should have no rents to become an agent!");

			if (!ModelState.IsValid)
				return View(model);

			agentService.Create(userId, model.PhoneNumber);
			TempData["message"] = "You have sussessfully become an agent!";

			return RedirectToAction(nameof(HousesController.All), "Houses");
		}
	}
}
