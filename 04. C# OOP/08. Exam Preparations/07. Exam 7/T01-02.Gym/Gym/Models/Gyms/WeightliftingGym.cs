namespace Gym.Models.Gyms
{
    public class WeightliftingGym : Gym
    {
        private const int GymCapacity = 20;

        public WeightliftingGym(string name)
            : base(name, GymCapacity)
        {
        }
    }
}
