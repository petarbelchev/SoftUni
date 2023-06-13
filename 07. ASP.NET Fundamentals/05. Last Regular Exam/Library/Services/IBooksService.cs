using Library.Models;

namespace Library.Services
{
    public interface IBooksService
    {
        Task AddBookAsync(AddBookFormModel model);

        /// <exception cref="InvalidOperationException"></exception>
        Task AddToCollection(int bookId, string userId);

        Task<IEnumerable<AllBooksViewModel>> AllBooksAsync();

        Task<ICollection<CategoryViewModel>> GetCategories();

        /// <exception cref="InvalidOperationException"></exception>
        Task RemoveFromCollection(int bookId, string userId);

        Task<IEnumerable<UserBooksViewModel>> UserBooksAsync(string userId);
    }
}
