using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boardgames.Data.Models
{
	public class BoardgameSeller
	{
		//•	BoardgameId – integer, Primary Key, foreign key (required)
		[Required]
		[ForeignKey(nameof(Boardgame))]
		public int BoardgameId { get; set; }

        //•	Boardgame – Boardgame
        public Boardgame Boardgame { get; set; } = null!;

        //•	SellerId – integer, Primary Key, foreign key (required)
		[Required]
		[ForeignKey(nameof(Seller))]
		public int SellerId { get; set; }

        //•	Seller – Seller
        public Seller Seller { get; set; } = null!;
    }
}
