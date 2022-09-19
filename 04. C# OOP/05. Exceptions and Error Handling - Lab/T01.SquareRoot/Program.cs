﻿using System;

namespace Т01.SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            try
            {
                if (num < 0)
                {
                    throw new ArgumentException("Invalid number.");
                }

                Console.WriteLine(Math.Sqrt(num));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
