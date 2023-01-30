using HouseRentingSystem.Web.Infrastructure;
using HouseRentingSystem.Services.Agents;
using HouseRentingSystem.Services.Houses;
using HouseRentingSystem.Services.Houses.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace HouseRentingSystem.Web.Controllers
{
	public class HousesController : Controller
	{
		private readonly IHouseService houseService;
		private readonly IAgentService agentService;
		private readonly IMapper mapper;

		public HousesController(
			IHouseService houseService,
			IAgentService agentService,
			IMapper mapper)
		{
			this.houseService = houseService;
			this.agentService = agentService;
			this.mapper = mapper;
		}

		public IActionResult All([FromQuery] AllHousesQueryModel queryModel)
		{
			HouseQueryServiceModel queryResult = houseService.All(
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

		public IActionResult Details(int id, string information)
		{
			if (!houseService.Exists(id))
				return BadRequest();

			var houseModel = houseService.HouseDetailsById(id);

			if (information != houseModel.GetInformation())
				return BadRequest();

			return View(houseModel);
		}

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

			return RedirectToAction(nameof(Details),
				new { id = newHouseId, information = model.GetInformation() });
		}

		[Authorize]
		public IActionResult Mine()
		{
			var userHouses = new List<HouseServiceModel>();
			string userId = User.Id();
			bool isAgent = agentService.ExistsById(userId);

			if (isAgent)
			{
				int agentId = agentService.GetAgentId(userId);
				userHouses.AddRange(houseService.AllHousesByAgentId(agentId));
			}

			if (!isAgent || User.IsAdmin())
			{
				int[] addedHousesIds = userHouses.Select(h => h.Id).ToArray();

				userHouses.AddRange(houseService.AllHousesByUserId(userId)
					.Where(h => !addedHousesIds.Contains(h.Id)));
			}

			return View(userHouses);
		}

		[Authorize]
		public IActionResult Edit(int id)
		{
			if (!houseService.Exists(id))
				return BadRequest();

			if (!houseService.HasAgentWithId(id, User.Id()) && !User.IsAdmin())
				return Unauthorized();

			var house = houseService.HouseDetailsById(id);
			var houseCategoryId = houseService.GetHouseCategoryId(id);
			var formModel = mapper.Map<HouseFormModel>(house);
			formModel.CategoryId = houseCategoryId;
			formModel.Categories = houseService.AllCategories();

			return View(formModel);
		}

		[Authorize]
		[HttpPost]
		public IActionResult Edit(int id, HouseFormModel model)
		{
			if (!houseService.Exists(id))
				return BadRequest();

			if (!houseService.HasAgentWithId(id, User.Id()) && !User.IsAdmin())
				return Unauthorized();

			if (!houseService.CategoryExists(model.CategoryId))
				ModelState.AddModelError(nameof(model.CategoryId),
					"Category does not exist.");

			if (!ModelState.IsValid)
			{
				model.Categories = houseService.AllCategories();

				return View(model);
			}

			houseService.Edit(id, model.Title, model.Address, model.Description,
							  model.ImageUrl, model.PricePerMonth, model.CategoryId);

			return RedirectToAction(nameof(Details),
				new { id, information = model.GetInformation() });
		}

		[Authorize]
		public IActionResult Delete(int id)
		{
			if (!houseService.Exists(id))
				return BadRequest();

			if (!houseService.HasAgentWithId(id, User.Id()) && !User.IsAdmin())
				return Unauthorized();

			var house = houseService.HouseDetailsById(id);
			var viewModel = mapper.Map<HouseDetailsViewModel>(house);

			return View(viewModel);
		}

		[Authorize]
		[HttpPost]
		public IActionResult Delete(HouseDetailsViewModel model)
		{
			if (!houseService.Exists(model.Id))
				return BadRequest();

			if (!houseService.HasAgentWithId(model.Id, User.Id()) && !User.IsAdmin())
				return Unauthorized();

			houseService.Delete(model.Id);

			return RedirectToAction(nameof(All));
		}

		[Authorize]
		[HttpPost]
		public IActionResult Rent(int id)
		{
			if (!houseService.Exists(id))
				return BadRequest();

			string userId = User.Id();

			if (agentService.ExistsById(userId) && !User.IsAdmin())
				return Unauthorized();

			if (houseService.IsRented(id))
				return BadRequest();

			houseService.Rent(id, userId);

			return RedirectToAction(nameof(Mine));
		}

		[Authorize]
		[HttpPost]
		public IActionResult Leave(int id)
		{
			if (!houseService.Exists(id) ||
				!houseService.IsRented(id))
			{
				return BadRequest();
			}

			string userId = User.Id();

			if ((agentService.ExistsById(userId) && !User.IsAdmin()) ||
				!houseService.IsRentedByUserWithId(id, userId))
			{
				return Unauthorized();
			}

			houseService.Leave(id);

			return RedirectToAction(nameof(Mine));
		}
	}
}
