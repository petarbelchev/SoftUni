namespace Raiding
{
    public class Warrior : BaseHero
    {
        public Warrior(string heroName)
            : base(heroName)
        {
            this.Power = 100;
        }
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
