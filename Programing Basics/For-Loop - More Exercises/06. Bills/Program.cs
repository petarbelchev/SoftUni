using System;

namespace _06._Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            int monthQuantity = int.Parse(Console.ReadLine());
            double electricityBills = 0;
            double waterBills = 20 * monthQuantity;
            double internetBills = 15 * monthQuantity;
            double otherBills = 0;

            for (int i = 0; i < monthQuantity; i++)
            {
                electricityBills += double.Parse(Console.ReadLine());
                otherBills = (electricityBills + waterBills + internetBills) + ((electricityBills + waterBills + internetBills) * 0.2);
            }

            Console.WriteLine($"Electricity: {electricityBills:f2} lv");
            Console.WriteLine($"Water: {waterBills:f2} lv");
            Console.WriteLine($"Internet: {internetBills:f2} lv");
            Console.WriteLine($"Other: {otherBills:f2} lv");
            Console.WriteLine($"Average: {(electricityBills + waterBills + internetBills + otherBills) / monthQuantity:f2} lv");
        }
    }
}
