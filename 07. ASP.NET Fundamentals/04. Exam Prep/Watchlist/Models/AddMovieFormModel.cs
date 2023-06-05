using System.ComponentModel.DataAnnotations;
using static Watchlist.Common.EntitiesConstants.MovieConstants;

namespace Watchlist.Models
{
	public class AddMovieFormModel
	{
		[Required]
		[StringLength(TitleMaxLength, MinimumLength = TitleMinLength,
			ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        public string Title { get; set; } = null!;
		
		[Required]
		[StringLength(DirectorMaxLength, MinimumLength = DirectorMinLength,
			ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        public string Director { get; set; } = null!;
		
		[Required]
        public string ImageUrl { get; set; } = null!;
		
		[Required]
		[Range(MinRating, MaxRating,
			ErrorMessage = "The {0} must be at least {2} and at max {1}.")]
        public decimal Rating { get; set; }
		
		[Required]
		[Display(Name = "Genre")]
        public int GenreId { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; }
			= new HashSet<GenreViewModel>();
    }
}
