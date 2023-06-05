using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Watchlist.Common.EntitiesConstants.MovieConstants;

namespace Watchlist.Data.Models
{
	public class Movie
	{
		[Key]
        public int Id { get; set; }

		[Required]
		[MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

		[Required]
		[MaxLength(DirectorMaxLength)]
        public string Director { get; set; } = null!;

		[Required]
        public string ImageUrl { get; set; } = null!;

		[Required]
		[Range(MinRating, MaxRating)]
        public decimal Rating { get; set; }

		[Required]
		[ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }

        public Genre Genre { get; set; } = null!;

        public ICollection<UserMovie> UsersMovies { get; set; }
			= new HashSet<UserMovie>();
    }
}
