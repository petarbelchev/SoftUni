using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Watchlist.Models;
using Watchlist.Services;

namespace Watchlist.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMoviesService moviesService;
        private readonly IGenreService genreService;

        public MoviesController(
            IMoviesService moviesService,
            IGenreService genreService)
        {
            this.moviesService = moviesService;
            this.genreService = genreService;
        }

        public async Task<IActionResult> All()
        {
            var movies = await moviesService.GetMoviesAsync();

            return View(movies);
        }

        public async Task<IActionResult> Add()
        {
            var viewModel = new AddMovieFormModel
            {
                Genres = await genreService.GetGenresAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMovieFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await moviesService.AddMovieAsync(model);

            return LocalRedirect("/");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int movieId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await moviesService.AddToWatched(movieId, userId);

                return LocalRedirect("/");
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await moviesService.RemoveFromWatched(movieId, userId);

            return RedirectToAction(nameof(Watched));
        }

        public async Task<IActionResult> Watched()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var movies = await moviesService.GetWatchedAsync(userId);

            return View(movies);
        }
    }
}
