using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trucks.Data.Models.Enums;

namespace Trucks.Data.Models
{
	public class Truck
	{
		//•	Id – integer, Primary Key
		[Key]
		public int Id { get; set; }

        //•	RegistrationNumber – text with length 8.
        //First two characters are upper letters [A-Z], followed by four digits and the last two characters are upper letters [A-Z] again.
        [Required]
        [RegularExpression(@"^[A-Z]{2}\d{4}[A-Z]{2}$")]
        public string RegistrationNumber { get; set; } = null!;

        //•	VinNumber – text with length 17 (required)
        [Required]
        [StringLength(17, MinimumLength = 17)]
        public string VinNumber { get; set; } = null!;

        //•	TankCapacity – integer in range [950…1420]
        [Required]
        [Range(950, 1420)]
        public int TankCapacity { get; set; }

        //•	CargoCapacity – integer in range [5000…29000]
        [Required]
        [Range(5000, 29000)]
        public int CargoCapacity { get; set; }

        //•	CategoryType – enumeration of type CategoryType, with possible values (Flatbed, Jumbo, Refrigerated, Semi) (required)
        [Required]
        public CategoryType CategoryType { get; set; }

        //•	MakeType – enumeration of type MakeType, with possible values (Daf, Man, Mercedes, Scania, Volvo) (required)
        [Required]
        public MakeType MakeType { get; set; }

        //•	DespatcherId – integer, foreign key (required)
        [Required]
        [ForeignKey(nameof(Despatcher))]
        public int DespatcherId { get; set; }

        //•	Despatcher – Despatcher 
        public Despatcher Despatcher { get; set; } = null!;

        //•	ClientsTrucks – collection of type ClientTruck
        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; } 
            = new HashSet<ClientTruck>();
    }
}
