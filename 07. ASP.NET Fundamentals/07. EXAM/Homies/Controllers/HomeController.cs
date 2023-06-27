using Homies.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers
{
	public class HomeController : Controller
    {
        public IActionResult Index() => this.User.IsAuthenticated()
            ? this.RedirectToAction("All", "Event")
            : this.View();

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}