namespace ProductShop.Dtos.Export.User
{
    using System.Xml;
    using System.Xml.Serialization;

    [XmlType("SoldProducts")]
    public class ExpSoldProdLongDTO
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public ExpSoldProdDTO[] Products { get; set; }
    }
}
