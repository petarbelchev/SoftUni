using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVC_Intro_Demo.Models;
using System.Text;
using System.Text.Json;

namespace MVC_Intro_Demo.Controllers
{
	public class ProductsController : Controller
	{
		private IEnumerable<ProductViewModel> products = new List<ProductViewModel>()
		{
			new ProductViewModel
			{
				Id = 1,
				Name = "Cheese",
				Price = 7.00
			},
			new ProductViewModel
			{
				Id = 2,
				Name = "Ham",
				Price = 5.50
			},
			new ProductViewModel
			{
				Id = 3,
				Name = "Bread",
				Price = 1.50
			}
		};

		public IActionResult Index()
		{
			return View();
		}

		[ActionName("My-Products")]
		public IActionResult All(string keyword)
		{
			if (keyword != null)
			{
				return View(products
					.Where(p => p.Name.ToLower()
						.Contains(keyword.ToLower())));
			}

			return View(products);
		}

		public IActionResult ById(int id)
		{
			ProductViewModel product = products
				.FirstOrDefault(p => p.Id == id);

			if (product == default)
			{
				return BadRequest();
			}

			return View(product);
		}

		public IActionResult AllAsJson()
		{
			return Json(products, new JsonSerializerOptions
			{
				WriteIndented = true
			});
		}

		public IActionResult AllAsText()
		{
			var sb = new StringBuilder();

			foreach (var p in products)
				sb.AppendLine($"Product {p.Id}: {p.Name} - {p.Price}lv");

			return Content(sb.ToString().TrimEnd());
		}

		public IActionResult AllAsTextFile()
		{
			var sb = new StringBuilder();

			foreach (var p in products)
				sb.AppendLine($"Product {p.Id}: {p.Name} - {p.Price}lv");

			Response.Headers.Add(
				HeaderNames.ContentDisposition, 
				@"attachment;filename=product.txt");

			return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
		}
	}
}
