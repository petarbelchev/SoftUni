namespace PlanetWars.Repositories
{
    using Contracts;
    using PlanetWars.Models.MilitaryUnits.Contracts;

    using System.Collections.Generic;
    using System.Linq;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly ICollection<IMilitaryUnit> units;

        public UnitRepository()
        {
            units = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models
            => (IReadOnlyCollection<IMilitaryUnit>)units;

        public void AddItem(IMilitaryUnit model)
            => units.Add(model);

        public IMilitaryUnit FindByName(string unitTypeName)
            => units.FirstOrDefault(u => u.GetType().Name == unitTypeName);

        public bool RemoveItem(string unitTypeName)
            => units.Remove(FindByName(unitTypeName));
    }
}
