using System;

namespace _06._Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int visochina = int.Parse(Console.ReadLine());
            int daljina = int.Parse(Console.ReadLine());

            int brParcheta = visochina * daljina;
            int brVzetiParcheta = 0;

            while (brVzetiParcheta < brParcheta)
            {
                string input = Console.ReadLine();

                if (input == "STOP")
                {
                    Console.WriteLine($"{brParcheta - brVzetiParcheta} pieces are left.");
                    break;
                }
                else
                {
                    brVzetiParcheta += int.Parse(input);

                    if (brParcheta <= brVzetiParcheta)
                    {
                        Console.WriteLine($"No more cake left! You need {brVzetiParcheta - brParcheta} pieces more.");
                        break;
                    }
                }
            }
        }
    }
}
