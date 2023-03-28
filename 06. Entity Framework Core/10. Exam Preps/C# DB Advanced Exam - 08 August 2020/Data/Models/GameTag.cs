using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaporStore.Data.Models
{
	public class GameTag
	{
        //•	GameId – integer, Primary Key, foreign key (required)
        [Required]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        //•	Game – Game
        public Game Game { get; set; } = null!;

        //•	TagId – integer, Primary Key, foreign key (required)
        [Required]
        [ForeignKey(nameof(Tag))]
        public int TagId { get; set; }

        //•	Tag – Tag
        public Tag Tag { get; set; } = null!;
    }
}
