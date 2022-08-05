using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    internal class StartUp
    {
        static void Main()
        {
            var hashSet = new HashSet<Person>();
            var sortedSet = new SortedSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = personData[0];
                int age = int.Parse(personData[1]);
                var person = new Person(name, age);

                hashSet.Add(person);
                sortedSet.Add(person);
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}
