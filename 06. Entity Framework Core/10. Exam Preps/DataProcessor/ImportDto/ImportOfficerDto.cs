using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
	[XmlType("Officer")]
	public class ImportOfficerDto
	{
		[XmlElement("Name")]
		//[Required]
		//[StringLength(30, MinimumLength = 3)]
		public string FullName { get; set; } = null!;

		[XmlElement("Money")]
		//[Required]
		//[Range(0, double.MaxValue)] //NOTE: May not correct!
		public decimal Salary { get; set; }
		
		[XmlElement("Position")]
		//[Required]
		public string Position { get; set; } = null!;
		
		[XmlElement("Weapon")]
		//[Required]
		public string Weapon { get; set; } = null!;
		
		[XmlElement("DepartmentId")]
		//[Required]
		//[ForeignKey(nameof(Department))]
		public int DepartmentId { get; set; }
		
		[XmlArray("Prisoners")]
		//[Required]
        public ImportPrisonerIdDto[] OfficerPrisoners { get; set; } = null!;
    }
}
