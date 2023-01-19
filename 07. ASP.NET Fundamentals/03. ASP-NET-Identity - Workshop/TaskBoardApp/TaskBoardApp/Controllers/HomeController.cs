using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models;

namespace TaskBoardApp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly TaskBoardAppDbContext _dbContext;

        public HomeController(TaskBoardAppDbContext context)
        {
            _dbContext = context;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var boardsNames = _dbContext.Boards
                .Select(b => b.Name)
                .Distinct();

            var boardsWithTasksCount = new List<HomeBoardModel>();
            foreach (var boardName in boardsNames)
            {
                var tasksCountInCurrBoard = _dbContext.Tasks.Count(t => t.Board.Name == boardName);
                boardsWithTasksCount.Add(new HomeBoardModel
                {
                    BoardName = boardName,
                    TasksCount = tasksCountInCurrBoard
                });
            }

            int userTasksCount = -1;

            if (User.Identity?.IsAuthenticated ?? false)
            {
                var currUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                userTasksCount = _dbContext.Tasks.Count(t => t.OwnerId == currUserId);
            }

            var homeModel = new HomeViewModel()
            {
                AllTasksCount = _dbContext.Tasks.Count(),
                BoardsWithTasksCount = boardsWithTasksCount,
                UserTasksCount = userTasksCount
            };

            return View(homeModel);
        }
    }
}