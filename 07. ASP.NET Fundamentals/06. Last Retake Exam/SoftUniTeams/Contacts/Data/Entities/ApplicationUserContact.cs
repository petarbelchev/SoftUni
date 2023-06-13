using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Data.Entities
{
	public class ApplicationUserContact
	{
        [Required]
        [Key]
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; } = null!;

        public ApplicationUser ApplicationUser { get; set; } = null!;

        [Required]
        [Key]
        [Range(1, int.MaxValue)]
        [ForeignKey(nameof(Contact))]
        public int ContactId { get; set; }

        public Contact Contact { get; set; } = null!;
    }
}
