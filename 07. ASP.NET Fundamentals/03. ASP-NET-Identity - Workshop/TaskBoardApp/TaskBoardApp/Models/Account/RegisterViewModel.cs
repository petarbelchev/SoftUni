using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstants.User;

namespace TaskBoardApp.Models.Account
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(UserUsernameMaxLength, MinimumLength = UserUsernameMinLength)]
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [StringLength(UserPasswordMaxLength, MinimumLength = UserPasswordMinLength)]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [StringLength(UserPasswordMaxLength, MinimumLength = UserPasswordMinLength)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        [StringLength(UserFirstNameMaxLength, MinimumLength = UserFirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(UserLastNameMaxLength, MinimumLength = UserLastNameMinLength)]
        public string LastName { get; set; } = null!;
    }
}
