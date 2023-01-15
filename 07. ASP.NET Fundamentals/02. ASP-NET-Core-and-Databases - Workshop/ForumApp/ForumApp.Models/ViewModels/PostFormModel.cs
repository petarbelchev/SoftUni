using System.ComponentModel.DataAnnotations;
using static ForumApp.Models.DataConstants.Post;

namespace ForumApp.Models.ViewModels
{
    public class PostFormModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; } = null!;
    }
}
