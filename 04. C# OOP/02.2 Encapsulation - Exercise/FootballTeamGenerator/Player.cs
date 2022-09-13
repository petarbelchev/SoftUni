using System;

namespace FootballTeamGenerator
{
    internal class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.", nameof(this.name));
                }
                this.name = value;
            }
        }
        public int Endurance 
        { 
            get => this.endurance;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception($"Endurance should be between 0 and 100.");
                }
                this.endurance = value;
            } 
        }
        public int Sprint
        {
            get => this.sprint;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception($"Sprint should be between 0 and 100.");
                }
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get => this.dribble;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception($"Dribble should be between 0 and 100.");
                }
                this.dribble = value;
            }
        }
        public int Passing
        {
            get => this.passing;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception($"Passing should be between 0 and 100.");
                }
                this.passing = value;
            }
        }
        public int Shooting
        {
            get => this.shooting;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception($"Shooting should be between 0 and 100.");
                }
                this.shooting = value;
            }
        }

        internal double OverallSkillLevel()
        {
            double sumOfStats = this.endurance + this.sprint + this.dribble + this.passing + this.shooting;

            return sumOfStats / 5;
        }
    }
}
