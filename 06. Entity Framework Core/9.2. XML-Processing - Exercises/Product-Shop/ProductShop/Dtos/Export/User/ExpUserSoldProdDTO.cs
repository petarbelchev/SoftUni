namespace ProductShop.Dtos.Export.User
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("User")]
    public class ExpUserSoldProdDTO
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        [Required]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public ExpSoldProdDTO[] SoldProducts { get; set; }
    }
}
