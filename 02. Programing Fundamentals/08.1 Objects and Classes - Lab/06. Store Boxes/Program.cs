using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Store_Boxes
{
    class Item
    {
        public Item(string itemName, double itemPrice)
        {
            Name = itemName;
            Price = itemPrice;
        }

        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Box
    {
        public Box(int serialNumber, Item item, int itemQuantity, double priceForBox)
        {
            SerialNumber = serialNumber;
            Item = item;
            ItemQuantity = itemQuantity;
            PriceForBox = priceForBox;
        }

        public int SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public double PriceForBox { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Box> boxes = new List<Box>();

            while (input != "end")
            {
                string[] itemDetails = input.Split();
                int serialNumber = int.Parse(itemDetails[0]);
                string itemName = itemDetails[1];
                int itemQuantity = int.Parse(itemDetails[2]);
                double itemPrice = double.Parse(itemDetails[3]);
                double priceForBox = itemQuantity * itemPrice;

                Item newItem = new Item(itemName, itemPrice);
                Box newBox = new Box(serialNumber, newItem, itemQuantity, priceForBox);

                boxes.Add(newBox);

                input = Console.ReadLine();
            }

            List<Box> orderedBoxes = boxes.OrderByDescending(box => box.PriceForBox).ToList();

            foreach (Box box in orderedBoxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceForBox:f2}");
            }
        }
    }
}
