using ForumApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Data
{
	public class ForumAppDbContext : DbContext
	{
		public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
			: base(options)
		{ }

		public DbSet<Post> Posts { get; set; }

		private Post FirstPost { get; set; } = null!;

		private Post SecondPost { get; set; } = null!;

		private Post ThirdPost { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			SeedPosts();

			modelBuilder.Entity<Post>()
				.HasData(this.FirstPost, this.SecondPost, this.ThirdPost);

			base.OnModelCreating(modelBuilder);
		}

		private void SeedPosts()
		{
			this.FirstPost = new Post()
			{
				Id = 1,
				Title = "My First Post",
				Content = "My first post will be about performing CRUD operations in MVC. It's so much fun!"
			};

			this.SecondPost = new Post()
			{
				Id = 2,
				Title = "My Second Post",
				Content = "This is my second post. CRUD operations in MVC are getting more and more intresting!"
			};

			this.ThirdPost = new Post()
			{
				Id = 3,
				Title = "My third post",
				Content = "Hello there! I'm getting better and better with the CRUD operations in MVC. Stay tuned!"
			};
		}
	}
}
