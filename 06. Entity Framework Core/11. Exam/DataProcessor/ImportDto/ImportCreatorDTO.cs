using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
	[XmlType("Creator")]
	public class ImportCreatorDTO
	{
		//•	FirstName – text with length [2, 7] (required) 
		[XmlElement("FirstName")]
		[Required]
		[StringLength(7, MinimumLength = 2)]
		public string FirstName { get; set; } = null!;

		//•	LastName – text with length [2, 7] (required)
		[XmlElement("LastName")]
		[Required]
		[StringLength(7, MinimumLength = 2)]
		public string LastName { get; set; } = null!;

		//•	Boardgames – collection of type Boardgame
		[XmlArray("Boardgames")]
		public ImportBoardgameDTO[] Boardgames { get; set; } = null!;
	}
}
