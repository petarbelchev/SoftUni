namespace CarDealer.DTOs.Import
{
    using System.Xml.Serialization;

    [XmlType("partId")]
    public class ImpPardIdDTO
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
