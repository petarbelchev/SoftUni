using HouseRentingSystem.Services.Agents;
using HouseRentingSystem.Services.Houses;
using HouseRentingSystem.Web.Areas.Admin.Models;
using HouseRentingSystem.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Web.Areas.Admin.Controllers
{
	public class HousesController : AdminController
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

		public IActionResult Mine()
		{
			string adminUserId = User.Id();
			int adminId = agentService.GetAgentId(adminUserId);

			return View(new MyHousesViewModel
			{
				AddedHouses = houseService.AllHousesByAgentId(adminId),
				RentedHouses = houseService.AllHousesByUserId(adminUserId)
			});
		}
	}
}
