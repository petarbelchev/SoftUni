using System.ComponentModel.DataAnnotations;

namespace FastFood.Core.ViewModels.Items
{
    public class CreateItemInputModel
    {
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
