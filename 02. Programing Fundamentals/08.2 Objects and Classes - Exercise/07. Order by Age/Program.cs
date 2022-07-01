using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] personDetails = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = personDetails[0];
                string id = personDetails[1];
                int age = int.Parse(personDetails[2]);
                if (persons.Any(p => p.Id == id))
                {
                    foreach (Person person in persons)
                    {
                        if (person.Id == id)
                        {
                            person.Name = name;
                            person.Age = age;
                        }
                    }
                }
                else
                {
                    persons.Add(new Person(name, id, age));
                }

                input = Console.ReadLine();
            }

            persons = persons.OrderBy(p => p.Age).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, persons));
        }
    }

    class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }

        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"{Name} with ID: {Id} is {Age} years old.";
        }
    }
}
