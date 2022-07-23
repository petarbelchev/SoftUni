using System;
using System.Collections.Generic;

namespace _08._SoUnPar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regularReservations = new HashSet<string>();
            HashSet<string> vipReservations = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "PARTY")
            {
                if (char.IsDigit(input[0]))
                    vipReservations.Add(input);
                else
                    regularReservations.Add(input);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "END")
            {
                if (char.IsDigit(input[0]))
                    vipReservations.Remove(input);
                else
                    regularReservations.Remove(input);

                input = Console.ReadLine();
            }

            Console.WriteLine(vipReservations.Count + regularReservations.Count);

            if (vipReservations.Count > 0)
                Console.WriteLine(string.Join(Environment.NewLine, vipReservations));

            if (regularReservations.Count > 0)
                Console.WriteLine(string.Join(Environment.NewLine, regularReservations));
        }
    }
}
