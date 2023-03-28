using System.ComponentModel.DataAnnotations;

namespace TeisterMask.DataProcessor.ImportDto
{
	public class ImportEmployeeDTO
	{
		[Required]
		[StringLength(40, MinimumLength = 3)]
		[RegularExpression(@"^[A-Za-z0-9]{3,}$")]
        public string Username { get; set; } = null!;

		[Required]
		[EmailAddress]
        public string Email { get; set; } = null!;

		[Required]
		[RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
        public string Phone { get; set; } = null!;

        public virtual ICollection<int> Tasks  { get; set; } = null!;
	}
}
