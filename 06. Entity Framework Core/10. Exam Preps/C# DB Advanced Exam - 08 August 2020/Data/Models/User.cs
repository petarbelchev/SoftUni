using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models
{
	public class User
	{
        //•	Id – integer, Primary Key
        [Key]
        public int Id { get; set; }

        //•	Username – text with length[3, 20] (required)
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; } = null!;

        //•	FullName – text, which has two words, consisting of Latin letters.
        //Both start with an upper letter and are followed by lower letters.
        //The two words are separated by a single space (ex. "John Smith") (required)
        [Required]
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$")]
        public string FullName { get; set; } = null!;

        //•	Email – text(required)
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        //•	Age – integer in the range[3, 103] (required)
        [Required]
        [Range(3, 103)]
        public int Age { get; set; }

        //•	Cards – collection of type Card
        public ICollection<Card> Cards { get; set; }
            = new HashSet<Card>();
    }
}
