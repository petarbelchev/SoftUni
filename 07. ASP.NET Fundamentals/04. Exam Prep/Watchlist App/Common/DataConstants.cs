namespace Watchlist.Common
{
	public class DataConstants
	{
		public class User
		{
			public const int UserUserNameMaxLength = 20;
			public const int UserUserNameMinLength = 5;

			public const int UserEmailMaxLength = 60;
			public const int UserEmailMinLength = 10;

			public const int UserPasswordMaxLength = 20;
			public const int UserPasswordMinLength = 5;
		}

		public class Movie
		{
			public const int MovieTitleMaxLength = 50;
			public const int MovieTitleMinLength = 10;

			public const int MovieDirectorMaxLength = 50;
			public const int MovieDirectorMinLength = 5;

			public const double MovieRatingMaxLength = 10.00;
			public const double MovieRatingMinLength = 0.00;
		}

		public class Genre
		{
			public const int GenreNameMaxLength = 50;
			public const int GenreNameMinLength = 5;
		}
	}
}
