using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Shopping_Spree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] allPersons = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<Person> persons = new List<Person>();

            foreach (var person in allPersons)
            {
                string[] personDetails = person.Split("=", StringSplitOptions.RemoveEmptyEntries);

                persons.Add(new Person(personDetails[0], int.Parse(personDetails[1])));
            }

            string[] allProducts = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<Product> products = new List<Product>();

            foreach (var product in allProducts)
            {
                string[] productDetails = product.Split("=", StringSplitOptions.RemoveEmptyEntries);

                products.Add(new Product(productDetails[0], int.Parse(productDetails[1])));
            }

            string purchase = Console.ReadLine();

            while (purchase != "END")
            {
                string[] purchaseDetails = purchase
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person person = persons.Find(p => p.Name == purchaseDetails[0]);
                Product product = products.Find(p => p.Name == purchaseDetails[1]);

                if (person.IsPersonHaveEnoughMoney(person, product))
                {
                    person.Buy(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }

                purchase = Console.ReadLine();
            }

            foreach (var person in persons)
            {
                if (person.BagOfProducts.Count > 0)
                {
                    Console.Write($"{person.Name} - ");
                    Console.WriteLine(string.Join(", ", person.BagOfProducts));
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }

    class Person
    {
        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<string>();
        }

        public string Name { get; set; }

        public int Money { get; set; }

        public List<string> BagOfProducts { get; set; }

        public void Buy(Product product)
        {
            BagOfProducts.Add(product.Name);
            Money -= product.Cost;
        }

        public bool IsPersonHaveEnoughMoney(Person person, Product product)
        {
            if (product.Cost <= person.Money)
            {
                return true;
            }

            return false;
        }
    }

    class Product
    {
        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name { get; set; }

        public int Cost { get; set; }
    }
}
