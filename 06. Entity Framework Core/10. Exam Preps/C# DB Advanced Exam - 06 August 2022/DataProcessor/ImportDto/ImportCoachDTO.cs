using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
	[XmlType("Coach")]
	public class ImportCoachDTO
	{
		//•	Name – text with length [2, 40] (required)
		[XmlElement("Name")]
		[Required]
		[StringLength(40, MinimumLength = 2)]
		public string Name { get; set; } = null!;

		//•	Nationality – text (required)
		[XmlElement("Nationality")]
		[Required]
		public string Nationality { get; set; } = null!;

		//•	Footballers – collection of type Footballer
		[XmlArray("Footballers")]
		public ImportFootballerDTO[] Footballers { get; set; } = null!;
	}
}
