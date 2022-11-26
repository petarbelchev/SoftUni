namespace NavalVessels.Core
{
    using Contracts;
    using NavalVessels.Models;
    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories;
    using NavalVessels.Repositories.Contracts;
    using NavalVessels.Utilities.Messages;
    using System.Collections.Generic;
    using System.Linq;

    public class Controller : IController
    {
        private IRepository<IVessel> vessels;
        private ICollection<ICaptain> captains;

        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = this.captains.FirstOrDefault(c => c.FullName == selectedCaptainName);

            if (captain == null)
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);

            IVessel vessel = this.vessels.FindByName(selectedVesselName);

            if (vessel == null)
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);

            if (vessel.Captain != null)
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);

            vessel.Captain = captain;
            captain.AddVessel(vessel);

            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attacker = this.vessels.FindByName(attackingVesselName);
            
            if (attacker == null)
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);

            var deffender = this.vessels.FindByName(defendingVesselName);

            if (deffender == null)
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);

            if (attacker.ArmorThickness == 0)
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);

            if (deffender.ArmorThickness == 0)
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);

            attacker.Attack(deffender);
            attacker.Captain.IncreaseCombatExperience();
            deffender.Captain.IncreaseCombatExperience();

            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, deffender.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            var captain = this.captains.FirstOrDefault(c => c.FullName == captainFullName);
            
            if (captain == null)
                return string.Format(OutputMessages.CaptainNotFound, captainFullName);

            return captain.Report();
        }

        public string HireCaptain(string fullName)
        {
            var captain = this.captains.FirstOrDefault(c => c.FullName == fullName);
            if (captain != null)
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);

            captain = new Captain(fullName);
            this.captains.Add(captain);

            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = this.vessels.FindByName(name);
            
            if (vessel != null)
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);

            if (vesselType != "Battleship" && vesselType != "Submarine")
                return string.Format(OutputMessages.InvalidVesselType);

            if (vesselType == "Battleship")
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            else
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            
            this.vessels.Add(vessel);

            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string ServiceVessel(string vesselName)
        {
            var vessel = this.vessels.FindByName(vesselName);

            if (vessel == null)
                return string.Format(OutputMessages.VesselNotFound, vesselName);

            vessel.RepairVessel();

            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            var vessel = this.vessels.FindByName(vesselName);

            if (vessel == null) 
                return string.Format(OutputMessages.VesselNotFound, vesselName);

            if (vessel.GetType().Name == "Battleship")
            {
                (vessel as Battleship).ToggleSonarMode();
                return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else
            {
                (vessel as Submarine).ToggleSubmergeMode();
                return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }
        }

        public string VesselReport(string vesselName)
        {
            var vessel = this.vessels.FindByName(vesselName);

            if (vessel == null)
                return string.Format(OutputMessages.VesselNotFound, vesselName);

            return vessel.ToString();
        }
    }
}
