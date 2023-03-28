namespace SoftJail.DataProcessor.ExportDto
{
	public class ExportPrisonerDto
	{
        public int Id { get; set; }

		public string Name { get; set; } = null!;

        public int CellNumber { get; set; }

        public IEnumerable<ExportPrisonerOfficerDto> Officers { get; set; } = null!;

        public decimal TotalOfficerSalary { get; set; }
    }
}
