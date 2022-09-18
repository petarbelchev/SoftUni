namespace Raiding
{
    public class Druid : BaseHero
    {
        public Druid(string heroName)
            : base(heroName)
        {
            this.Power = 80;
        }
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
