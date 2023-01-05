﻿using System.Collections.Generic;

namespace CarDealer.DTO
{
    internal class CarDTO
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public long TravelledDistance { get; set; }
        public ICollection<int> PartsId { get; set; } = new List<int>();
    }
}
