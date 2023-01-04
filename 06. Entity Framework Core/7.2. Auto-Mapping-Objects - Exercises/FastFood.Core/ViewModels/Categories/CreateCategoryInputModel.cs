using System.ComponentModel.DataAnnotations;

namespace FastFood.Core.ViewModels.Categories
{
    public class CreateCategoryInputModel
    {
        [Required]
        public string CategoryName { get; set; }
    }
}
