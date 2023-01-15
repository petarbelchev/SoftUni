using ForumApp.Data.Repositories.Contracts;
using ForumApp.Models.DTOs;
using ForumApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Data.Repositories
{
	public class PostRepository : IPostRepository
	{
		private readonly ForumAppDbContext context;

		public PostRepository(ForumAppDbContext context)
		{
			this.context = context;
		}

		public async Task AddPost(PostDTO postDTO)
		{
			context.Posts.Add(new Post
			{
				Title = postDTO.Title,
				Content = postDTO.Content
			});

			await context.SaveChangesAsync();
		}

		public async Task DeletePostById(int id)
		{
			Post post = context.Posts.Find(id) ??
				throw new ArgumentNullException($"Post with id {id} doesn't exist!");

			context.Remove(post);
			await context.SaveChangesAsync();
		}

		public async Task EditPost(PostDTO postDTO)
		{
			Post post = await context.Posts.FirstOrDefaultAsync(p => p.Id == postDTO.Id) ??
				throw new ArgumentNullException($"Post with id {postDTO.Id} does not exist!");

			post.Title = postDTO.Title;
			post.Content = postDTO.Content;
			
			await context.SaveChangesAsync();
		}

		public async Task<IEnumerable<PostDTO>> GetAllPosts()
		{
			PostDTO[] postDTOs = await context.Posts
				.Select(p => new PostDTO
				{
					Id = p.Id,
					Title = p.Title,
					Content = p.Content
				}).ToArrayAsync();

			return postDTOs;
		}

		public async Task<PostDTO> GetPostById(int id)
		{
			Post post = await context.Posts.FirstOrDefaultAsync(p => p.Id == id) ??
				throw new ArgumentNullException($"Post with id {id} does not exist!");

			return new PostDTO
			{
				Id = post.Id,
				Title = post.Title,
				Content = post.Content
			};
		}
	}
}
