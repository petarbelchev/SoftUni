using ForumApp.Core.Contracts;
using ForumApp.Data.Repositories.Contracts;
using ForumApp.Models.DTOs;
using ForumApp.Models.ViewModels;

namespace ForumApp.Core.Services
{
	public class PostService : IPostService
	{
		private readonly IPostRepository repo;

		public PostService(IPostRepository repo)
		{
			this.repo = repo;
		}

		public async Task AddPost(PostFormModel model)
		{
			PostDTO newPost = new PostDTO
			{
				Title = model.Title,
				Content = model.Content
			};

			await repo.AddPost(newPost);
		}

		public async Task DeletePostById(int postId)
		{
			await repo.DeletePostById(postId);
		}

		public async Task EditPost(int id, PostFormModel model)
		{
			await repo.EditPost(new PostDTO
			{
				Id = id,
				Title = model.Title,
				Content = model.Content
			});
		}

		public async Task<IEnumerable<PostViewModel>> GetAllPosts()
		{
			var posts = await repo.GetAllPosts();

			return posts.Select(p => new PostViewModel
			{
				Id = p.Id,
				Title = p.Title,
				Content = p.Content
			});
		}

		public async Task<PostFormModel> GetPostById(int id)
		{
			PostDTO post = await repo.GetPostById(id);

			return new PostFormModel
			{
				Title = post.Title,
				Content = post.Content
			};
		}
	}
}
