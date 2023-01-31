using HouseRentingSystem.Services.Data.Configurations;
using HouseRentingSystem.Services.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Services.Data
{
	public class HouseRentingDbContext : IdentityDbContext<User>
	{
		public HouseRentingDbContext(DbContextOptions<HouseRentingDbContext> options)
			: base(options)
		{
		}

		public DbSet<Agent> Agents { get; init; } = null!;

		public DbSet<Category> Categories { get; init; } = null!;

		public DbSet<House> Houses { get; init; } = null!;

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.ApplyConfiguration(new UserEntityTypeConfiguration());
			builder.ApplyConfiguration(new AgentEntityTypeConfiguration());
			builder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
			builder.ApplyConfiguration(new HouseEntityTypeConfiguration());
		}
	}
}