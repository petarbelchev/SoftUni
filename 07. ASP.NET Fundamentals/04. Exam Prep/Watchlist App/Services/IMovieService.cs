using Watchlist.Data.Entities;
using Watchlist.Models.Movie;

namespace Watchlist.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<ExportMovieViewModel>> GetAllMoviesAsync(string userId);

        Task<IEnumerable<ExportMovieViewModel>> GetWatchedMoviesByUserIdAsync(string userId);

        Task AddMovie(AddMovieViewModel movieModel);

        Task AddMovieToWatched(string userId, int movieId);

        Task RemoveMovieFromWatched(string userId, int movieId);

        Task<IEnumerable<Genre>> GetGenres();
    }
}
