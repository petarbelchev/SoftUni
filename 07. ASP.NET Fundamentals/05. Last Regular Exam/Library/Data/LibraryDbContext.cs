using Library.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static Library.Constants.ApplicationsUserConstants;

namespace Library.Data
{
    public class LibraryDbContext : IdentityDbContext<ApplicationUser>
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            _ = builder.Entity<ApplicationUser>(b =>
            {
                _ = b
                    .Property(x => x.UserName)
                    .HasMaxLength(UserNameMaxLength)
                    .IsRequired();

                _ = b
                    .Property(x => x.NormalizedUserName)
                    .HasMaxLength(UserNameMaxLength)
                    .IsRequired();

                _ = b
                    .Property(x => x.Email)
                    .HasMaxLength(EmailMaxLength)
                    .IsRequired();

                _ = b
                    .Property(x => x.NormalizedEmail)
                    .HasMaxLength(EmailMaxLength)
                    .IsRequired();
            });

            _ = builder.Entity<ApplicationUserBook>()
                .HasKey(x => new { x.ApplicationUserId, x.BookId });

            _ = builder.Entity<Book>(b =>
            {
                _ = b
                    .Property(x => x.Rating)
                    .HasColumnType("decimal(4,2)")
                    .IsRequired();

                _ = b
                    .HasData(new Book()
                    {
                        Id = 5,
                        Title = "Lorem Ipsum",
                        Author = "Dolor Sit",
                        ImageUrl = "https://img.freepik.com/free-psd/book-cover-mock-up-arrangement_23-2148622888.jpg?w=826&t=st=1666106877~exp=1666107477~hmac=5dea3e5634804683bccfebeffdbde98371db37bc2d1a208f074292c862775e1b",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        CategoryId = 1,
                        Rating = 9.5m
                    });
            });

            _ = builder.Entity<Category>()
               .HasData(new Category()
               {
                   Id = 1,
                   Name = "Action"
               },
               new Category()
               {
                   Id = 2,
                   Name = "Biography"
               },
               new Category()
               {
                   Id = 3,
                   Name = "Children"
               },
               new Category()
               {
                   Id = 4,
                   Name = "Crime"
               },
               new Category()
               {
                   Id = 5,
                   Name = "Fantasy"
               });

            base.OnModelCreating(builder);
        }
    }
}