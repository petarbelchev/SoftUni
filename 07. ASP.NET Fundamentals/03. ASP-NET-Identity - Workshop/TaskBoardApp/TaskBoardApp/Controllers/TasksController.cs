using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Data.Entities;
using TaskBoardApp.Models.Tasks;

namespace TaskBoardApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskBoardAppDbContext _dbContext;

        public TasksController(TaskBoardAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new TaskFormModel()
            {
                Boards = GetBoards()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel model)
        {
            if (!GetBoards().Any(b => b.Id == model.BoardId))
                ModelState.AddModelError(nameof(model.BoardId), "BoardId does not exist.");

            if (!ModelState.IsValid)
                return View(model);

            string currUserId = GetUserId();

            TaskEntity task = new TaskEntity()
            {
                Title = model.Title,
                Description = model.Description,
                BoardId = model.BoardId,
                OwnerId = currUserId
            };

            _dbContext.Tasks.Add(task);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Boards");
        }

        public async Task<IActionResult> Details(int id)
        {
            TaskDetailsViewModel? task = await _dbContext.Tasks
                .Where(t => t.Id == id)
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Owner = t.Owner.UserName,
                    CreatedOn = t.CreatedOn.ToString()
                })
                .FirstOrDefaultAsync();

            if (task == null)
            {
                return BadRequest();
            }

            return View(task);
        }

        public async Task<IActionResult> Edit(int id)
        {
            TaskEntity? task = await _dbContext.FindAsync<TaskEntity>(id);

            if (task == null)
                return BadRequest();

            string currUserId = GetUserId();

            if (currUserId != task.OwnerId)
                return Unauthorized();

            TaskFormModel taskModel = new TaskFormModel
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = GetBoards()
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            TaskEntity? task = await _dbContext.FindAsync<TaskEntity>(id);

            if (task == null)
                return BadRequest();

            string currUserId = GetUserId();

            if (currUserId != task.OwnerId)
                return Unauthorized();

            if (!GetBoards().Any(b => b.Id == model.BoardId))
                ModelState.AddModelError(nameof(model.BoardId), "Board does not exist.");

            task.Title = model.Title;
            task.Description = model.Description;
            task.BoardId = model.BoardId;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Boards");
        }

        public async Task<IActionResult> Delete(int id)
        {
            TaskEntity? task = await _dbContext.Tasks.FindAsync(id);
            if (task == null)
                return BadRequest();

            string currUserId = GetUserId();
            if (currUserId != task.OwnerId)
                return Unauthorized();

            TaskViewModel model = new TaskViewModel
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel taskModel)
        {
            TaskEntity? task = await _dbContext.Tasks.FindAsync(taskModel.Id);
            if (task == null)
                return BadRequest();
            
            string currUserId = GetUserId();
            if (currUserId != task.OwnerId)
                return Unauthorized();

            _dbContext.Remove(task);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Boards");
        }

        private IEnumerable<TaskBoardModel> GetBoards()
            => _dbContext.Boards.Select(b => new TaskBoardModel()
            {
                Id = b.Id,
                Name = b.Name
            });

        private string GetUserId()
            => this.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
