using System.ComponentModel.DataAnnotations;

namespace Trucks.Data.Models
{
	public class Despatcher
	{
		//•	Id – integer, Primary Key
		[Key]
		public int Id { get; set; }

		//•	Name – text with length [2, 40] (required)
		[Required]
		[StringLength(40, MinimumLength = 2)]
		public string Name { get; set; } = null!;

        //•	Position – text
		[Required]
        public string Position { get; set; } = null!;

        //•	Trucks – collection of type Truck
        public virtual ICollection<Truck> Trucks { get; set; }
			= new HashSet<Truck>();
    }
}
