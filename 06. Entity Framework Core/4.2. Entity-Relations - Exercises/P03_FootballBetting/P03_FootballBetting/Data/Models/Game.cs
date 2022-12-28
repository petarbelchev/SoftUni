using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class Game
    {
        public Game()
        {
            PlayerStatistics = new HashSet<PlayerStatistic>();
            Bets = new HashSet<Bet>();
        }

        [Key]
        public int GameId { get; set; }

        [Required]
        [ForeignKey(nameof(HomeTeam))]
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        [Required]
        [ForeignKey(nameof(AwayTeam))]
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public float HomeTeamBetRate { get; set; }

        [Required]
        public float AwayTeamBetRate { get; set; }

        [Required]
        public float DrawBetRate { get; set; }

        [Required]
        [MaxLength(5)]
        public string Result { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; }

        [InverseProperty(nameof(Bet.Game))]
        public ICollection<Bet> Bets { get; set; }
    }
}
