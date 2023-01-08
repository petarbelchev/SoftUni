namespace ProductShop.Dtos.Export.User
{
    using System.Xml.Serialization;

    [XmlType("Product")]
    public class ExpSoldProdDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
