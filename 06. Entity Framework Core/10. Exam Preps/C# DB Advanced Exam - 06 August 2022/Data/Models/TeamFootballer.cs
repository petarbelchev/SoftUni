using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models
{
	public class TeamFootballer
	{
		//•	TeamId – integer, Primary Key, foreign key (required)
		[Required]
		public int TeamId { get; set; }

        //•	Team – Team
        public Team Team { get; set; } = null!;

        //•	FootballerId – integer, Primary Key, foreign key (required)
		[Required]
		public int FootballerId { get; set; }

        //•	Footballer – Footballer
        public Footballer Footballer { get; set; } = null!;
    }
}
