using System.ComponentModel.DataAnnotations;
using static Contacts.Constants.ContactConstants;

namespace Contacts.Data.Entities
{
	public class Contact
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(FirstNameMaxLength)]
		public string FirstName { get; set; } = null!;

		[Required]
		[MaxLength(LastNameMaxLength)]
		public string LastName { get; set; } = null!;

		[Required]
		[MaxLength(EmailMaxLength)]
		public string Email { get; set; } = null!;

		[Required]
		[MaxLength(PhoneNumberMaxLength)]
		public string PhoneNumber { get; set; } = null!;

		public string? Address { get; set; }

		[Required]
		public string Website { get; set; } = null!;

        public ICollection<ApplicationUserContact> ApplicationUsersContacts { get; set; }
            = new HashSet<ApplicationUserContact>();
	}
}
