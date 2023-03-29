using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
	[XmlType("Play")]
	public class ImportPlayDTO
	{
		[XmlElement("Title")]
		[Required]
		[MinLength(4)]
        public string Title { get; set; } = null!;

        //format {hours:minutes:seconds}, with a minimum length of 1 hour
		// to be checked!!! Duration of the play is less than 1 (one) hour is invalid
		[XmlElement("Duration")]
		[Required]
		public string Duration { get; set; } = null!;

		[XmlElement("Raiting")]
		[Required]
		[Range(0.00, 10.00)]
		public float Rating { get; set; }
				
		[XmlElement("Genre")]
		[Required]
		public string Genre { get; set; } = null!;
		
		[XmlElement("Description")]
		[Required]
		[MaxLength(700)]
		public string Description { get; set; } = null!;
		
		[XmlElement("Screenwriter")]
		[Required]
		[MinLength(4)]
        public string Screenwriter { get; set; } = null!;
    }
}
