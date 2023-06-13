using Library.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() 
            => this.User.IsAuthenticated()
                ? this.RedirectToAction("All", "Books")
                : this.View();
    }
}