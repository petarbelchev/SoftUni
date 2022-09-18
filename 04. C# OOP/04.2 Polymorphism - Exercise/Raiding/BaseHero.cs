namespace Raiding
{
    public abstract class BaseHero
    {
        public BaseHero(string heroName)
        {
            this.Name = heroName;
        }
        public string Name { get; protected set; }

        public int Power { get; protected set; }

        public abstract string CastAbility();
    }
}
