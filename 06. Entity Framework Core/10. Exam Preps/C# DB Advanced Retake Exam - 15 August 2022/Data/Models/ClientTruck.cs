using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trucks.Data.Models
{
	public class ClientTruck
	{
        //•	ClientId – integer, Primary Key, foreign key(required)
        [Required]
        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        //•	Client – Client
        public Client Client { get; set; } = null!;

        //•	TruckId – integer, Primary Key, foreign key(required)
        [Required]
        [ForeignKey(nameof(Truck))]
        public int TruckId { get; set; }

        //•	Truck – Truck
        public Truck Truck { get; set; } = null!;
    }
}
