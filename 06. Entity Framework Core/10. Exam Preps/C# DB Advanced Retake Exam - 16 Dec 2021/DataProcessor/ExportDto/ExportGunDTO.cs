using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
	[XmlType("Gun")]
	public class ExportGunDTO
	{
		[XmlAttribute("Manufacturer")]
        public string Manufacturer { get; set; } = null!;

		[XmlAttribute("GunType")]
        public string GunType { get; set; } = null!;
		
		[XmlAttribute("GunWeight")]
        public string GunWeight { get; set; } = null!;
		
		[XmlAttribute("BarrelLength")]
        public string BarrelLength { get; set; }  = null!;

		[XmlAttribute("Range")]
        public string Range { get; set; } = null!;

		[XmlArray("Countries")]
        public ExportCountryDTO[] Countries { get; set; } = null!;
    }
}
