using System;
using System.Collections.Generic;
using System.Linq;

namespace T06.Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var animals = new List<Animal>();

            while (input != "Beast!")
            {
                string[] animalData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string type = input;
                string name = animalData[0];
                int age = int.Parse(animalData[1]);
                string gender = animalData[2];

                try
                {
                    if (type == "Cat")
                    {
                        animals.Add(new Cat(name, age, gender));
                    }
                    else if (type == "Dog")
                    {
                        animals.Add(new Dog(name, age, gender));
                    }
                    else if (type == "Frog")
                    {
                        animals.Add(new Frog(name, age, gender));
                    }
                    else if (type == "Kitten")
                    {
                        animals.Add(new Kitten(name, age));
                    }
                    else if (type == "Tomcat")
                    {
                        animals.Add(new Tomcat(name, age));
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
