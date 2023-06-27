using Homies.Data;
using Homies.Data.Entities;
using Homies.Models;
using Microsoft.EntityFrameworkCore;

namespace Homies.Services
{
	public class EventService : IEventService
	{
		private readonly HomiesDbContext context;

		public EventService(HomiesDbContext context)
			=> this.context = context;

		/// <exception cref="InvalidOperationException"></exception>
		public async Task AddEventAsync(EventFormModel model, string organizerId)
		{
			if (!await this.context.Types.AnyAsync(x => x.Id == model.TypeId))
				throw new InvalidOperationException("Type does not exist.");

			var newEvent = new Event
			{
				Name = model.Name,
				TypeId = model.TypeId,
				Description = model.Description,
				CreatedOn = DateTime.UtcNow,
				Start = model.Start ?? throw new InvalidOperationException(),
				End = model.End ?? throw new InvalidOperationException(),
				OrganizerId = organizerId,
			};

			await this.context.Events.AddAsync(newEvent);
			await this.context.SaveChangesAsync();
		}

		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="InvalidOperationException"></exception>
		public async Task EditEventAsync(int id, EventFormModel model, string organizerId)
		{
			Event? @event = await this.context.Events.FindAsync(id)
				?? throw new InvalidOperationException("Event does not exist.");

			if (@event.OrganizerId != organizerId)
				throw new ArgumentException("The user cannot edit this event.");

			@event.Start = model.Start ?? throw new InvalidOperationException();
			@event.End = model.End ?? throw new InvalidOperationException();
			@event.Description = model.Description;
			@event.Name = model.Name;
			@event.TypeId = model.TypeId;

			await this.context.SaveChangesAsync();
		}

		public async Task<IEnumerable<EventViewModel>> GetAllEventsAsync()
		{
			EventViewModel[] events = await this.context.Events
				.Select(x => new EventViewModel
				{
					Id = x.Id,
					Name = x.Name,
					Organizer = x.Organizer.Email,
					Start = x.Start.ToString("yyyy-MM-dd H:mm"),
					Type = x.Type.Name
				})
				.ToArrayAsync();

			return events;
		}

		/// <exception cref="InvalidOperationException"></exception>
		public async Task<EventDetailsViewModel> GetEventDetailsAsync(int id)
		{
			EventDetailsViewModel viewModel = await this.context.Events
				.Where(x => x.Id == id)
				.Select(x => new EventDetailsViewModel
				{
					Id = x.Id,
					Name = x.Name,
					Description = x.Description,
					CreatedOn = x.CreatedOn.ToString("yyyy-MM-dd H:mm"),
					Organizer = x.Organizer.Email,
					Type = x.Type.Name,
					Start = x.Start.ToString("yyyy-MM-dd H:mm"),
					End = x.End.ToString("yyyy-MM-dd H:mm")
				})
				.FirstAsync();

			return viewModel;
		}

		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="InvalidOperationException"></exception>
		public async Task<EventFormModel> GetEventFormModelAsync(int id, string organizerId)
		{
			Event? @event = await this.context.Events.FindAsync(id)
				?? throw new InvalidOperationException("Event does not exist.");

			if (@event.OrganizerId != organizerId)
				throw new ArgumentException("The user cannot edit this event.");

			var formModel = new EventFormModel
			{
				Name = @event.Name,
				TypeId = @event.TypeId,
				Description = @event.Description,
				Start = @event.Start,
				End = @event.End,
				Types = await this.context.Types
					.Select(x => new TypeViewModel
					{
						Id = x.Id,
						Name = x.Name
					})
					.ToArrayAsync()
			};

			return formModel;
		}

		public async Task<IEnumerable<EventViewModel>> GetJoinedEventsAsync(string userId)
		{
			EventViewModel[] events = await this.context.EventsParticipants
				.Where(x => x.HelperId == userId)
				.Select(x => new EventViewModel
				{
					Id = x.Event.Id,
					Name = x.Event.Name,
					Organizer = x.Event.Organizer.Email,
					Start = x.Event.Start.ToString("yyyy-MM-dd H:mm"),
					Type = x.Event.Type.Name
				})
				.ToArrayAsync();

			return events;
		}

		public async Task<IEnumerable<TypeViewModel>> GetTypesAsync()
		{
			var types = await this.context.Types
				.Select(x => new TypeViewModel
				{
					Id = x.Id,
					Name = x.Name
				})
				.ToArrayAsync();

			return types;
		}

		/// <exception cref="InvalidOperationException"></exception>
		public async Task JoinToEventAsync(int id, string userId)
		{
			bool isUserJoined = await this.context.EventsParticipants
				.AnyAsync(x => x.EventId == id && x.HelperId == userId);

			if (isUserJoined)
				throw new InvalidOperationException();

			var userEvent = new EventParticipant
			{
				EventId = id,
				HelperId = userId
			};

			await this.context.EventsParticipants.AddAsync(userEvent);
			await this.context.SaveChangesAsync();
		}

		/// <exception cref="InvalidOperationException"></exception>
		public async Task LeaveFromEventAsync(int id, string userId)
		{
			EventParticipant userEvent = await this.context.EventsParticipants
				.FirstAsync(x => x.EventId == id && x.HelperId == userId);

			this.context.EventsParticipants.Remove(userEvent);
			await this.context.SaveChangesAsync();
		}
	}
}
