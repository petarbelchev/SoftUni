using System;

namespace _07._Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupsQuantity = int.Parse(Console.ReadLine());

            int Musala = 0;
            int Monblan = 0;
            int Kilimanjaro = 0;
            int K2 = 0;
            int Everest = 0;

            for (int i = 1; i <= groupsQuantity; i++)
            {
                int climbersQuantity = int.Parse(Console.ReadLine());

                if (climbersQuantity <= 5)
                {
                    Musala += climbersQuantity;
                }
                else if (climbersQuantity >= 6 && climbersQuantity <= 12)
                {
                    Monblan += climbersQuantity;
                }
                else if (climbersQuantity >= 13 && climbersQuantity <= 25)
                {
                    Kilimanjaro += climbersQuantity;
                }
                else if (climbersQuantity >= 26 && climbersQuantity <= 40)
                {
                    K2 += climbersQuantity;
                }
                else if (climbersQuantity >= 41)
                {
                    Everest += climbersQuantity;
                }
            }

            double totalClimbers = Musala + Monblan + Kilimanjaro + K2 + Everest;

            Console.WriteLine($"{Musala / totalClimbers * 100:f2}%");
            Console.WriteLine($"{Monblan / totalClimbers * 100:f2}%");
            Console.WriteLine($"{Kilimanjaro / totalClimbers * 100:f2}%");
            Console.WriteLine($"{K2 / totalClimbers * 100:f2}%");
            Console.WriteLine($"{Everest / totalClimbers * 100:f2}%");
        }
    }
}
