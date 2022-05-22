using System;

namespace _09._Padawan_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceOfLightsabers = double.Parse(Console.ReadLine());
            double priceOfRobes = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());

            double countOfLightsabers = Math.Ceiling(countOfStudents + (countOfStudents * 0.1));
            double countOfBelts = countOfStudents;

            if (countOfBelts > 5)
            {
                countOfBelts -= countOfStudents / 6;
            }

            double countOfRobes = countOfStudents;

            double totalPriceForLightsabers = priceOfLightsabers * countOfLightsabers;
            double totalPriceForRobes = priceOfRobes * countOfRobes;
            double totalPriceForBelts = priceOfBelts * countOfBelts;

            double totalPriceAll = totalPriceForLightsabers + totalPriceForBelts + totalPriceForRobes;

            bool isMoneyEnough = amountOfMoney >= totalPriceAll;

            if (isMoneyEnough)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPriceAll:f2}lv.");
            }
            else
            {
                Console.WriteLine($" John will need {totalPriceAll - amountOfMoney:f2}lv more.");
            }
        }
    }
}
