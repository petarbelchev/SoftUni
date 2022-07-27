using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Person> persons = ReadPersons();

        FilterPersonsByAgeThreshold(ref persons);

        Print(persons);
    }

    static void Print(List<Person> persons)
    {
        string[] formatOfPrint = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        Action<Person> print = person => Console.WriteLine($"{person.Name} - {person.Age}");
        
        if (formatOfPrint.Length == 1)
        {
            if (formatOfPrint[0] == "name")
                print = person => Console.WriteLine($"{person.Name}");

            else if (formatOfPrint[0] == "age")
                print = person => Console.WriteLine($"{person.Age}");
        }

        persons.ForEach(print);
    }

    static void FilterPersonsByAgeThreshold(ref List<Person> persons)
    {
        string conditionInput = Console.ReadLine();
        int ageThreshold = int.Parse(Console.ReadLine());

        Func<Person, bool> condition = person => person.Age >= ageThreshold;

        if (conditionInput == "younger")
            condition = person => person.Age < ageThreshold;

        persons = persons.Where(condition).ToList();
    }

    static List<Person> ReadPersons()
    {
        List<Person> persons = new List<Person>();

        int countOfPersons = int.Parse(Console.ReadLine());
        for (int i = 0; i < countOfPersons; i++)
        {
            string[] personData = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            persons.Add(new Person(personData[0], int.Parse(personData[1])));
        }

        return persons;
    }
}

class Person
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; set; }
    public int Age { get; set; }
}
