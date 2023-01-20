using System.ComponentModel.DataAnnotations;
using static Watchlist.Common.DataConstants.Movie;

namespace Watchlist.Data.Entities
{
	public class Movie
	{
		public int Id { get; set; }

		[MaxLength(MovieTitleMaxLength)]
		public string Title { get; set; } = null!;

		[MaxLength(MovieDirectorMaxLength)]
		public string Director { get; set; } = null!;

		public string ImageUrl { get; set; } = null!;

		public decimal Rating { get; set; }

		public int GenreId { get; set; }
		public Genre Genre { get; set; } = null!;

		public ICollection<UserMovie> Users { get; set; }
			= new HashSet<UserMovie>();
	}
}
