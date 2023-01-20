using Microsoft.EntityFrameworkCore;
using Watchlist.Data;
using Watchlist.Data.Entities;
using Watchlist.Models.Movie;

namespace Watchlist.Services
{
    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext context;

        public MovieService(WatchlistDbContext context)
        {
            this.context = context;
        }

        public async Task AddMovie(AddMovieViewModel movieModel)
        {
            Movie newMovie = new Movie
            {
                Title = movieModel.Title,
                Director = movieModel.Director,
                ImageUrl = movieModel.ImageUrl,
                Rating = movieModel.Rating,
                GenreId = movieModel.GenreId
            };

            context.Movies.Add(newMovie);
            await context.SaveChangesAsync();
        }

        public async Task AddMovieToWatched(string userId, int movieId)
        {
            User? user = await context.Users.FindAsync(userId);

            if (user == null)
                throw new ArgumentException("User does not exist!");

            if (!context.Movies.Any(m => m.Id == movieId))
                throw new ArgumentException("Movie does not exist!");

            user.WatchedMovies.Add(new UserMovie { MovieId = movieId });

            await context.SaveChangesAsync();
        }

        public async Task RemoveMovieFromWatched(string userId, int movieId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.WatchedMovies)
                .FirstOrDefaultAsync();

            if (user == null)
                throw new ArgumentException("User does not exist!");

            var movie = user.WatchedMovies.FirstOrDefault(m => m.MovieId == movieId);
            
            if (movie == null)
                throw new ArgumentException("Movie does not exist!");

            user.WatchedMovies.Remove(movie);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExportMovieViewModel>> GetAllMoviesAsync(string userId)
        {
            int[] watcherMoviesIds = await GetWatchedMoviesIds(userId);

            return await context.Movies.Select(m => new ExportMovieViewModel
            {
                Id = m.Id,
                Title = m.Title,
                Director = m.Director,
                ImageUrl = m.ImageUrl,
                Rating = m.Rating,
                Genre = m.Genre.Name,
                IsWatched = watcherMoviesIds.Contains(m.Id)
            }).ToArrayAsync();
        }

        public async Task<IEnumerable<Genre>> GetGenres()
            => await context.Genres.ToArrayAsync();

        public async Task<IEnumerable<ExportMovieViewModel>> GetWatchedMoviesByUserIdAsync(string userId)
        {
            int[] moviesIds = await GetWatchedMoviesIds(userId);

            return await context.Movies
                .Where(m => moviesIds.Contains(m.Id))
                .Select(m => new ExportMovieViewModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    Director = m.Director,
                    ImageUrl = m.ImageUrl,
                    Rating = m.Rating,
                    Genre = m.Genre.Name
                })
                .ToArrayAsync();
        }

        private async Task<int[]> GetWatchedMoviesIds(string userId)
        {
            var moviesIds = await context.Users
                .Where(u => u.Id == userId)
                .SelectMany(u => u.WatchedMovies)
                .Select(m => m.MovieId)
                .ToArrayAsync();

            return moviesIds;
        }
    }
}
