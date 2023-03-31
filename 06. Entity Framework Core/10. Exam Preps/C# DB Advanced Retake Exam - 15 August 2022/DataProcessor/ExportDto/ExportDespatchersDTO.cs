using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto
{
	[XmlType("Despatcher")]
	public class ExportDespatchersDTO
	{
		[XmlAttribute("TrucksCount")]
        public string TrucksCount { get; set; } = null!;

		[XmlElement("DespatcherName")]
        public string DespatcherName { get; set; } = null!;

		[XmlArray("Trucks")]
        public ExportTruckDTO[] Trucks { get; set; } = null!;
    }
}
