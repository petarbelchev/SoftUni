using System.ComponentModel.DataAnnotations;
using static Library.Constants.BookConstants;

namespace Library.Models
{
    public class AddBookFormModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(RatingMinLength, RatingMaxLength)]
        public decimal Rating { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; }
            = new HashSet<CategoryViewModel>();
    }
}
