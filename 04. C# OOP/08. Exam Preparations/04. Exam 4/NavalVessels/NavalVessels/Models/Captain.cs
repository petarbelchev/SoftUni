namespace NavalVessels.Models
{
    using Contracts;
    using NavalVessels.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Captain : ICaptain
    {
        private string fullName;

        public Captain(string fullName)
        {
            this.FullName = fullName;
            this.CombatExperience = 0;
            this.Vessels = new List<IVessel>();
        }

        public string FullName
        {
            get { return this.fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidCaptainName);

                this.fullName = value;
            }
        }

        public int CombatExperience { get; private set; }

        public ICollection<IVessel> Vessels { get; private set; }

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null) 
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);

            this.Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
            => this.CombatExperience += 10;

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.FullName} has {this.CombatExperience} combat experience and commands {this.Vessels.Count} vessels.");

            if (this.Vessels.Count > 0)
            {
                foreach (var vessel in this.Vessels)
                {
                    string vesselType = vessel.GetType().Name;

                    sb.AppendLine($"- {vessel.Name}");
                    sb.AppendLine($" *Type: {vesselType}");
                    sb.AppendLine($" *Armor thickness: {vessel.ArmorThickness}");
                    sb.AppendLine($" *Main weapon caliber: {vessel.MainWeaponCaliber}");
                    sb.AppendLine($" *Speed: {vessel.Speed} knots");
                    string targets = vessel.Targets.Count == 0 ? "None" : string.Join(", ", vessel.Targets);
                    sb.AppendLine($" *Targets: {targets}");
                    
                    string mode;
                    if (vesselType == "Battleship")
                    {
                        mode = (vessel as Battleship).SonarMode == false ? "OFF" : "ON";
                        sb.AppendLine($" *Sonar mode: {mode}");
                    }
                    else
                    {
                        mode = (vessel as Submarine).SubmergeMode == false ? "OFF" : "ON";
                        sb.AppendLine($" *Submerge mode: {mode}");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
