namespace NavalVessels.Models
{
    using System.Text;

    public class Battleship : Vessel
    {
        private const double ArmorThickness = 300;

        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, ArmorThickness)
        {
            this.SonarMode = false;
        }

        public bool SonarMode { get; private set; }

        public void ToggleSonarMode()
        {
            if (this.SonarMode == false)
            {
                this.SonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                this.SonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            string sonarMode = this.SonarMode == false ? "OFF" : "ON";
            sb.AppendLine($" *Sonar mode: {sonarMode}");
            return sb.ToString().TrimEnd();
        }
    }
}
