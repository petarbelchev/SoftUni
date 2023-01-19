using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data.Entities;

namespace TaskBoardApp.Data
{
	public class TaskBoardAppDbContext : IdentityDbContext<User>
	{
		public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
			: base(options)
		{ }

		public DbSet<TaskEntity> Tasks { get; set; } = null!;

		public DbSet<Board> Boards { get; set; } = null!;

		private User GuestUser { get; set; } = null!;
		private Board OpenBoard { get; set; } = null!;
		private Board InProgressBoard { get; set; } = null!;
		private Board DoneBoard { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder builder)
		{
			SeedUsers();

			builder.Entity<User>()
				.HasData(GuestUser);

			SeedBoards();

			builder.Entity<Board>()
				.HasData(OpenBoard, InProgressBoard, DoneBoard);

			builder.Entity<TaskEntity>()
				.HasData(
				new TaskEntity
				{
					Id = 1,
					Title = "Prepare for ASP.NET Fundamentals exam",
					Description = "Learn using ASP.NET Core Identity",
					CreatedOn = DateTime.Now.AddMonths(-1),
					OwnerId = GuestUser.Id,
					BoardId = OpenBoard.Id
				},
				new TaskEntity
				{
					Id = 2,
					Title = "Improve EF Core skills",
					Description = "Learn using EF Core and MS SQL Server Management Studio",
					CreatedOn = DateTime.Now.AddMonths(-5),
					OwnerId = GuestUser.Id,
					BoardId = DoneBoard.Id
				},
				new TaskEntity
				{
					Id = 3,
					Title = "Improve ASP.NET Core skills",
					Description = "Learn using ASP.NET Core Identity",
					CreatedOn = DateTime.Now.AddDays(-10),
					OwnerId = GuestUser.Id,
					BoardId = InProgressBoard.Id
				},
				new TaskEntity
				{
					Id = 4,
					Title = "Prepare for C# Fundamentals Exam",
					Description = "Prepare by solving old Mid and Final exams",
					CreatedOn = DateTime.Now.AddYears(-1),
					OwnerId = GuestUser.Id,
					BoardId = DoneBoard.Id
				});

			builder.Entity<Board>()
				.HasMany(b => b.Tasks)
				.WithOne(b => b.Board)
				.HasForeignKey(t => t.BoardId)
				.OnDelete(DeleteBehavior.Restrict);

			base.OnModelCreating(builder);
		}

		private void SeedBoards()
		{
			OpenBoard = new Board()
			{
				Id = 1,
				Name = "Open"
			};

			InProgressBoard = new Board()
			{
				Id = 2,
				Name = "In Progress"
			};

			DoneBoard = new Board()
			{
				Id = 3,
				Name = "Done"
			};
		}

		private void SeedUsers()
		{
			var hasher = new PasswordHasher<IdentityUser>();

			GuestUser = new User()
			{
				UserName = "guest",
				NormalizedUserName = "GUEST",
				Email = "guest@mail.com",
				NormalizedEmail = "GUEST@MAIL.COM",
				FirstName = "Guest",
				LastName = "User"
			};

			GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "guest");
		}
	}
}