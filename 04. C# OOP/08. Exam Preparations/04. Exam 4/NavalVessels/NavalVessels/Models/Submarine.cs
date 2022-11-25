namespace NavalVessels.Models
{
    using System.Text;

    public class Submarine : Vessel
    {
        private const double ArmorThickness = 200;

        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, ArmorThickness)
        {
            this.SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }

        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode == false)
            {
                this.SubmergeMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                this.SubmergeMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            string submergeMode = this.SubmergeMode == false ? "OFF" : "ON";
            sb.AppendLine($" *Submerge mode: {submergeMode}");
            return sb.ToString().TrimEnd();
        }
    }
}
