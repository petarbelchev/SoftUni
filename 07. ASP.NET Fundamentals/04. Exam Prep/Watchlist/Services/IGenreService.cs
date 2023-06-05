using Watchlist.Models;

namespace Watchlist.Services
{
	public interface IGenreService
	{
		Task<IEnumerable<GenreViewModel>> GetGenresAsync();
	}
}
