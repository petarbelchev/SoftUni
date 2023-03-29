using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
	[XmlType("Manufacturer")]
	public class ImportManufacturerDTO
	{
		[XmlElement("ManufacturerName")]
		[Required]
		[StringLength(40, MinimumLength = 4)] // unique
		public string ManufacturerName { get; set; } = null!;

		[XmlElement("Founded")]
		[Required]
		[StringLength(100, MinimumLength = 10)]
		public string Founded { get; set; } = null!;
	}
}
