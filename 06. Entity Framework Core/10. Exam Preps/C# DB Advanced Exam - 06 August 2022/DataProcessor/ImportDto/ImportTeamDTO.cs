using System.ComponentModel.DataAnnotations;

namespace Footballers.DataProcessor.ImportDto
{
	public class ImportTeamDTO
	{
		//•	Name – text with length [3, 40].
		//Should contain letters (lower and upper case), digits, spaces, a dot sign ('.') and a dash ('-'). (required)
		[Required]
		[StringLength(40, MinimumLength = 3)]
		[RegularExpression(@"^[A-Za-z.\s\-0-9]+$")]
		public string Name { get; set; } = null!;

		//•	Nationality – text with length [2, 40] (required)
		[Required]
		[StringLength(40, MinimumLength = 2)]
		public string Nationality { get; set; } = null!;

		//•	Trophies – integer (required)
		[Required]
		[Range(1, int.MaxValue)]
		public int Trophies { get; set; }

		//•	TeamsFootballers – collection of type TeamFootballer
		public int[] Footballers { get; set; } = null!;
	}
}
