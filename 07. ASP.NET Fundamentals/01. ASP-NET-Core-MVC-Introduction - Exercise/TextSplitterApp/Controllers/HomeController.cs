using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TextSplitterApp.Models;

namespace TextSplitterApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index(TextViewModel model)
		{
			return View(model);
		}

		public IActionResult Split(TextViewModel model)
		{
			string[] splitedText = model.Text
				.Split(" ", StringSplitOptions.RemoveEmptyEntries);

			model.SplitText = string.Join(Environment.NewLine, splitedText);

			return RedirectToAction("Index", model);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}