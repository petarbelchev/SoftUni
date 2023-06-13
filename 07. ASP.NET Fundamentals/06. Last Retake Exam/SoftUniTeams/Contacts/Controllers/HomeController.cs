using Contacts.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index() => this.User.IsAuthenticated() 
            ? this.RedirectToAction("All", "Contacts") 
            : this.View();
	}
}