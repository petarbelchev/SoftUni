using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstants.User;

namespace TaskBoardApp.Models.Account
{
	public class LoginViewModel
	{
		[Required]
		[StringLength(UserUsernameMaxLength, MinimumLength = UserUsernameMinLength)]
		public string Username { get; set; } = null!;

		[Required]
		[StringLength(UserPasswordMaxLength, MinimumLength = UserPasswordMinLength)]
		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;
	}
}
