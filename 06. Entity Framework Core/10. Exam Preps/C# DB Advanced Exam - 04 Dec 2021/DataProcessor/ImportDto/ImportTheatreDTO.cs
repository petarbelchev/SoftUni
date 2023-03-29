using System.ComponentModel.DataAnnotations;

namespace Theatre.DataProcessor.ImportDto
{
	public class ImportTheatreDTO
	{
		[Required]
		[MinLength(4)]
		public string Name { get; set; } = null!;

		[Required]
		[Range(0, 10)]
		public sbyte NumberOfHalls { get; set; }

		[Required]
		[MinLength(4)]
		public string Director { get; set; } = null!;

		public ImportTicketDTO[] Tickets { get; set; } = null!;
	}
}
