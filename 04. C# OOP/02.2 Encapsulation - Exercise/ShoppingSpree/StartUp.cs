using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main()
        {
            string[] inputOfPeople = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var listOfPeople = new List<Person>();

            foreach (var person in inputOfPeople)
            {
                string[] personData = person
                    .Split('=', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                try
                {
                    listOfPeople.Add(new Person(personData[0], decimal.Parse(personData[1])));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string[] inputOfProducts = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var listOfProducts = new List<Product>();

            foreach (var product in inputOfProducts)
            {
                string[] productData = product
                    .Split('=', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                
                try
                {
                    listOfProducts.Add(new Product(productData[0], decimal.Parse(productData[1])));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "END")
                    break;

                string[] cmdArgs = cmd
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                Person person = listOfPeople.Find(p => p.Name == cmdArgs[0]);
                Product product = listOfProducts.Find(p => p.Name == cmdArgs[1]);

                if (person.Money >= product.Cost)
                {
                    person.BagOfProducts.Add(product);
                    person.Money -= product.Cost;
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                else
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
            }

            foreach (var person in listOfPeople)
            {
                if (person.BagOfProducts.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - " + string.Join(", ",person.BagOfProducts));
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }
}
