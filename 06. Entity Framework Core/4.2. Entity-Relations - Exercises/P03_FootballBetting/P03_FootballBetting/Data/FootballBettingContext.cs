using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        { }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=.;Database=FootballBetting;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>(builder =>
            {
                builder.HasKey(ps => new { ps.PlayerId, ps.GameId });

                builder
                    .HasOne(ps => ps.Player)
                    .WithMany(p => p.PlayerStatistics)
                    .HasForeignKey(p => p.PlayerId);

                builder
                    .HasOne(ps => ps.Game)
                    .WithMany(g => g.PlayerStatistics)
                    .HasForeignKey(g => g.GameId);
            });

            modelBuilder.Entity<Team>(builder =>
            {
                builder
                    .HasOne(t => t.PrimaryKitColor)
                    .WithMany(t => t.PrimaryKitTeams)
                    .OnDelete(DeleteBehavior.Restrict);

                builder
                    .HasOne(t => t.SecondaryKitColor)
                    .WithMany(t => t.SecondaryKitTeams)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Game>(builder =>
            {
                builder
                    .HasOne(t => t.HomeTeam)
                    .WithMany(t => t.HomeGames)
                    .OnDelete(DeleteBehavior.Restrict);

                builder
                    .HasOne(t => t.AwayTeam)
                    .WithMany(t => t.AwayGames)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
