using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Watchlist.Models.Movie;
using Watchlist.Services;

namespace Watchlist.Controllers
{
    public class MoviesController : BaseController
    {
        private readonly IMovieService service;

        public MoviesController(IMovieService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> All()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
                return RedirectToAction("Logout", "User");

            return View(await service.GetAllMoviesAsync(userId));
        }

        public async Task<IActionResult> Add()
        {
            var model = new AddMovieViewModel
            {
                Genres = await service.GetGenres()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMovieViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                await service.AddMovie(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int movieId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await service.AddMovieToWatched(userId, movieId);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Watched()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var userMovies = await service
                .GetWatchedMoviesByUserIdAsync(userId);

            return View(userMovies);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await service.RemoveMovieFromWatched(userId, movieId);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return RedirectToAction("Watched");
        }
    }
}
