using System;

namespace _05._Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameActor = Console.ReadLine();
            double pointsAcademy = double.Parse(Console.ReadLine());
            int quantityJury = int.Parse(Console.ReadLine());

            double pointsSum = pointsAcademy;
            bool isGotNominee = false;

            for (int currentJury = 1; currentJury <= quantityJury; currentJury++)
            {
                string nameCurrentJury = Console.ReadLine();
                pointsSum += (double.Parse(Console.ReadLine()) * nameCurrentJury.Length) / 2;

                if (pointsSum >= 1250.5)
                {
                    Console.WriteLine($"Congratulations, {nameActor} got a nominee for leading role with {pointsSum:f1}!");
                    isGotNominee = true;
                    break;
                }
            }

            if (!isGotNominee)
            {
                Console.WriteLine($"Sorry, {nameActor} you need {1250.5 - pointsSum:f1} more!");
            }
        }
    }
}
