using Library.Data;
using Library.Data.Entities;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BooksService : IBooksService
    {
        private readonly LibraryDbContext context;

        public BooksService(LibraryDbContext context)
            => this.context = context;

        public async Task AddBookAsync(AddBookFormModel model)
        {
            var newBook = new Book
            {
                Title = model.Title,
                Author = model.Author,
                CategoryId = model.CategoryId,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating
            };

            _ = await this.context.Books.AddAsync(newBook);
            _ = await this.context.SaveChangesAsync();
        }

        /// <exception cref="InvalidOperationException"></exception>
        public async Task AddToCollection(int bookId, string userId)
        {
            Book book = await this.context.Books.FirstAsync(x => x.Id == bookId);

            bool isBookAdded = await this.context.Books.AnyAsync(x => 
                x.Id == bookId && x.ApplicationUsersBooks.Any(y => y.ApplicationUserId == userId));

            if (!isBookAdded)
            {
                book.ApplicationUsersBooks.Add(new ApplicationUserBook
                {
                    ApplicationUserId = userId
                });

                _ = await this.context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AllBooksViewModel>> AllBooksAsync()
        {
            AllBooksViewModel[] books = await this.context.Books
                .Select(x => new AllBooksViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Author = x.Author,
                    ImageUrl = x.ImageUrl,
                    Rating = x.Rating,
                    Category = x.Category.Name
                })
                .ToArrayAsync();

            return books;
        }

        public async Task<ICollection<CategoryViewModel>> GetCategories()
        {
            CategoryViewModel[] categories = await this.context.Categories
                .Select(x => new CategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToArrayAsync();

            return categories;
        }

        /// <exception cref="InvalidOperationException"></exception>
        public async Task RemoveFromCollection(int bookId, string userId)
        {
            Book book = await this.context.Books.FirstAsync(x => x.Id == bookId);

            ApplicationUserBook? userBook = await this.context.Books
                .Where(x => x.Id == bookId)
                .Select(x => x.ApplicationUsersBooks.FirstOrDefault(y => y.ApplicationUserId == userId))
                .FirstOrDefaultAsync();

            if (userBook != null)
            {
                _ = book.ApplicationUsersBooks.Remove(userBook);
                _ = await this.context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserBooksViewModel>> UserBooksAsync(string userId)
        {
            UserBooksViewModel[] books = await this.context.Users
                .Where(x => x.Id == userId)
                .SelectMany(x => x.ApplicationUsersBooks)
                .Select(x => new UserBooksViewModel
                {
                    Id = x.Book.Id,
                    Title = x.Book.Title,
                    Author = x.Book .Author,
                    ImageUrl = x.Book.ImageUrl,
                    Category = x.Book.Category.Name,
                    Description = x.Book.Description
                })
                .ToArrayAsync();

            return books;
        }
    }
}
