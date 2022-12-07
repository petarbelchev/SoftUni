﻿using Easter.Models.Eggs.Contracts;
using Easter.Utilities.Messages;
using System;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private string name;
        private int energyRequired;

        public Egg(string name, int energyRequired)
        {
            Name = name;
            EnergyRequired = energyRequired;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEggName);
                }
                name = value;
            }
        }

        public int EnergyRequired
        {
            get { return energyRequired; }
            private set
            {
                energyRequired = value;
                if (energyRequired < 0)
                {
                    energyRequired = 0;
                }
            }
        }

        public void GetColored()
            => EnergyRequired -= 10;

        public bool IsDone()
            => EnergyRequired == 0;
    }
}
