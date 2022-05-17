using System;

namespace _03._Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int cargoCount = int.Parse(Console.ReadLine());
            double tonnageAll = 0;
            int tonnageMinibus = 0;
            int tonnageTruck = 0;
            int tonnageTrain = 0;

            for (int i = 1; i <= cargoCount; i++)
            {
                int input = int.Parse(Console.ReadLine());
                tonnageAll += input;

                if (input <= 3)
                {
                    tonnageMinibus += input;
                }
                else if (input >= 4 && input <= 11)
                {
                    tonnageTruck += input;
                }
                else
                {
                    tonnageTrain += input;
                }
            }

            double minibusPrice = tonnageMinibus * 200;
            double truckPrice = tonnageTruck * 175;
            double trainPrice = tonnageTrain * 120;

            double averPricePerTone = (minibusPrice + truckPrice + trainPrice) / tonnageAll;
            double percentMinibus = (tonnageMinibus / tonnageAll) * 100;
            double percentTruck = (tonnageTruck / tonnageAll) * 100;
            double percentTrain = (tonnageTrain / tonnageAll) * 100;

            Console.WriteLine($"{averPricePerTone:f2}");
            Console.WriteLine($"{percentMinibus:f2}%");
            Console.WriteLine($"{percentTruck:f2}%");
            Console.WriteLine($"{percentTrain:f2}%");
        }
    }
}
