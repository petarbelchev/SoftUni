using Microsoft.EntityFrameworkCore;
using Watchlist.Data;
using Watchlist.Data.Models;
using Watchlist.Models;

namespace Watchlist.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly WatchlistDbContext dbContext;

        public MoviesService(WatchlistDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddMovieAsync(AddMovieFormModel model)
        {
            Movie movie = new Movie
            {
                Title = model.Title,
                Director = model.Director,
                GenreId = model.GenreId,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating
            };

            await dbContext.Movies.AddAsync(movie);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Throws Invalid Operation Exception when Movie Id or User Id are invalid.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task AddToWatched(int movieId, string userId)
        {
            bool isMovieExist = await dbContext.Movies
                .AnyAsync(x => x.Id == movieId);

            if (!isMovieExist)
            {
                throw new InvalidOperationException("Invalid Movie Id.");
            }

            bool isUserExist = await dbContext.Users
                .AnyAsync(x => x.Id == userId);

            if (!isUserExist)
            {
                throw new InvalidOperationException("Invalid User Id.");
            }

            bool isMovieWatched = await dbContext.UsersMovies
                .AnyAsync(x => x.UserId == userId && x.MovieId == movieId);

            if (!isMovieWatched)
            {
                await dbContext.UsersMovies
                    .AddAsync(new UserMovie
                    {
                        UserId = userId,
                        MovieId = movieId
                    });

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MovieViewModel>> GetMoviesAsync()
        {
            var movies = await dbContext.Movies
                .Select(m => new MovieViewModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    Director = m.Director,
                    ImageUrl = m.ImageUrl,
                    Genre = m.Genre.Name,
                    Rating = m.Rating
                })
                .ToArrayAsync();

            return movies;
        }

        public async Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userId)
        {
            var movies = await dbContext.UsersMovies
                .Where(x => x.UserId == userId)
                .Select(x => new MovieViewModel
                {
                    Id = x.Movie.Id,
                    Title = x.Movie.Title,
                    Director = x.Movie.Director,
                    ImageUrl = x.Movie.ImageUrl,
                    Genre = x.Movie.Genre.Name,
                    Rating = x.Movie.Rating
                })
                .ToArrayAsync();

            return movies;
        }

        public async Task RemoveFromWatched(int movieId, string userId)
        {
            UserMovie? userMovie = await dbContext.UsersMovies
                .Where(x => x.UserId == userId && x.MovieId == movieId)
                .FirstOrDefaultAsync();

            if (userMovie != null)
            {
                dbContext.UsersMovies.Remove(userMovie);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
