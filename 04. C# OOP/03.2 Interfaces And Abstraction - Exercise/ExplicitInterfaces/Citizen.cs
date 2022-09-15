namespace ExplicitInterfaces
{
    public class Citizen : IPerson, IResident
    {
        private string name;
        private int age;
        private string country;

        public Citizen(string name, string country, int age)
        {
            this.name = name;
            this.age = age;
            this.country = country;
        }

        public string Name => this.name;

        public int Age => this.age;

        public string Country => this.country;

        string IPerson.GetName()
        {
            return this.Name;
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }
    }
}
