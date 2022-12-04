namespace Gym.Models.Gyms
{
    public class BoxingGym : Gym
    {
        private const int GymCapacity = 15;

        public BoxingGym(string name) 
            : base(name, GymCapacity)
        {
        }
    }
}
