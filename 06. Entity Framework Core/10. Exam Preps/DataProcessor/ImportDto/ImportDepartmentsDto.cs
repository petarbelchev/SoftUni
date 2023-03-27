using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
	public class ImportDepartmentsDto
	{
		[Required]
		[StringLength(25, MinimumLength = 3)]
        public string Name { get; set; } = null!;

		[Required]
        public ImportCellDto[] Cells { get; set; } = null!;
	}
}
