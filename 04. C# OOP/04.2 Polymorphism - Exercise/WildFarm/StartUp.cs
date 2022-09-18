using System;
using System.Collections.Generic;
using System.Linq;
using WildFarm.Animals;
using WildFarm.Foods;

namespace WildFarm
{
    public class StartUp
    {
        static void Main()
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "End") break;

                string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string type = cmdArgs[0];

                Animal animal = null;

                switch (type)
                {
                    case "Cat": animal = new Cat(cmdArgs[1], double.Parse(cmdArgs[2]), cmdArgs[3], cmdArgs[4]); break;
                    case "Dog": animal = new Dog(cmdArgs[1], double.Parse(cmdArgs[2]), cmdArgs[3]); break;
                    case "Hen": animal = new Hen(cmdArgs[1], double.Parse(cmdArgs[2]), double.Parse(cmdArgs[3])); break;
                    case "Mouse": animal = new Mouse(cmdArgs[1], double.Parse(cmdArgs[2]), cmdArgs[3]); break;
                    case "Owl": animal = new Owl(cmdArgs[1], double.Parse(cmdArgs[2]), double.Parse(cmdArgs[3])); break;
                    case "Tiger": animal = new Tiger(cmdArgs[1], double.Parse(cmdArgs[2]), cmdArgs[3], cmdArgs[4]); break;
                }

                animal.ProduceSound();
                animals.Add(animal);

                cmd = Console.ReadLine();

                if (cmd == "End") break;

                cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                type = cmdArgs[0];
                int quantity = int.Parse(cmdArgs[1]);

                Food food = null;

                switch (type)
                {
                    case "Fruit": food = new Fruit(quantity); break;
                    case "Meat": food = new Meat(quantity); break;
                    case "Seeds": food = new Seeds(quantity); break;
                    case "Vegetable": food = new Vegetable(quantity); break;
                }

                animals.Last().Eat(food);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
