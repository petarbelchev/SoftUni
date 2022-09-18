namespace Raiding
{
    public class Rogue : BaseHero
    {
        public Rogue(string heroName)
            : base(heroName)
        {
            this.Power = 80;
        }
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
