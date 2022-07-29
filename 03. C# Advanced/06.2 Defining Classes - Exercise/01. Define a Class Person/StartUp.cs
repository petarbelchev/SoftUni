using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            var firstPerson = new Person("Petar", 32);

            var secondPerson = new Person()
            {
                Name = "Tsvetelina",
                Age = 33
            };
        }
    }
}
