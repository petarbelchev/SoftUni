using Microsoft.AspNetCore.Identity;

namespace Watchlist.Data.Entities
{
	public class User : IdentityUser
	{
		public ICollection<UserMovie> WatchedMovies { get; set; }
			= new HashSet<UserMovie>();
	}
}
