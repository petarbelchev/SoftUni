using SoftJail.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.DataProcessor.ImportDto
{
	public class ImportPrisonerDto
	{
		[Required]
		[StringLength(20, MinimumLength = 3)]
		public string FullName { get; set; } = null!;

		[Required]
		[RegularExpression("^The [A-Z][a-z]+$")]
		public string Nickname { get; set; } = null!;

		[Required]
		[Range(18, 65)]
		public int Age { get; set; }

		[Required]
		public string IncarcerationDate { get; set; } = null!;

		public string ReleaseDate { get; set; } = null!;

		[Range(0, double.MaxValue)] //NOTE: May not correct!
		public decimal? Bail { get; set; }

		[ForeignKey(nameof(Cell))]
		public int? CellId { get; set; }

		public ICollection<ImportMailDto> Mails { get; set; }
			= new HashSet<ImportMailDto>();

		public ICollection<OfficerPrisoner> PrisonerOfficers { get; set; }
			= new HashSet<OfficerPrisoner>();
	}
}
