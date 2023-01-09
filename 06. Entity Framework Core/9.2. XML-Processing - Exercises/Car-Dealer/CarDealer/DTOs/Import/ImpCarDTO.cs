namespace CarDealer.DTOs.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Car")]
    public class ImpCarDTO
    {
        [XmlElement("make")]
        [Required]
        public string Make { get; set; }

        [XmlElement("model")]
        [Required]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public ImpPardIdDTO[] PartsIds { get; set; }
    }
}
