using AutoMapper.QueryableExtensions;
using HouseRentingSystem.Services.Rents;
using HouseRentingSystem.Services.Rents.Models;

namespace HouseRentingSystem.Tests.UnitTests
{
	[TestFixture]
	public class RentServiceTests : UnitTestsBase
	{
		private IRentService rentService;

		[OneTimeSetUp]
		public void SetUp()
		{
			rentService = new RentService(data, mapper);
		}

		[Test]
		public void All_ShouldReturnAllRentedHouses()
		{
			//Arrange
			var expectedRents = data.Houses
				.Where(h => h.RenterId != null)
				.ProjectTo<RentServiceModel>(mapper.ConfigurationProvider)
				.ToArray();

			//Act
			var actualRents = rentService.All().ToArray();

			//Assert
			Assert.That(actualRents, Is.Not.Null);
			Assert.That(actualRents.Length, Is.EqualTo(expectedRents.Length));

			for (int i = 0; i < expectedRents.Length; i++)
			{
				Assert.That(actualRents[i], Is.Not.Null);
				Assert.That(actualRents[i].HouseTitle, Is.EqualTo(expectedRents[i].HouseTitle));
				Assert.That(actualRents[i].HouseImageUrl, Is.EqualTo(expectedRents[i].HouseImageUrl));
				Assert.That(actualRents[i].RenterFullName, Is.EqualTo(expectedRents[i].RenterFullName));
				Assert.That(actualRents[i].RenterEmail, Is.EqualTo(expectedRents[i].RenterEmail));
				Assert.That(actualRents[i].AgentFullName, Is.EqualTo(expectedRents[i].AgentFullName));
				Assert.That(actualRents[i].AgentEmail, Is.EqualTo(expectedRents[i].AgentEmail));
			}
		}
	}
}
