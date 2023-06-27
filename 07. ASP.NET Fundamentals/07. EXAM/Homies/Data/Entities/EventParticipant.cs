﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Data.Entities
{
	public class EventParticipant
	{
		[Required]
		[ForeignKey(nameof(Helper))]
		public string HelperId { get; set; } = null!;

		public User Helper { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Event))]
        public int EventId { get; set; }

		public Event Event { get; set; } = null!;
    }
}
