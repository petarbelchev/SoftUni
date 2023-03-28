using System.ComponentModel.DataAnnotations;

namespace SoftJail.Data.Models
{
	public class Department
	{
		[Key]
        public int Id { get; set; }

		[Required]
		[MaxLength(25)]
        public string Name { get; set; } = null!;

        public ICollection<Cell> Cells { get; set; }
			= new HashSet<Cell>();
    }
}