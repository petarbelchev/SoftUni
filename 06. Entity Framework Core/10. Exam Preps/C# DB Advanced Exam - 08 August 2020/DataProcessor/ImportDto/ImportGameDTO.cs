using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.ImportDto
{
	public class ImportGameDTO
	{
		//•	Name – text (required)
		[Required]
		public string Name { get; set; } = null!;

		//•	Price – decimal (non-negative, minimum value: 0) (required)
		[Required]
		[Range(0, double.MaxValue)]
		public decimal Price { get; set; }

		//•	ReleaseDate – Date (required)
		[Required]
		public string ReleaseDate { get; set; } = null!;

		//•	Developer – the game's developer (required)
		[Required]
		public string Developer { get; set; } = null!;

		//•	Genre – the game's genre (required)
		[Required]
		public string Genre { get; set; } = null!;

		//•	GameTags - collection of type GameTag. Each game must have at least one tag.
		public ICollection<string> Tags { get; set; }
			= new HashSet<string>();
    }
}
