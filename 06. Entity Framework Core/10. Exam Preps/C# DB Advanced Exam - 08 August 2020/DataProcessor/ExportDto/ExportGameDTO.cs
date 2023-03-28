namespace VaporStore.DataProcessor.ExportDto
{
	public class ExportGameDTO
	{
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Developer { get; set; } = null!;

        public string Tags { get; set; } = null!;

        public int Players { get; set; }
    }
}
