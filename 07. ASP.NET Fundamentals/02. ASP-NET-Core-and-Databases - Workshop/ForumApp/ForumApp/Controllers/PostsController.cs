using ForumApp.Core.Contracts;
using ForumApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
	public class PostsController : Controller
	{
		private readonly IPostService service;

		public PostsController(IPostService postService)
		{
			this.service = postService;
		}

		public IActionResult Index()
		{
			return RedirectToAction(nameof(All));
		}

		public async Task<IActionResult> All()
		{
			return View(await service.GetAllPosts());
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(PostFormModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			await service.AddPost(model);

			return RedirectToAction(nameof(All));
		}

		public async Task<IActionResult> Edit(int id)
		{
			return View(await service.GetPostById(id));
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, PostFormModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			await service.EditPost(id, model);

			return RedirectToAction(nameof(All));
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			await service.DeletePostById(id);

			return RedirectToAction(nameof(All));
		}
	}
}
