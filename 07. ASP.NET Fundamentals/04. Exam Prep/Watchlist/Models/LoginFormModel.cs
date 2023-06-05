using System.ComponentModel.DataAnnotations;
using static Watchlist.Common.EntitiesConstants.UserConstants;

namespace Watchlist.Models
{
	public class LoginFormModel
	{
		[Required]
		[StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength,
			ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
		[Display(Name = "Username")]
		public string UserName { get; set; } = null!;

		[Required]
		[StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength,
			ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;
	}
}
