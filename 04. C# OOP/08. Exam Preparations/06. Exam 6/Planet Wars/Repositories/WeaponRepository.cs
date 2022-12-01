namespace PlanetWars.Repositories
{
    using Contracts;
    using PlanetWars.Models.Weapons.Contracts;

    using System.Collections.Generic;
    using System.Linq;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private ICollection<IWeapon> weapons;

        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models
            => (IReadOnlyCollection<IWeapon>)weapons;

        public void AddItem(IWeapon model)
            => weapons.Add(model);

        public IWeapon FindByName(string weaponTypeName)
            => weapons.FirstOrDefault(w => w.GetType().Name == weaponTypeName);

        public bool RemoveItem(string weaponTypeName)
            => weapons.Remove(FindByName(weaponTypeName));
    }
}
