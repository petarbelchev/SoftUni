using System.ComponentModel.DataAnnotations;
using static Watchlist.Common.DataConstants.Genre;

namespace Watchlist.Data.Entities
{
	public class Genre
	{
		public int Id { get; set; }

		[MaxLength(GenreNameMaxLength)]
		public string Name { get; set; } = null!;

		public ICollection<Movie> Movies { get; set; }
			= new HashSet<Movie>();
	}
}
