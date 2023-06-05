namespace Watchlist.Common
{
	public static class EntitiesConstants
	{
		public static class UserConstants
		{
			public const int UserNameMaxLength = 20;
			public const int UserNameMinLength = 5;

			public const int EmailMaxLength = 60;
			public const int EmailMinLength = 10;

			public const int PasswordMaxLength = 20;
			public const int PasswordMinLength = 5;
		}

		public static class MovieConstants
		{
            public const int TitleMaxLength = 50;
            public const int TitleMinLength = 10;

            public const int DirectorMaxLength = 50;
            public const int DirectorMinLength = 5;

			public const double MaxRating = 10.00;
			public const double MinRating = 0.00;
        }

		public static class GenreConstants
		{
			public const int NameMaxLength = 50;
			public const int NameMinLength = 5;
		}
	}
}
