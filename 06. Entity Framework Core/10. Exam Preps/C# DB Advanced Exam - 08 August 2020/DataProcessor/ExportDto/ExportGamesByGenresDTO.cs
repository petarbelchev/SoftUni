namespace VaporStore.DataProcessor.ExportDto
{
	public class ExportGamesByGenresDTO
	{
        public int Id { get; set; }

        public string Genre { get; set; } = null!;

        public IEnumerable<ExportGameDTO> Games { get; set; } = null!;

        public int TotalPlayers { get; set; }
    }
}
