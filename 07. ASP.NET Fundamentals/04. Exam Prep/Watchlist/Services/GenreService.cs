using Microsoft.EntityFrameworkCore;
using Watchlist.Data;
using Watchlist.Models;

namespace Watchlist.Services
{
	public class GenreService : IGenreService
	{
		private readonly WatchlistDbContext dbContext;

		public GenreService(WatchlistDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IEnumerable<GenreViewModel>> GetGenresAsync()
		{
			var genres = await dbContext.Genres
				.Select(g => new GenreViewModel
				{
					Id = g.Id,
					Name = g.Name
				})
				.ToArrayAsync();

			return genres;
		}
	}
}
