using System.ComponentModel.DataAnnotations;

namespace Trucks.Data.Models
{
	public class Client
	{
		//•	Id – integer, Primary Key
		[Key]
		public int Id { get; set; }

		//•	Name – text with length [3, 40] (required)
		[Required]
		[StringLength(40, MinimumLength = 3)]
		public string Name { get; set; } = null!;

		//•	Nationality – text with length [2, 40] (required)
		[Required]
		[StringLength(40, MinimumLength = 2)]
		public string Nationality { get; set; } = null!;

		//•	Type – text (required)
		[Required]
		public string Type { get; set; } = null!;

		//•	ClientsTrucks – collection of type ClientTruck
		public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }
			= new HashSet<ClientTruck>();
	}
}
