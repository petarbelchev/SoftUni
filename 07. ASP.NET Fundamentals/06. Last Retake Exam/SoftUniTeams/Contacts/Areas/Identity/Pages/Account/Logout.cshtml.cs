#nullable disable

using Contacts.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Contacts.Areas.Identity.Pages.Account
{
    [Authorize]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LogoutModel(SignInManager<ApplicationUser> signInManager)
            => this._signInManager = signInManager;

        public async Task<IActionResult> OnPost()
        {
            await this._signInManager.SignOutAsync();

            return this.LocalRedirect("/");
        }
    }
}
