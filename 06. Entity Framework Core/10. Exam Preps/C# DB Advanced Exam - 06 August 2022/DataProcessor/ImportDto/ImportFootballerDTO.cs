using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
	[XmlType("Footballer")]
	public class ImportFootballerDTO
	{
		//•	Name – text with length [2, 40] (required)
		[XmlElement("Name")]
		[Required]
		[StringLength(40, MinimumLength = 2)]
		public string Name { get; set; } = null!;

		//•	ContractStartDate – date and time (required)
		[XmlElement("ContractStartDate")]
		[Required]
		public string ContractStartDate { get; set; } = null!;

		//•	ContractEndDate – date and time (required)
		[XmlElement("ContractEndDate")]
		[Required]
		public string ContractEndDate { get; set; } = null!;

		//•	Position - enumeration of type PositionType, with possible values (Goalkeeper, Defender, Midfielder, Forward) (required)
		[XmlElement("PositionType")]
		[Required]
		public string PositionType { get; set; } = null!;

		//•	BestSkill – enumeration of type BestSkillType, with possible values (Defence, Dribble, Pass, Shoot, Speed) (required)
		[XmlElement("BestSkillType")]
		[Required]
		public string BestSkillType { get; set; } = null!;
	}
}
