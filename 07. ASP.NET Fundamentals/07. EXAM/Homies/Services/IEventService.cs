using Homies.Models;

namespace Homies.Services
{
	public interface IEventService
	{
		/// <exception cref="InvalidOperationException"></exception>
		Task AddEventAsync(EventFormModel model, string organizerId);

		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="InvalidOperationException"></exception>
		Task EditEventAsync(int id, EventFormModel model, string organizerId);

		Task<IEnumerable<EventViewModel>> GetAllEventsAsync();

		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="InvalidOperationException"></exception>
		Task<EventFormModel> GetEventFormModelAsync(int id, string organizerId);

		/// <exception cref="InvalidOperationException"></exception>
		Task<EventDetailsViewModel> GetEventDetailsAsync(int id);

		Task<IEnumerable<EventViewModel>> GetJoinedEventsAsync(string userId);

		Task<IEnumerable<TypeViewModel>> GetTypesAsync();

		/// <exception cref="InvalidOperationException"></exception>
		Task LeaveFromEventAsync(int id, string userId);

		/// <exception cref="InvalidOperationException"></exception>
		Task JoinToEventAsync(int id, string userId);
	}
}
