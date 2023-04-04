using System.ComponentModel.DataAnnotations;

namespace Boardgames.Data.Models
{
	public class Creator
	{
		//•	Id – integer, Primary Key
		[Key]
		public int Id { get; set; }

		//•	FirstName – text with length [2, 7] (required) 
		[Required]
		[StringLength(7, MinimumLength = 2)]
		public string FirstName { get; set; } = null!;

		//•	LastName – text with length [2, 7] (required)
		[Required]
		[StringLength (7, MinimumLength = 2)]
		public string LastName { get; set; } = null!;

        //•	Boardgames – collection of type Boardgame
        public virtual ICollection<Boardgame> Boardgames { get; set; }
			= new HashSet<Boardgame>();
    }
}
