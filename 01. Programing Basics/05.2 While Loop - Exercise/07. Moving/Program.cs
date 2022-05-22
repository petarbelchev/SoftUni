using System;

namespace _07._Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int shirochina = int.Parse(Console.ReadLine());
            int daljina = int.Parse(Console.ReadLine());
            int visochina = int.Parse(Console.ReadLine());

            int obemKvartira = shirochina * daljina * visochina;
            int brKashoni = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Done")
                {
                    Console.WriteLine($"{obemKvartira - brKashoni} Cubic meters left.");
                    break;
                }
                else
                {
                    brKashoni += int.Parse(input);

                    if (brKashoni >= obemKvartira)
                    {
                        Console.WriteLine($"No more free space! You need {brKashoni - obemKvartira} Cubic meters more.");
                        break;
                    }
                }
            }

        }
    }
}
