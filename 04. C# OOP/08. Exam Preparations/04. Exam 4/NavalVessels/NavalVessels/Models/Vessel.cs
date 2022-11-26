namespace NavalVessels.Models
{
    using Contracts;
    using NavalVessels.Utilities.Messages;

    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double initialArmourThickness;

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.ArmorThickness = armorThickness;
            this.initialArmourThickness = armorThickness;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.Targets = new HashSet<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);

                this.name = value;
            }
        }

        public ICaptain Captain
        {
            get => this.captain;
            set
            {
                if (value == null)
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);

                this.captain = value;
            }
        }

        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber { get; protected set; }

        public double Speed { get; protected set; }

        public ICollection<string> Targets { get; private set; }

        public void Attack(IVessel target)
        {
            if (target == null)
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);

            double armourLeft = target.ArmorThickness - this.MainWeaponCaliber;

            if (armourLeft > 0)
            {
                target.ArmorThickness = armourLeft;
            }
            else
            {
                target.ArmorThickness = 0;
            }

            this.Targets.Add(target.Name);
        }

        public void RepairVessel()
            => this.ArmorThickness = initialArmourThickness;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {this.Speed} knots");

            string targetsReport = this.Targets.Count == 0 ? "None" : string.Join(", ", this.Targets);

            sb.AppendLine($" *Targets: {targetsReport}");

            return sb.ToString().TrimEnd();
        }
    }
}
