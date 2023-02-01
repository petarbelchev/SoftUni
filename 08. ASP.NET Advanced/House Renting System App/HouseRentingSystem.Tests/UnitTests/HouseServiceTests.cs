using AutoMapper.QueryableExtensions;
using HouseRentingSystem.Services.Data.Entities;
using HouseRentingSystem.Services.Houses;
using HouseRentingSystem.Services.Houses.Models;
using HouseRentingSystem.Services.Users;

namespace HouseRentingSystem.Tests.UnitTests
{
	[TestFixture]
	public class HouseServiceTests : UnitTestsBase
	{
		private IHouseService houseService;
		private IUserService userService;

		[OneTimeSetUp]
		public void SetUp()
		{
			userService = new UserService(data, mapper);
			houseService = new HouseService(data, userService, mapper);
		}

		[Test]
		public void All_ShouldReturnCorrectData_WithSearchTermFilter()
		{
			//Arrange
			string searchTerm = "First";
			var expectedResult = data.Houses
				.Where(h => h.Title.Contains(searchTerm) ||
							h.Address.Contains(searchTerm) ||
							h.Description.Contains(searchTerm))
				.ProjectTo<HouseServiceModel>(mapper.ConfigurationProvider)
				.ToArray();

			//Act
			var result = houseService.All(null, searchTerm);

			//Assert
			Assert.That(result.TotalHousesCount, Is.EqualTo(expectedResult.Length));

			var resultHouse = result.Houses.FirstOrDefault();
			Assert.That(resultHouse, Is.Not.Null);

			var houseInDb = expectedResult.First();
			Assert.Multiple(() =>
			{
				Assert.That(resultHouse.Id, Is.EqualTo(houseInDb.Id));
				Assert.That(resultHouse.Title, Is.EqualTo(houseInDb.Title));
			});
		}

		[Test]
		public void All_ShouldReturnCorrectData_WithCategoryNameFilter()
		{
			//Arrange
			string categoryName = "Single-Family";
			var expectedResult = data.Houses
				.Where(h => h.Category.Name == categoryName)
				.ProjectTo<HouseServiceModel>(mapper.ConfigurationProvider)
				.ToArray();

			//Act
			var result = houseService.All(categoryName);

			//Assert
			Assert.That(result.TotalHousesCount, Is.EqualTo(expectedResult.Length));

			var resultHouse = result.Houses.FirstOrDefault();
			Assert.That(resultHouse, Is.Not.Null);

			var houseInDb = expectedResult.First();
			Assert.Multiple(() =>
			{
				Assert.That(resultHouse.Id, Is.EqualTo(houseInDb.Id));
				Assert.That(resultHouse.Title, Is.EqualTo(houseInDb.Title));
			});
		}

		[Test]
		public void AllCategories_ShouldReturnCorrectData()
		{
			//Arrange
			var expected = data.Categories
				.ProjectTo<HouseCategoryServiceModel>(mapper.ConfigurationProvider)
				.AsEnumerable();

			//Act
			var actual = houseService.AllCategories();

			//Assert
			Assert.That(actual.Count(), Is.EqualTo(expected.Count()));

			for (int i = 0; i < expected.Count(); i++)
			{
				Assert.Multiple(() =>
				{
					Assert.That(actual.ElementAt(i).Id, Is.EqualTo(expected.ElementAt(i).Id));
					Assert.That(actual.ElementAt(i).Name, Is.EqualTo(expected.ElementAt(i).Name));
				});
			}
		}

		[Test]
		public void AllCategoriesNames_ShouldReturnCorrectData()
		{
			//Arrange
			var expected = data.Categories
				.Select(c => c.Name)
				.Distinct()
				.AsEnumerable();

			//Act
			var actual = houseService.AllCategoriesNames();

			//Assert
			Assert.That(actual.Count(), Is.EqualTo(expected.Count()));

			for (int i = 0; i < expected.Count(); i++)
			{
				Assert.That(actual.ElementAt(i), Is.EqualTo(expected.ElementAt(i)));
			}
		}

		[Test]
		public void AllHousesByAgentId_ShouldReturnCorrectData()
		{
			//Arrange
			var expected = data.Houses
				.Where(h => h.AgentId == Agent.Id)
				.ProjectTo<HouseServiceModel>(mapper.ConfigurationProvider)
				.AsEnumerable();

			//Act
			var actual = houseService.AllHousesByAgentId(Agent.Id);

			//Assert
			Assert.That(actual.Count(), Is.EqualTo(expected.Count()));

			for (int i = 0; i < expected.Count(); i++)
			{
				Assert.That(actual.ElementAt(i).Id, Is.EqualTo(expected.ElementAt(i).Id));
			}
		}

		[Test]
		public void AllHousesByUserId_ShouldReturnCorrectData()
		{
			//Arrange
			var expected = data.Houses
				.Where(h => h.RenterId == Renter.Id)
				.ProjectTo<HouseServiceModel>(mapper.ConfigurationProvider)
				.AsEnumerable();

			//Act
			var actual = houseService.AllHousesByUserId(Renter.Id);

			//Assert
			Assert.That(actual.Count(), Is.EqualTo(expected.Count()));

			for (int i = 0; i < expected.Count(); i++)
			{
				Assert.That(actual.ElementAt(i).Id, Is.EqualTo(expected.ElementAt(i).Id));
			}
		}

		[Test]
		public void CategoryExists_ShouldReturnTrue_WithValidCategory()
		{
			//Arrange
			Category category = data.Categories
				.First(c => c.Name == "Single-Family");

			//Act
			bool result = houseService.CategoryExists(category.Id);

			//Assert
			Assert.That(result, Is.True);
		}

		[Test]
		public void Create_ShouldCreateHouse()
		{
			//Arrange
			int housesCountBefore = data.Houses.Count();

			var house = new House
			{
				Title = "TestHouse",
				Address = "TestAddress",
				Description = "TestDescription",
				ImageUrl = "TestUrl",
				PricePerMonth = 10.00m,
				CategoryId = 1,
				AgentId = Agent.Id
			};

			//Act
			int newHouseId = houseService.Create(house.Title, house.Address,
												house.Description, house.ImageUrl,
												house.PricePerMonth, house.CategoryId,
												house.AgentId);

			var newHouse = data.Houses.Find(newHouseId);

			//Assert
			Assert.That(data.Houses.Count(), Is.EqualTo(housesCountBefore + 1));
			Assert.That(newHouse, Is.Not.Null);
			Assert.That(newHouse.Title, Is.EqualTo(house.Title));
			Assert.That(newHouse.PricePerMonth, Is.EqualTo(house.PricePerMonth));
		}

		[Test]
		public void Exists_ShouldReturnTrue_WithValidId()
		{
			//Arrange

			//Act
			bool result = houseService.Exists(RentedHouse.Id);

			//Assert
			Assert.That(result, Is.True);
		}
	}
}
