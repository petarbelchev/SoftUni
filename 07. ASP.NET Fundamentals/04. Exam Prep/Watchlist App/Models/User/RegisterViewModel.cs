using System.ComponentModel.DataAnnotations;
using static Watchlist.Common.DataConstants.User;

namespace Watchlist.Models.User
{
    public class RegisterViewModel
    {
        [StringLength(UserUserNameMaxLength, MinimumLength = UserUserNameMinLength)]
        public string UserName { get; set; } = null!;

        [EmailAddress]
        [StringLength(UserEmailMaxLength, MinimumLength = UserEmailMinLength)]
        public string Email { get; set; } = null!;

        [StringLength(UserPasswordMaxLength, MinimumLength = UserUserNameMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [StringLength(UserPasswordMaxLength, MinimumLength = UserUserNameMinLength)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
