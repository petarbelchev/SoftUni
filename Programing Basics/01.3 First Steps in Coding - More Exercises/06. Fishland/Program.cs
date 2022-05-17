using System;

namespace _06._Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            double skumriyaCenaKg = double.Parse(Console.ReadLine());
            double cacaCenaKg = double.Parse(Console.ReadLine());
            double palamudKg = double.Parse(Console.ReadLine());
            double safridKg = double.Parse(Console.ReadLine());
            int midiKg = int.Parse(Console.ReadLine());
            double midiCenaKg = 7.5;
            double palamudCenaKg = skumriyaCenaKg + (skumriyaCenaKg * 0.6);
            double safridCenaKg = cacaCenaKg + (cacaCenaKg * 0.8);

            double palamudPrice = palamudKg * palamudCenaKg;
            double safridPrice = safridCenaKg * safridKg;
            double midiPrice = midiCenaKg * midiKg;

            double totalPrice = palamudPrice + safridPrice + midiPrice;

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
