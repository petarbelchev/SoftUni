using System;

namespace _04._Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int ageLili = int.Parse(Console.ReadLine());
            double washMachinePrice = double.Parse(Console.ReadLine());
            int sigleToyPrice = int.Parse(Console.ReadLine());

            double money = 0;
            double moneyBrother = 0;
            int toysQuantity = 0;

            for (int i = 1; i <= ageLili; i++)
            {
                if (i % 2 != 0)
                {
                    toysQuantity += 1;
                }
                else
                {
                    money += (i / 2) * 10;
                    moneyBrother += 1;
                }
            }

            money -= moneyBrother;
            money += toysQuantity * sigleToyPrice;

            if (money >= washMachinePrice)
            {
                Console.WriteLine($"Yes! {money - washMachinePrice:f2}");
            }
            else
            {
                Console.WriteLine($"No! {washMachinePrice - money:f2}");
            }
        }
    }
}
