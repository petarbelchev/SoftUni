using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    internal class Team
    {
        private string teamName;
        private List<Player> players;

        public Team(string name)
        {
            this.TeamName = name;
            this.players = new List<Player>();
        }

        public string TeamName
        {
            get => this.teamName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.", nameof(this.teamName));
                }

                this.teamName = value;
            }
        }
        public double Rating
        {
            get
            {
                if (this.players.Count == 0) 
                    return 0;

                return Math.Round(this.players.Select(p => p.OverallSkillLevel()).ToArray().Average());
            }
        }


        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player foundedPlayer = this.players.FirstOrDefault(p => p.Name == playerName);

            if (foundedPlayer == null)
            {
                throw new Exception($"Player {playerName} is not in {this.teamName} team.");
            }

            this.players.Remove(foundedPlayer);
        }
    }
}
