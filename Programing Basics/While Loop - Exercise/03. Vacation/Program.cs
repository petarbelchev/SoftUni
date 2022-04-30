using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoneyForVacantion = double.Parse(Console.ReadLine());
            double avalableMoney = double.Parse(Console.ReadLine());
            int daysSpend = 0;
            int daysTotal = 0;

            while (true)
            {
                string typeTransaction = Console.ReadLine();
                double amoundTransaction = double.Parse(Console.ReadLine());
                daysTotal++;

                if (typeTransaction == "spend")
                {
                    avalableMoney -= amoundTransaction;

                    if (avalableMoney < 0)
                    {
                        avalableMoney = 0;
                    }

                    daysSpend++;
                }

                if (typeTransaction == "save")
                {
                    avalableMoney += amoundTransaction;
                    daysSpend = 0;
                }

                if (daysSpend >= 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine($"{daysTotal}");
                    break;
                }

                if (avalableMoney >= neededMoneyForVacantion)
                {
                    Console.WriteLine($"You saved the money for {daysTotal} days.");
                    break;
                }
            }
        }
    }
}
