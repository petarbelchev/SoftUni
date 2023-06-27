using System.ComponentModel.DataAnnotations;
using static Homies.Constants.TypeConstants;

namespace Homies.Data.Entities
{
	public class Type
	{
		[Key]
        public int Id { get; set; }

		[Required]
		[MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

		public ICollection<Event> Events { get; set; }
			= new HashSet<Event>();
    }
}
