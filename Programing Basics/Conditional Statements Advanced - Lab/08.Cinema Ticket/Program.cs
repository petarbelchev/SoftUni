﻿using System;

namespace _08.Cinema_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();

            if (day == "Monday" || day == "Tuesday" || day == "Friday")
            {
                Console.WriteLine(12);
            }
            else if (day == "Wednesday" || day == "Thursday")
            {
                Console.WriteLine(14);
            }
            else
            {
                Console.WriteLine(16);
            }
        }
    }
}
