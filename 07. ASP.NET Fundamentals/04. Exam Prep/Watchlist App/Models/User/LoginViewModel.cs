using System.ComponentModel.DataAnnotations;
using static Watchlist.Common.DataConstants.User;

namespace Watchlist.Models.User
{
    public class LoginViewModel
    {
        [Display(Name = "Username")]
        [StringLength(UserUserNameMaxLength, MinimumLength = UserUserNameMinLength)]
        public string UserName { get; set; } = null!;

        [DataType(DataType.Password)]
        [StringLength(UserPasswordMaxLength, MinimumLength = UserPasswordMinLength)]
        public string Password { get; set; } = null!;

        public string? ReturnUrl { get; set; }
    }
}
