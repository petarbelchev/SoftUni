using HouseRentingSystem.Infrastructure;
using HouseRentingSystem.Models.Agents;
using HouseRentingSystem.Services.Agents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
			return RedirectToAction(nameof(HousesController.All), "Houses");
		}
	}
}
