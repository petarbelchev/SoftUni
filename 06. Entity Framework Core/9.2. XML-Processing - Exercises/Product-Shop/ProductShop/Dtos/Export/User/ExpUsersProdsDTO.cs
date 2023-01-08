namespace ProductShop.Dtos.Export.User
{
    using System.Xml.Serialization;

    public class ExpUsersProdsDTO
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public ExpUserSoldProdLongDTO[] Users { get; set; }
    }
}
