using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Product, int> products = new Dictionary<Product, int>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "buy")
            {
                string[] productDetails = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string productName = productDetails[0];
                double price = double.Parse(productDetails[1]);
                int quantity = int.Parse(productDetails[2]);

                if (products.Any(p => p.Key.Name == productName))
                {
                    Product thisProduct = products.Keys
                        .Where(p => p.Name == productName).FirstOrDefault();

                    products[thisProduct] += quantity;

                    if (thisProduct.Price != price)
                    {
                        thisProduct.Price = price;
                    }
                }
                else
                {
                    Product newProduct = new Product(productDetails[0], double.Parse(productDetails[1]));

                    products.Add(newProduct, quantity);
                }
            }

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key.Name} -> {product.Key.Price * product.Value:f2}");
            }
        }
    }

    class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"{Name} {Price}";
        }
    }
}
