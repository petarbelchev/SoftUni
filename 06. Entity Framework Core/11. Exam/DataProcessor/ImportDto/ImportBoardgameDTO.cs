using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
	[XmlType("Boardgame")]
	public class ImportBoardgameDTO
	{
		//•	Name – text with length [10…20] (required)
		[XmlElement("Name")]
		[Required]
		[StringLength(20, MinimumLength = 10)]
		public string Name { get; set; } = null!;

		//•	Rating – double in range [1…10.00] (required)
		[XmlElement("Rating")]
		[Required]
		[Range(1, 10.00)]
		public double Rating { get; set; }

		//•	YearPublished – integer in range [2018…2023] (required)
		[XmlElement("YearPublished")]
		[Required]
		[Range(2018, 2023)]
		public int YearPublished { get; set; }

		//•	CategoryType – enumeration of type CategoryType, with possible values (Abstract, Children, Family, Party, Strategy) (required)
		[XmlElement("CategoryType")]
		[Required]
		public string CategoryType { get; set; } = null!;

		//•	Mechanics – text (string, not an array) (required)
		[XmlElement("Mechanics")]
		[Required]
		public string Mechanics { get; set; } = null!;
	}
}
