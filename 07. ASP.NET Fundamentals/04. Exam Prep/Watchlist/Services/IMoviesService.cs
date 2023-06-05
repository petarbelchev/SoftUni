using Watchlist.Models;

namespace Watchlist.Services
{
	public interface IMoviesService
	{
		Task<IEnumerable<MovieViewModel>> GetMoviesAsync();

		Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userId);

		Task AddMovieAsync(AddMovieFormModel model);
		
        /// <summary>
        /// Throws Invalid Operation Exception when Movie Id or User Id are invalid.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
		Task AddToWatched(int movieId, string userId);
		
		Task RemoveFromWatched(int movieId, string userId);
	}
}
