using System;

namespace _01._Oscars_ceremony
{
    class Program
    {
        static void Main(string[] args)
        {
            int rent = int.Parse(Console.ReadLine());
            double statuettePrice = rent - (rent * 0.3);
            double catering = statuettePrice - (statuettePrice * 0.15);
            double sound = catering / 2;
            double totalPrice = rent + statuettePrice + catering + sound;

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
