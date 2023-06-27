using Microsoft.AspNetCore.Identity;

namespace Homies.Data.Entities
{
	public class User : IdentityUser
	{
        public ICollection<Event> OrganizedEvents { get; set; }
			= new HashSet<Event>();

        public ICollection<EventParticipant> EventsParticipants { get; set; }
			= new HashSet<EventParticipant>();
    }
}
