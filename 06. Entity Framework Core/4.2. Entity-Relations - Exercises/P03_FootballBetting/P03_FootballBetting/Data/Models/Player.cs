﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class Player
    {
        public Player()
        {
            PlayerStatistics = new HashSet<PlayerStatistic>();
        }

        [Key]
        public int PlayerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int SquadNumber { get; set; }

        [Required]
        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }
        public Team Team { get; set; }

        [Required]
        [ForeignKey(nameof(Position))]
        public int PositionId { get; set; }
        public Position Position { get; set; }

        [Required]
        public bool IsInjured { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}
