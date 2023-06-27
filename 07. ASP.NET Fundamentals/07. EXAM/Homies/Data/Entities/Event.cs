using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Homies.Constants.EventConstants;

namespace Homies.Data.Entities
{
	public class Event
	{
		[Key]
		public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

		[Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

		[Required]
        [ForeignKey(nameof(Organizer))]
        public string OrganizerId { get; set; } = null!;

		public User Organizer { get; set; } = null!;

		[Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }

        public Type Type { get; set; } = null!;

        public ICollection<EventParticipant> EventsParticipants { get; set; }
            = new HashSet<EventParticipant>();
    }
}
