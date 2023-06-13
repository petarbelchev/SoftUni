using System.ComponentModel.DataAnnotations;
using static Contacts.Constants.ContactConstants;

namespace Contacts.Models
{
    public class ContactFormModel
    {
        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength,
            ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength,
            ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength,
            ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength,
            ErrorMessage = "The {0} must be at least {2} and at max {1} digits.")]
        [RegularExpression(@"^(?:\+359|0)[\-\s]?\d{3}(?:[\-\s]?\d{2}){3}$", 
            ErrorMessage = "Please enter a valid phone number.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = null!;

        public string? Address { get; set; }

        [Required]
        [RegularExpression(@"^www.[a-zA-Z0-9-]+\.bg$",
			ErrorMessage = "Please enter a valid website.")]
        public string Website { get; set; } = null!;
    }
}
