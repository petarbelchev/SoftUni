using System.ComponentModel.DataAnnotations;

namespace Trucks.DataProcessor.ImportDto
{
	public class ImportClientDTO
	{
		//•	Name – text with length [3, 40] (required)
		[Required]
		[StringLength(40, MinimumLength = 3)]
		public string Name { get; set; } = null!;

		//•	Nationality – text with length [2, 40] (required)
		[Required]
		[StringLength(40, MinimumLength = 2)]
		public string Nationality { get; set; } = null!;

		//•	Type – text (required)
		[Required]
		public string Type { get; set; } = null!;

		//•	ClientsTrucks – collection of type ClientTruck
		public virtual int[] Trucks { get; set; } = null!;
	}
}
