using System.ComponentModel.DataAnnotations;
using static Homies.Constants.EventConstants;

namespace Homies.Models
{
	public class EventFormModel
	{
		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength,
			ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
		public string Name { get; set; } = null!;

		[Required]
		[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength,
			ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
		public string Description { get; set; } = null!;

		[Required]
		public DateTime? Start { get; set; } = null!;

		[Required]
		public DateTime? End { get; set; } = null!;

		[Required]
		[Range(1, int.MaxValue)]
		public int TypeId { get; set; }

		public IEnumerable<TypeViewModel> Types { get; set; }
			= new List<TypeViewModel>();
	}
}
