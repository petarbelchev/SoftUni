using System;

namespace _07._Football_League
{
    class Program
    {
        static void Main(string[] args)
        {
            int allSeats = int.Parse(Console.ReadLine());
            int allFans = int.Parse(Console.ReadLine());
            int fansA = 0;
            int fansB = 0;
            int fansV = 0;
            int fansG = 0;

            for (int i = 1; i <= allFans; i++)
            {
                char sector = char.Parse(Console.ReadLine());

                switch (sector)
                {
                    case 'A':
                        fansA++;
                        break;
                    case 'B':
                        fansB++;
                        break;
                    case 'V':
                        fansV++;
                        break;
                    case 'G':
                        fansG++;
                        break;
                }
            }

            double percentA = ((double)fansA / allFans) * 100;
            double percentB = ((double)fansB / allFans) * 100;
            double percentV = ((double)fansV / allFans) * 100;
            double percentG = ((double)fansG / allFans) * 100;
            double percentAllSeats = ((double)allFans / allSeats) * 100;

            Console.WriteLine($"{percentA:f2}%");
            Console.WriteLine($"{percentB:f2}%");
            Console.WriteLine($"{percentV:f2}%");
            Console.WriteLine($"{percentG:f2}%");
            Console.WriteLine($"{percentAllSeats:f2}%");
        }
    }
}
