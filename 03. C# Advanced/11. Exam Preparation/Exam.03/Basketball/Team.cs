using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> players;

        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            this.players = new List<Player>();
        }

        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public int Count { get => this.players.Count; }

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || 
                string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }

            if (this.OpenPositions == 0)
            {
                return "There are no more open positions.";
            }

            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            this.players.Add(player);
            this.OpenPositions--;

            return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            var playerToRemove = this.players.FirstOrDefault(p => p.Name == name);

            if (playerToRemove != null)
            {
                this.players.Remove(playerToRemove);
                this.OpenPositions++;

                return true;
            }

            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            int initCount = this.players.Count;
            this.players = this.players
                .Where(p => p.Position != position)
                .ToList();

            int removedCount = initCount - this.players.Count;
            this.OpenPositions += removedCount;

            return removedCount;
        }

        public Player RetirePlayer(string name)
        {
            Player playerToRetire = this.players
                .FirstOrDefault(p => p.Name == name);

            if (playerToRetire != null)
            {
                playerToRetire.Retired = true;
            }

            return playerToRetire;
        }

        public List<Player> AwardPlayers(int games)
        {
            return this.players.Where(p => p.Games >= games).ToList();
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}:");
            foreach (var player in this.players.Where(p => p.Retired == false))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
