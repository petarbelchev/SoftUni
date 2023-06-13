using System.ComponentModel.DataAnnotations;
using static Library.Constants.CategoryConstants;

namespace Library.Data.Entities
{
    public class Category
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; }
            = new HashSet<Book>();
    }
}
