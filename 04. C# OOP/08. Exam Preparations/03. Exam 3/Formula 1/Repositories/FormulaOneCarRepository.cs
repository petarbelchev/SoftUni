namespace Formula1.Repositories
{
    using Contracts;
    using Formula1.Models.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly ICollection<IFormulaOneCar> models;

        public FormulaOneCarRepository()
        {
            this.models = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models
            => (IReadOnlyCollection<IFormulaOneCar>)this.models;

        public void Add(IFormulaOneCar model)
            => this.models.Add(model);

        public IFormulaOneCar FindByName(string model)
            => this.models.FirstOrDefault(m => m.Model == model);

        public bool Remove(IFormulaOneCar model)
            => this.models.Remove(model);
    }
}
