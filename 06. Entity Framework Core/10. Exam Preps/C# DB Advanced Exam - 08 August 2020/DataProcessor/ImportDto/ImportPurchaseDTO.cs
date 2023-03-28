using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.ImportDto
{
	[XmlType("Purchase")]
	public class ImportPurchaseDTO
	{
        [Required]
        [XmlAttribute("title")]
        public string Game { get; set; } = null!;

        //•	Type – enumeration of type PurchaseType, with possible values ("Retail", "Digital") (required) 
        [Required]
        [XmlElement("Type")]
        public string Type { get; set; } = null!;

        //•	ProductKey – text, which consists of 3 pairs of 4 uppercase Latin letters and digits, separated by dashes (ex. "ABCD-EFGH-1J3L") (required)
        [Required]
        [XmlElement("Key")]
        [RegularExpression(@"^[A-Z\d]{4}-[A-Z\d]{4}-[A-Z\d]{4}$")]
        public string ProductKey { get; set; } = null!;

        //•	Date – Date (required)
        [Required]
        [XmlElement("Date")]
        public string Date { get; set; } = null!;

        //•	Card – the purchase's card (required)
        [Required]
        [XmlElement("Card")]
        public string Card { get; set; } = null!;
	}
}
