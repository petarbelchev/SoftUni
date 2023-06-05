using System.ComponentModel.DataAnnotations;
using static Watchlist.Common.EntitiesConstants.GenreConstants;

namespace Watchlist.Data.Models
{
	public class Genre
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Movie> Movies { get; set; }
			= new HashSet<Movie>();
    }
}
