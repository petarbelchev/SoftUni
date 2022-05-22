using System;

namespace _05._Series
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int serialsQuantity = int.Parse(Console.ReadLine());
            bool isBudgetEnough = true;

            for (int currentSerial = 1; currentSerial <= serialsQuantity; currentSerial++)
            {
                string nameCurrentSerial = Console.ReadLine();
                double priceCurrentSerial = double.Parse(Console.ReadLine());

                if (nameCurrentSerial == "Thrones")
                {
                    priceCurrentSerial -= priceCurrentSerial * 0.5;
                }
                else if (nameCurrentSerial == "Lucifer")
                {
                    priceCurrentSerial -= priceCurrentSerial * 0.4;
                }
                else if (nameCurrentSerial == "Protector")
                {
                    priceCurrentSerial -= priceCurrentSerial * 0.3;
                }
                else if (nameCurrentSerial == "TotalDrama")
                {
                    priceCurrentSerial -= priceCurrentSerial * 0.2;
                }
                else if (nameCurrentSerial == "Area")
                {
                    priceCurrentSerial -= priceCurrentSerial * 0.1;
                }

                priceCurrentSerial = Math.Round(priceCurrentSerial, 2);

                if (budget < priceCurrentSerial)
                {
                    isBudgetEnough = false;
                }

                budget -= priceCurrentSerial;
                budget = Math.Round(budget, 2);
            }

            if (isBudgetEnough)
            {
                Console.WriteLine($"You bought all the series and left with {budget:f2} lv.");
            }
            else
            {
                Console.WriteLine($"You need {Math.Abs(budget):f2} lv. more to buy the series!");
            }
        }
    }
}
