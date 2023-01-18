namespace TaskBoardApp.Data
{
	class DataConstants
	{
		internal class User
		{
			internal const int UserFirstNameMaxLength = 15;
			internal const int UserLastNameMaxLength = 15;
			internal const int UserUsernameMaxLength = 15;
		}

		internal class Task
		{
			internal const int TaskTitleMaxLength = 70;
			internal const int TaskTitleMinLength = 5;

			internal const int TaskDescriptionMaxLength = 1000;
			internal const int TaskDescriptionMinLength = 10;
		}

		internal class Board
		{
			internal const int BoardNameMaxLength = 30;
			internal const int BoardNameMinLength = 3;
		}
	}
}
