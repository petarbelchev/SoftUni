using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.ImportDto
{
	public class ImportUserDTO
	{
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
        public ICollection<ImportCardDTO> Cards { get; set; }
            = new HashSet<ImportCardDTO>();
    }
}
