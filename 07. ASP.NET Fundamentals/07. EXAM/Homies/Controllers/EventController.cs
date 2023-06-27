using Homies.Extensions;
using Homies.Models;
using Homies.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers
{
	[Authorize]
	public class EventController : Controller
	{
		private readonly IEventService eventService;

		public EventController(IEventService eventService)
			=> this.eventService = eventService;

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var viewModel = new EventFormModel
			{
				Types = await this.eventService.GetTypesAsync()
			};

			return this.View(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Add(EventFormModel model)
		{
			if (!this.ModelState.IsValid)
			{
				model.Types = await this.eventService.GetTypesAsync();

				return this.View(model);
			}

			try
			{
				await this.eventService.AddEventAsync(model, this.User.Id());
			}
			catch (InvalidOperationException ex)
			{
				this.ModelState.AddModelError(string.Empty, ex.Message);

				return this.View(model);
			}

			return this.RedirectToAction(nameof(All));
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			IEnumerable<EventViewModel> events = await this.eventService.GetAllEventsAsync();

			return this.View(events);
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			EventDetailsViewModel viewModel;

			try
			{
				viewModel = await this.eventService.GetEventDetailsAsync(id);
			}
			catch (InvalidOperationException)
			{
				return this.BadRequest();
			}

			return this.View(viewModel);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			EventFormModel viewModel;

			try
			{
				viewModel = await this.eventService.GetEventFormModelAsync(id, this.User.Id());
			}
			catch (ArgumentException)
			{
				return this.Unauthorized();
			}
			catch (InvalidOperationException)
			{
				return this.BadRequest();
			}

			return this.View(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, EventFormModel model)
		{
			if (!this.ModelState.IsValid)
			{
				model.Types = await this.eventService.GetTypesAsync();

				return this.View(model);
			}

			try
			{
				await this.eventService.EditEventAsync(id, model, this.User.Id());
			}
			catch (ArgumentException)
			{
				return this.Unauthorized();
			}
			catch (InvalidOperationException)
			{
				return this.BadRequest();
			}

			return this.RedirectToAction(nameof(All));
		}

		[HttpPost]
		public async Task<IActionResult> Join(int id)
		{
			try
			{
				await this.eventService.JoinToEventAsync(id, this.User.Id());
			}
			catch (InvalidOperationException)
			{
				return this.RedirectToAction(nameof(All));
			}

			return this.RedirectToAction(nameof(Joined));
		}

		[HttpGet]
		public async Task<IActionResult> Joined()
		{
			IEnumerable<EventViewModel> events =
				await this.eventService.GetJoinedEventsAsync(this.User.Id());

			return this.View(events);
		}

		[HttpPost]
		public async Task<IActionResult> Leave(int id)
		{
			try
			{
				await this.eventService.LeaveFromEventAsync(id, this.User.Id());
			}
			catch (InvalidOperationException)
			{
				return this.BadRequest();
			}

			return this.RedirectToAction(nameof(All));
		}
	}
}
