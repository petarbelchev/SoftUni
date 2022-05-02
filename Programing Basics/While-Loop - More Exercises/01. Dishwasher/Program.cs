using System;

namespace _01._Dishwasher
{
    class Program
    {
        static void Main(string[] args)
        {
            int bottles = int.Parse(Console.ReadLine());
            int detergentMl = bottles * 750;
            int counter = 0;
            int dishes = 0;
            int plates = 0;
            int sausepan = 0;

            while (true)
            {
                string input = Console.ReadLine();

                counter++;

                if (input == "End")
                {
                    break;
                }
                else
                {
                    dishes = int.Parse(input);
                }

                if (counter != 3)
                {
                    if (detergentMl >= dishes * 5)
                    {
                        detergentMl -= dishes * 5;
                        plates += dishes;
                    }
                    else
                    {
                        detergentMl -= dishes * 5;
                        break;
                    }
                }

                if (counter == 3)
                {
                    if (detergentMl >= dishes * 15)
                    {
                        detergentMl -= dishes * 15;
                        sausepan += dishes;
                        counter = 0;
                    }
                    else
                    {
                        detergentMl -= dishes * 15;
                        break;
                    }
                }
            }

            if (detergentMl >= 0)
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{plates} dishes and {sausepan} pots were washed.");
                Console.WriteLine($"Leftover detergent {detergentMl} ml.");
            }
            else
            {
                Console.WriteLine($"Not enough detergent, {Math.Abs(detergentMl)} ml. more necessary!");
            }
        }
    }
}
