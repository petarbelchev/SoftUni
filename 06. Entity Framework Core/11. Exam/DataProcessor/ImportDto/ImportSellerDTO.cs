using System.ComponentModel.DataAnnotations;

namespace Boardgames.DataProcessor.ImportDto
{
	public class ImportSellerDTO
	{
		//•	Name – text with length [5…20] (required)
		[Required]
		[StringLength(20, MinimumLength = 5)]
		public string Name { get; set; } = null!;

		//•	Address – text with length [2…30] (required)
		[Required]
		[StringLength(30, MinimumLength = 2)]
		public string Address { get; set; } = null!;

		//•	Country – text (required)
		[Required]
		public string Country { get; set; } = null!;

		//•	Website – a string (required).
		//First four characters are "www.", followed by upper and lower letters, digits or '-' and the last three characters are ".com".
		[Required]
		[RegularExpression($@"^www\.[A-Za-z\d-]+\.com$")]
		public string Website { get; set; } = null!;

		//•	BoardgamesSellers – collection of type BoardgameSeller
		public int[] Boardgames { get; set; } = null!;
	}
}
