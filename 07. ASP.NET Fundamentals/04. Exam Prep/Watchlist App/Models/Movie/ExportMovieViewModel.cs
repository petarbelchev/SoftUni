using System.ComponentModel.DataAnnotations;

namespace Watchlist.Models.Movie
{
    public class ExportMovieViewModel
    {
		public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Director { get; set; } = null!;

        public decimal Rating { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public bool IsWatched { get; set; }
    }
}
