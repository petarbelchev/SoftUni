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
		public void Delete_ShouldDeleteHouse()
		{
			//Arrange
			string title = "TestHouse2";
			string address = "TestAddress2";
			string description = "TestDescription2";
			string imageUrl = "TestUrl2";
			decimal pricePerMonth = 15.00m;
			int categoryId = 2;
			int agentId = Agent.Id;

			int houseId = houseService.Create(title, address, description, imageUrl,
												pricePerMonth, categoryId, agentId);

			//Act
			int housesCountBeforeDelete = data.Houses.Count();
			houseService.Delete(houseId);

			//Assert
			Assert.That(data.Houses.Count(), Is.EqualTo(housesCountBeforeDelete - 1));

			var deletedHouse = data.Houses.Find(houseId);
			Assert.That(deletedHouse, Is.Null);
		}

		[Test]
		public void Edit_ShouldEditHouse()
		{
			//Arrange
			string title = "TestHouse3";
			string address = "TestAddress3";
			string description = "TestDescription3";
			string imageUrl = "TestUrl3";
			decimal pricePerMonth = 20.00m;
			int categoryId = 3;
			int agentId = Agent.Id;

			int houseId = houseService.Create(title, address, description, imageUrl,
												pricePerMonth, categoryId, agentId);

			//Act
			string newTitle = "EditedTitle";
			decimal newPrice = 25.00m;
			houseService.Edit(houseId, newTitle, address, description, imageUrl, newPrice, categoryId);

			//Assert
			var house = data.Houses.First(h => h.Id == houseId);
			Assert.That(house.Title, Is.EqualTo(newTitle));
			Assert.That(house.PricePerMonth, Is.EqualTo(newPrice));
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

		[Test]
		public void GetHouseCategoryId_ShouldReturnCorrectId()
		{
			//Arrange
			int expectedId = RentedHouse.CategoryId;

			//Act
			int actualId = houseService.GetHouseCategoryId(RentedHouse.Id);

			//Assert
			Assert.That(actualId, Is.EqualTo(expectedId));
		}

		[Test]
		public void HasAgentWithId_ShouldReturnTrue_WithValidId()
		{
			//Arrange

			//Act
			bool result = houseService.HasAgentWithId(RentedHouse.Id, Agent.UserId);

			//Assert
			Assert.That(result, Is.True);
		}

		[Test]
		public void HasAgentWithId_ShouldReturnFalse_WithInvalidUserId()
		{
			//Arrange

			//Act
			bool result = houseService.HasAgentWithId(RentedHouse.Id, "NotExistId");

			//Assert
			Assert.That(result, Is.False);
		}

		[Test]
		public void HasAgentWithId_ShouldReturnFalse_WithInvalidHouseId()
		{
			//Arrange

			//Act
			bool result = houseService.HasAgentWithId(-1, Agent.UserId);

			//Assert
			Assert.That(result, Is.False);
		}

		[Test]
		public void HouseDetailsById_ShouldReturnCorrectData()
		{
			//Act
			var house = houseService.HouseDetailsById(RentedHouse.Id);

			//Assert
			Assert.That(house.Id, Is.EqualTo(RentedHouse.Id));
			Assert.That(house.Title, Is.EqualTo(RentedHouse.Title));
			Assert.That(house.Description, Is.EqualTo(RentedHouse.Description));
		}

		[Test]
		public void IsRented_ShouldReturnTrue_WithValidData()
		{
			//Act
			bool response = houseService.IsRented(RentedHouse.Id);

			//Assert
			Assert.That(response, Is.True);
		}

		[Test]
		public void IsRentedByUserWithId_ShouldReturnTrue_WithValidData()
		{
			//Act
			bool response = houseService.IsRentedByUserWithId(RentedHouse.Id, Renter.Id);

			//Assert
			Assert.That(response, Is.True);
		}

		[Test]
		public void LastThreeHouses_ShouldReturnCorrectData()
		{
			//Arrange
			var lastThreeHouses = new List<House>();
			for (int i = 1; i <= 3; i++)
			{
				lastThreeHouses.Add(new House
				{
					Title = "Title" + i,
					Address = "Address" + i,
					Description = "Description" + i,
					ImageUrl = "ImageUrl" + i,
					Agent = Agent,
					Renter = Renter,
					Category = new Category() { Name = "TestCategory" }
				});
			}
			data.Houses.AddRange(lastThreeHouses);
			data.SaveChanges();

			lastThreeHouses.Reverse();

			//Act
			var actualHouses = houseService.LastThreeHouses();

			//Assert
			Assert.That(actualHouses, Is.Not.Null);
			Assert.That(actualHouses.Count(), Is.EqualTo(lastThreeHouses.Count()));
			for (int i = 0; i < actualHouses.Count(); i++)
			{
				Assert.That(actualHouses.ElementAt(i).Id, Is.EqualTo(lastThreeHouses.ElementAt(i).Id));
				Assert.That(actualHouses.ElementAt(i).Title, Is.EqualTo(lastThreeHouses.ElementAt(i).Title));
				Assert.That(actualHouses.ElementAt(i).Address, Is.EqualTo(lastThreeHouses.ElementAt(i).Address));
			}
		}

		[Test]
		public void RentAndLeave_ShouldWorkCorrectly()
		{
			//Arrange
			
			//Act
			houseService.Leave(RentedHouse.Id);

			//Assert that house is lefted
			Assert.That(RentedHouse.RenterId, Is.Null);

			//Act
			houseService.Rent(RentedHouse.Id, Renter.Id);

			//Assert that house is created and rented
			Assert.That(RentedHouse.RenterId, Is.EqualTo(Renter.Id));
		}
	}
}
