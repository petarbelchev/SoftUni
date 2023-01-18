using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaskBoardApp.Data.DataConstants.Task;

namespace TaskBoardApp.Data.Entities
{
	public class TaskEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(TaskTitleMaxLength)]
		public string Title { get; set; } = null!;

		[Required]
		[MaxLength(TaskDescriptionMaxLength)]
		public string Description { get; set; } = null!;

		public DateTime CreatedOn { get; set; }

		[ForeignKey(nameof(Board))]
		public int BoardId { get; set; }
		public Board Board { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Owner))]
		public string OwnerId { get; set; } = null!;
		public User Owner { get; set; } = null!;
	}
}
