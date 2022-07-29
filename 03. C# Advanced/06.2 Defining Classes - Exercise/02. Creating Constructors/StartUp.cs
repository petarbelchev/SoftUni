using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            var firstPerson = new Person();
            var secondPerson = new Person(15);
            var thirdPerson = new Person("Petar", 32);
        }
    }
}
