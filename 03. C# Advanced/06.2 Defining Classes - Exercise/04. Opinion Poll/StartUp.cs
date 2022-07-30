using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            int numOfPersons = int.Parse(Console.ReadLine());

            var persons = new List<Person>();

            for (int i = 0; i < numOfPersons; i++)
            {
                string[] personInfo = Console.ReadLine().Split();
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                persons.Add(new Person(name, age));
            }

            Console.WriteLine(
                string.Join(Environment.NewLine, persons
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)));
        }
    }
}
