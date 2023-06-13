using Library.Extensions;
using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBooksService booksService;

        public BooksController(IBooksService booksService)
            => this.booksService = booksService;

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var viewModel = new AddBookFormModel()
            {
                Categories = await this.booksService.GetCategories()
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.booksService.GetCategories();

                return this.View(model);
            }

            await this.booksService.AddBookAsync(model);

            return this.RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int bookId)
        {
            try
            {
                await this.booksService.AddToCollection(bookId, this.User.Id());
            }
            catch (InvalidOperationException)
            {
                return this.BadRequest();
            }

            return this.RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<AllBooksViewModel> viewModel = await this.booksService.AllBooksAsync();

            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            IEnumerable<UserBooksViewModel> viewModel = 
                await this.booksService.UserBooksAsync(this.User.Id());

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            try
            {
                await this.booksService.RemoveFromCollection(bookId, this.User.Id());
            }
            catch (InvalidOperationException)
            {
                return this.BadRequest();
            }

            return this.RedirectToAction(nameof(Mine));
        }
    }
}
