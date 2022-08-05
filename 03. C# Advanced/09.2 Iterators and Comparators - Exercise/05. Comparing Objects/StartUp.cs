using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    internal class StartUp
    {
        static void Main()
        {
            var persons = new List<Person>();

            string cmd;

            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] personData = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = personData[0];
                int age = int.Parse(personData[1]);
                string town = personData[2];

                persons.Add(new Person(name, age, town));
            }

            int position = int.Parse(Console.ReadLine()) - 1;

            Person personToCompare = persons[position];

            int equalsCount = 0;
            int notEqualsCount = 0;

            foreach (var person in persons)
            {
                int result = person.CompareTo(personToCompare);

                if (result == 0)
                {
                    equalsCount++;
                }
                else
                {
                    notEqualsCount++;
                }
            }

            if (equalsCount < 2)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalsCount} {notEqualsCount} {persons.Count}");
            }
        }
    }
}
