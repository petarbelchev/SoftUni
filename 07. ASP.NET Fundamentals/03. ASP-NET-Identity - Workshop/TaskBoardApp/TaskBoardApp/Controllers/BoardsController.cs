using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.Models;
using TaskBoardApp.Models.Tasks;

namespace TaskBoardApp.Controllers
{
    public class BoardsController : BaseController
    {
        private readonly TaskBoardAppDbContext _dbContext;

        public BoardsController(TaskBoardAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            BoardViewModel[] boards = await _dbContext.Boards
                .Select(b => new BoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b.Tasks.Select(t => new TaskViewModel()
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Description = t.Description,
                        Owner = t.Owner.UserName
                    })
                })
                .ToArrayAsync();

            return View(boards);
        }
    }
}
