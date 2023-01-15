using ForumApp.Data;
using ForumApp.Data.Models;
using ForumApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
	public class PostsController : Controller
	{
		private readonly ForumAppDbContext context;

		public PostsController(ForumAppDbContext context)
		{
			this.context = context;
		}

		public IActionResult Index()
		{
			return RedirectToAction(nameof(All));
		}

		public IActionResult All()
		{
			PostViewModel[] posts = context.Posts
				.Select(p => new PostViewModel
				{
					Id = p.Id,
					Title= p.Title,
					Content = p.Content
				}).ToArray();

			return View(posts);
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(PostFormModel model)
		{
			Post newPost = new Post
			{
				Title = model.Title,
				Content = model.Content
			};

			context.Posts.Add(newPost);
			context.SaveChanges();

			return RedirectToAction(nameof(All));
		}

		public IActionResult Edit(int id)
		{
			Post post = context.Posts.Find(id) ?? 
				throw new ArgumentNullException($"Post with id {id} doesn't exist!");

			PostFormModel postFormModel = new PostFormModel
			{
				Title = post.Title,
				Content = post.Content
			};

			return View(postFormModel);
		}

		[HttpPost]
		public IActionResult Edit(int id, PostFormModel model)
		{
			Post editedPost = context.Posts.Find(id) ?? 
				throw new ArgumentNullException($"Post with id {id} doesn't exist!");

			editedPost.Title = model.Title;
			editedPost.Content = model.Content;

			context.SaveChanges();

			return RedirectToAction(nameof(All));
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			Post post = context.Posts.Find(id) ??
				throw new ArgumentNullException($"Post with id {id} doesn't exist!");

			context.Remove(post);
			context.SaveChanges();

			return RedirectToAction(nameof(All));
		}
	}
}
