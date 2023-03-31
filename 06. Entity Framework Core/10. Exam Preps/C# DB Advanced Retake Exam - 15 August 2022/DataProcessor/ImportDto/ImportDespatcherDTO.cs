using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Data.Models;

namespace Trucks.DataProcessor.ImportDto
{
	[XmlType("Despatcher")]
	public class ImportDespatcherDTO
	{
		//•	Name – text with length [2, 40] (required)
		[XmlElement("Name")]
		[Required]
		[StringLength(40, MinimumLength = 2)]
		public string Name { get; set; } = null!;

		//•	Position – text
		[XmlElement("Position")]
		[Required]
		public string Position { get; set; } = null!;

		//•	Trucks – collection of type Truck
		[XmlArray("Trucks")]
		public ImportTruckDTO[] Trucks { get; set; } = null!;
	}
}
