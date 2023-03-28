using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
	[XmlType("Task")]
	public class ImportTaskDTO
	{
		[XmlElement("Name")]
		[Required]
		[StringLength(40, MinimumLength = 2)]
        public string Name { get; set; } = null!;

		[XmlElement("OpenDate")]
		[Required]
        public string OpenDate { get; set; } = null!;

		[XmlElement("DueDate")]
		[Required]
        public string DueDate { get; set; } = null!;

		[XmlElement("ExecutionType")]
		[Range(0, 3)]
		public int ExecutionType { get; set; }

		[XmlElement("LabelType")]
		[Range(0, 4)]
		public int LabelType { get; set; }
	}
}
