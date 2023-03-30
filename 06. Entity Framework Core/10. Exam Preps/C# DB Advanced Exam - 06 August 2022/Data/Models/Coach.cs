using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models
{
	public class Coach
	{
		//•	Id – integer, Primary Key
		[Key]
		public int Id { get; set; }

		//•	Name – text with length [2, 40] (required)
		[Required]
		[StringLength(40, MinimumLength = 2)]
		public string Name { get; set; } = null!;

		//•	Nationality – text (required)
		[Required]
		public string Nationality { get; set; } = null!;

        //•	Footballers – collection of type Footballer
        public ICollection<Footballer> Footballers { get; set; }
			= new HashSet<Footballer>();
    }
}
