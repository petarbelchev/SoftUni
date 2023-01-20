using System.ComponentModel.DataAnnotations;
using Watchlist.Data.Entities;
using static Watchlist.Common.DataConstants.Movie;

namespace Watchlist.Models.Movie
{
    public class AddMovieViewModel
    {
        [StringLength(MovieTitleMaxLength, MinimumLength = MovieTitleMinLength)]
        public string Title { get; set; } = null!;

        [StringLength(MovieDirectorMaxLength, MinimumLength = MovieDirectorMinLength)]
        public string Director { get; set; } = null!;

        [Range(MovieRatingMinLength, MovieRatingMaxLength)]
        public decimal Rating { get; set; }

        public string ImageUrl { get; set; } = null!;

        public int GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
            = new List<Genre>();
    }
}
