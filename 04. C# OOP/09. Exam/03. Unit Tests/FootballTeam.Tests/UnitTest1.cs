namespace FootballTeam.Tests
{
    using NUnit.Framework;

    public class Tests
    {
        [TestCase("", 16)]
        [TestCase(null, 16)]
        public void InvalidNameShouldThrowException(string name, int capacity)
        {
            Assert.That(() =>
            {
                FootballTeam team = new FootballTeam(name, capacity);
            }, Throws.ArgumentException, "Name cannot be null or empty!");
        }

        [TestCase("Name", -1)]
        [TestCase("Name", 14)]
        public void InvalidCapacityShouldThrowException(string name, int capacity)
        {
            Assert.That(() =>
            {
                FootballTeam team = new FootballTeam(name, capacity);
            }, Throws.ArgumentException, "Capacity min value = 15");
        }

        [TestCase("Name", 16)]
        public void CtorShouldWorkCorrectly(string name, int capacity)
        {
            FootballTeam team = new FootballTeam(name, capacity);

            Assert.That(team.Name, Is.EqualTo(name));
            Assert.That(team.Capacity, Is.EqualTo(16));
            Assert.That(team.Players.Count, Is.EqualTo(0));
        }

        [TestCase("Name", 15)]
        public void AddNewPlayerWhenIsFull(string name, int capacity)
        {
            FootballTeam team = new FootballTeam(name, capacity);

            for (int i = 1; i <= team.Players.Count + 1; i++)
                team.AddNewPlayer(new FootballPlayer("Name" + i, i, "Midfielder"));

            string response = team.AddNewPlayer(new FootballPlayer("Last", 16, "Goalkeeper"));

            Assert.That(response, Is.EqualTo("No more positions available!"));
        }

        [TestCase("Name", 15)]
        public void AddNewPlayer(string name, int capacity)
        {
            FootballTeam team = new FootballTeam(name, capacity);
            FootballPlayer player = new FootballPlayer("player", 1, "Midfielder");
            string response = team.AddNewPlayer(player);

            Assert.That(response, Is.EqualTo($"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}"));
        }

        [TestCase("Name", 15)]
        public void TestPickPlayer(string name, int capacity)
        {
            FootballTeam team = new FootballTeam(name, capacity);
            FootballPlayer player1 = new FootballPlayer("Name1", 1, "Goalkeeper");
            FootballPlayer player2 = new FootballPlayer("Name2", 2, "Midfielder");
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player2);

            var returnedPlayer = team.PickPlayer("Name2");

            Assert.That(returnedPlayer, Is.EqualTo(player2));
        }

        [TestCase("Name", 15)]
        public void TestPlayerScore(string name, int capacity)
        {
            FootballTeam team = new FootballTeam(name, capacity);
            FootballPlayer player1 = new FootballPlayer("Name1", 1, "Goalkeeper");
            FootballPlayer player2 = new FootballPlayer("Name2", 2, "Midfielder");
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player2);

            string response = team.PlayerScore(2);
            var returnedPlayer = team.PickPlayer("Name2");

            Assert.That(returnedPlayer.ScoredGoals, Is.EqualTo(1));
            Assert.That(response, Is.EqualTo($"{returnedPlayer.Name} scored and now has {returnedPlayer.ScoredGoals} for this season!"));
        }
    }
}