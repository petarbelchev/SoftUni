using HouseRentingSystem.Services.Agents;
using HouseRentingSystem.Services.Data.Entities;

namespace HouseRentingSystem.Tests.UnitTests
{
	[TestFixture]
	public class AgentServiceTests : UnitTestsBase
	{
		private IAgentService agentService;

		[OneTimeSetUp]
		public void SetUp()
		{
			agentService = new AgentService(data);
		}

		[Test]
		public void GetAgentId_ShouldReturnCorrectAgentId()
		{
			//Arrange
			string userId = Agent.UserId;
			int expectedAgentId = Agent.Id;

			//Act
			int actualAgentId = agentService.GetAgentId(userId);

			//Assert
			Assert.That(actualAgentId, Is.EqualTo(expectedAgentId));
		}

		[Test]
		public void ExistsById_ShouldReturnTrue_WithValidId()
		{
			//Arrange
			string userId = Agent.UserId;

			//Act
			bool result = agentService.ExistsById(userId);

			//Assert
			Assert.That(result, Is.True);
		}

		[Test]
		public void AgentWithPhoneNumberExists_ShouldReturnTrue_WithValidPhoneNumber()
		{
			//Arrange
			string phoneNumber = Agent.PhoneNumber;

			//Act
			bool result = agentService.AgentWithPhoneNumberExists(phoneNumber);

			//Assert
			Assert.That(result, Is.True);
		}

		[Test]
		public void Create_ShouldCreateAgent_WithValidUserIdAndPhoneNumber()
		{
			//Arrange
			int agentCountBefore = data.Agents.Count();
			string newAgentPhoneNumber = "+35911223344";

			User newAgent = new User()
			{
				Id = "NewAgentId",
				Email = "NewAgentEmail",
				FirstName = "NewAgentFirstName",
				LastName = "NewAgentLastName"
			};
			data.Users.Add(newAgent);
			data.SaveChanges();

			//Act
			agentService.Create(newAgent.Id, newAgentPhoneNumber);
			int newAgentId = agentService.GetAgentId(newAgent.Id);
			Agent? newAgentInDb = data.Agents.Find(newAgentId);

			//Assert
			Assert.That(data.Agents.Count(), Is.EqualTo(agentCountBefore + 1));
			Assert.That(newAgentInDb, Is.Not.Null);
			Assert.That(newAgentInDb.PhoneNumber, Is.EqualTo(newAgentPhoneNumber));
			Assert.That(newAgentInDb.UserId, Is.EqualTo(newAgent.Id));
		}
	}
}
