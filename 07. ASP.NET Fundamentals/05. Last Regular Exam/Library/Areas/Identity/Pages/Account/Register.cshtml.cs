#nullable disable

using Library.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using static Library.Constants.ApplicationsUserConstants;

namespace Library.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;

        public RegisterModel(UserManager<ApplicationUser> userManager) 
            => this.userManager = userManager;

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength,
                ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
            public string UserName { get; set; }

            [Required]
            [StringLength(EmailMaxLength, MinimumLength = EmailMinLength,
                ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength,
                ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public IActionResult OnGetAsync()
            => this.User.Identity?.IsAuthenticated ?? false 
                ? this.LocalRedirect("/") 
                : this.Page();

        public async Task<IActionResult> OnPostAsync()
        {
            if (this.ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = this.Input.UserName,
                    Email = this.Input.Email
                };

                IdentityResult result = await this.userManager.CreateAsync(user, this.Input.Password);

                if (result.Succeeded)
                {
                    return this.RedirectToPage("Login");
                }

                foreach (IdentityError error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return this.Page();
        }
    }
}
