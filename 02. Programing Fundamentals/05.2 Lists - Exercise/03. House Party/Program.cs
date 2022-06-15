using System;
using System.Collections.Generic;

namespace _03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfInvitations = int.Parse(Console.ReadLine());

            List<string> guestList = new List<string>();

            for (int invitation = 1; invitation <= numOfInvitations; invitation++)
            {
                string[] answer = Console.ReadLine().Split();
                string nameGuest = answer[0];
                string goingOrNot = answer[2];

                if (goingOrNot == "going!")
                {
                    if (guestList.Contains(nameGuest))
                    {
                        Console.WriteLine($"{nameGuest} is already in the list!");
                    }
                    else
                    {
                        guestList.Add(nameGuest);
                    }
                }
                else if (goingOrNot == "not")
                {
                    if (guestList.Contains(nameGuest))
                    {
                        guestList.Remove(nameGuest);
                    }
                    else
                    {
                        Console.WriteLine($"{nameGuest} is not in the list!");
                    }
                }
            }

            foreach (string name in guestList)
            {
                Console.WriteLine(name);
            }
        }
    }
}
