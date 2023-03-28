using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models
{
	public class Prisoner
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(20)]
		public string FullName { get; set; } = null!;

		[Required]
		public string Nickname { get; set; } = null!;

		[Required]
		[Range(18, 65)]
		public int Age { get; set; }

		[Required]
		public DateTime IncarcerationDate { get; set; }

		public DateTime? ReleaseDate { get; set; }

		[Range(0, double.MaxValue)]
		public decimal? Bail { get; set; }

		[ForeignKey(nameof(Cell))]
		public int CellId { get; set; }

		public Cell Cell { get; set; } = null!;

		public ICollection<Mail> Mails { get; set; }
			= new HashSet<Mail>();

		public ICollection<OfficerPrisoner> PrisonerOfficers { get; set; }
			= new HashSet<OfficerPrisoner>();
	}
}
