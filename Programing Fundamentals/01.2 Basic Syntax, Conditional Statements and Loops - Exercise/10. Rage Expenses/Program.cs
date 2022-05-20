using System;

namespace _10._Rage_Expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double expenses = 0;
            int keyboardTrashedCounter = 0;

            for (int lost = 1; lost <= lostGamesCount; lost++)
            {
                bool isHeadsetTrashed = false;
                bool isMouseTrashed = false;

                if (lost % 2 == 0)
                {
                    expenses += headsetPrice;
                    isHeadsetTrashed = true;
                }

                if (lost % 3 == 0)
                {
                    expenses += mousePrice;
                    isMouseTrashed = true;
                }

                if (isHeadsetTrashed && isMouseTrashed)
                {
                    expenses += keyboardPrice;
                    keyboardTrashedCounter++;

                    if (keyboardTrashedCounter % 2 == 0)
                    {
                        expenses += displayPrice;
                    }
                }
            }

            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}
