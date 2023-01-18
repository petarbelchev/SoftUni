using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstants.Board;

namespace TaskBoardApp.Data.Entities
{
	public class Board
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(BoardNameMaxLength)]
		public string Name { get; set; } = null!;

		public ICollection<TaskEntity> Tasks { get; set; } 
			= new HashSet<TaskEntity>();
	}
}
