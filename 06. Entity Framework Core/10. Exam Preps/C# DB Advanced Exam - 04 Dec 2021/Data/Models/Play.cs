using System.ComponentModel.DataAnnotations;
using Theatre.Data.Models.Enums;

namespace Theatre.Data.Models
{
	public class Play
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(50)] // min length 4
		public string Title { get; set; } = null!;

		//format {hours:minutes:seconds}, with a minimum length of 1 hour
		[Required]
		public TimeSpan Duration { get; set; }

		[Required]
		[Range(0.00, 10.00)]
		public float Rating { get; set; }

		[Required]
		public Genre Genre { get; set; }

		[Required]
		[MaxLength(700)]
		public string Description { get; set; } = null!;

		[Required]
		[MaxLength(30)] // min length 4
        public string Screenwriter { get; set; } = null!;

        public virtual ICollection<Cast> Casts { get; set; } = null!;

        public virtual ICollection<Ticket> Tickets { get; set; } = null!;
    }
}
