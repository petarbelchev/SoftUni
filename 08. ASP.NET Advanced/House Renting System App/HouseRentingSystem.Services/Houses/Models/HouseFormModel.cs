using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Services.Data.DataConstants.House;

namespace HouseRentingSystem.Services.Houses.Models
{
    public class HouseFormModel : IHouseModel
	{
		[Required]
		[StringLength(HouseTitleMaxLength, MinimumLength = HouseTitleMinLength)]
		public string Title { get; set; } = null!;

		[Required]
		[StringLength(HouseAddressMaxLength, MinimumLength = HouseAddressMinLength)]
		public string Address { get; set; } = null!;

		[Required]
		[StringLength(HouseDescriptionMaxLength, MinimumLength = HouseDescriptionMinLength)]
		public string Description { get; set; } = null!;

		[Required]
		[Display(Name = "Image URL")]
		public string ImageUrl { get; set; } = null!;

		[Range(HousePricePerMonthMinValue, HousePricePerMonthMaxValue,
			ErrorMessage = "Price Per Month muse be a positive number and less than {2} leva")]
		[Display(Name = "Price Per Month")]
		public decimal PricePerMonth { get; set; }

		[Display(Name = "Category")]
		public int CategoryId { get; set; }

		public IEnumerable<HouseCategoryServiceModel> Categories { get; set; }
			= new List<HouseCategoryServiceModel>();
	}
}
