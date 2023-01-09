namespace CarDealer.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("part")]
    public class ExpPartDTO
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}
