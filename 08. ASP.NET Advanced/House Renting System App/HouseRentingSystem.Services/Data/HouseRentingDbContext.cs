using HouseRentingSystem.Services.Data.Configurations;
using HouseRentingSystem.Services.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Services.Data
{
	public class HouseRentingDbContext : IdentityDbContext<User>
	{
		private bool seedDb;

		public HouseRentingDbContext(DbContextOptions<HouseRentingDbContext> options, bool seed = true)
			: base(options)
		{
			if (Database.IsRelational())
				Database.Migrate();
			else
				Database.EnsureCreated();

			seedDb = seed;
		}

		public DbSet<Agent> Agents { get; init; } = null!;

		public DbSet<Category> Categories { get; init; } = null!;

		public DbSet<House> Houses { get; init; } = null!;

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<House>()
				.HasOne(h => h.Category)
				.WithMany(c => c.Houses)
				.HasForeignKey(h => h.CategoryId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<House>()
				.HasOne(h => h.Agent)
				.WithMany()
				.HasForeignKey(h => h.AgentId)
				.OnDelete(DeleteBehavior.Restrict);

			if (seedDb)
			{
				builder.ApplyConfiguration(new UserEntityTypeConfiguration());
				builder.ApplyConfiguration(new AgentEntityTypeConfiguration());
				builder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
				builder.ApplyConfiguration(new HouseEntityTypeConfiguration());
			}
		}
	}
}