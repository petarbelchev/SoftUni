namespace ProductShop.Dtos.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Category")]
    public class ImportCategoryDTO
    {
        [XmlElement("name")]
        [Required]
        public string Name { get; set; }
    }
}
