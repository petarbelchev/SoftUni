namespace ProductShop.Dtos.Export.User
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("User")]
    public class ExpUserSoldProdLongDTO
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        [Required]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement("SoldProducts")]
        public ExpSoldProdLongDTO SoldProducts { get; set; }
    }
}
