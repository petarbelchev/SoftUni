using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data.Models
{
	public class Purchase
	{
        //•	Id – integer, Primary Key
        [Key]
        public int Id { get; set; }

        //•	Type – enumeration of type PurchaseType, with possible values ("Retail", "Digital") (required) 
        [Required]
        public PurchaseType Type { get; set; }

        //•	ProductKey – text, which consists of 3 pairs of 4 uppercase Latin letters and digits, separated by dashes (ex. "ABCD-EFGH-1J3L") (required)
        [Required]
        [RegularExpression(@"^[A-Z\d]{4}-[A-Z\d]{4}-[A-Z\d]{4}$")]
        public string ProductKey { get; set; } = null!;

        //•	Date – Date (required)
        [Required]
        public DateTime Date { get; set; }

        //•	CardId – integer, foreign key (required)
        [Required]
        [ForeignKey(nameof(Card))]
        public int CardId { get; set; }

        //•	Card – the purchase's card (required)
        public Card Card { get; set; } = null!;

        //•	GameId – integer, foreign key (required)
        [Required]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        //•	Game – the purchase's game (required)
        public Game Game { get; set; } = null!;
    }
}
