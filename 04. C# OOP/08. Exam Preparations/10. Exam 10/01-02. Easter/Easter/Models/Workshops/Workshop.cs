using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System.Linq;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (bunny.Energy > 0 && bunny.Dyes.Any(d => !d.IsFinished()) && !egg.IsDone())
            {
                IDye dye = bunny.Dyes.First(d => !d.IsFinished());
                bunny.Work();
                dye.Use();
                egg.GetColored();
            }
        }
    }
}
