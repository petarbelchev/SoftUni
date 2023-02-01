using HouseRentingSystem.Services.Users;
using HouseRentingSystem.Services.Users.Models;

namespace HouseRentingSystem.Tests.UnitTests
{
	[TestFixture]
	public class UserServiceTests : UnitTestsBase
	{
		private IUserService userService;

		[OneTimeSetUp]
		public void SetUp()
		{
			userService = new UserService(data, mapper);
		}

		[Test]
		public void UserHasRents_ShouldReturnTrue_WithValidData()
		{
			//Arrange

			//Act
			bool result = userService.UserHasRents(Renter.Id);

			//Assert
			Assert.That(result, Is.True);
		}

		[Test]
		public void UserFullName_ShouldReturnCorrectResult()
		{
			//Arrange
			string expectedResult = Renter.FirstName + " " + Renter.LastName;

			//Act
			string actualResult = userService.UserFullName(Renter.Id);

			//Assert
			Assert.That(actualResult, Is.EqualTo(expectedResult));
		}

		[Test]
		public void All_ShouldReturnCorrectUsersAndAgents()
		{
			//Arrange
			int expectedTotalCount = data.Users.Count();
			int expectedAgentsCount = data.Agents.Count();
			int expectedUsersCount = expectedTotalCount - expectedAgentsCount;

			//Act
			UserServiceModel[] actualUsers = userService.All().ToArray();

			//Assert that returned count is correct
			Assert.That(actualUsers, Is.Not.Null);
			Assert.That(actualUsers.Length, Is.EqualTo(expectedTotalCount));
			Assert.That(actualUsers.Count(u => u.PhoneNumber != string.Empty),
				Is.EqualTo(expectedAgentsCount));
			Assert.That(actualUsers.Count(u => u.PhoneNumber == string.Empty), 
				Is.EqualTo(expectedUsersCount));

			//Assert that returned data is correct
			UserServiceModel? agent = actualUsers.FirstOrDefault(u => u.Email == Agent.User.Email);
			Assert.That(agent, Is.Not.Null);
			Assert.That(agent.PhoneNumber, Is.EqualTo(Agent.PhoneNumber));
		}
	}
}
