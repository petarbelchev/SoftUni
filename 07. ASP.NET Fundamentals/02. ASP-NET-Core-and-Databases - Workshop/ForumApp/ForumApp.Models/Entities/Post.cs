using System.ComponentModel.DataAnnotations;
using static ForumApp.Models.DataConstants.Post;

namespace ForumApp.Models.Entities
{
	public class Post
	{
		[Key]
		public int Id { get; init; }

		[Required]
		[MaxLength(TitleMaxLength)]
		public string Title { get; set; } = null!;

		[Required]
		[MaxLength(ContentMaxLength)]
		public string Content { get; set; } = null!;
	}
}
