using System.ComponentModel.DataAnnotations;

namespace Theatre.Data.Models
{
	public class Theatre
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(40)] // min length 4
		public string Name { get; set; } = null!;

		[Required]
		[Range(0, 10)]
		public sbyte NumberOfHalls { get; set; }

		[Required]
		[MaxLength(30)] // min length 4
		public string Director { get; set; } = null!;

		public virtual ICollection<Ticket> Tickets { get; set; } = null!;
	}
}
