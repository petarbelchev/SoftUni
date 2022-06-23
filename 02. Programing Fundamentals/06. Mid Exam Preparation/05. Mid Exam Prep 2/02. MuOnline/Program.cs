using System;

namespace _02._MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialHealth = 100;
            int initialBitcoins = 0;
            int bestRoom = 0;
            int roomsCounter = 0;
            int biggestAttack = 0;
            string[] rooms = Console.ReadLine().Split("|");

            foreach (string room in rooms)
            {
                roomsCounter++;
                string[] cmdArgs = room.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArgs[0];
                int number = int.Parse(cmdArgs[1]);

                switch (command)
                {
                    case "potion":
                        int healthBefore = initialHealth;
                        initialHealth += number;
                        if (initialHealth > 100)
                        {
                            initialHealth = 100;
                        }
                        Console.WriteLine($"You healed for {initialHealth - healthBefore} hp.");
                        Console.WriteLine($"Current health: {initialHealth} hp.");
                        break;

                    case "chest":
                        initialBitcoins += number;
                        Console.WriteLine($"You found {number} bitcoins.");
                        break;

                    default:
                        initialHealth -= number;
                        if (number > biggestAttack)
                        {
                            biggestAttack = number;
                            bestRoom = roomsCounter;
                        }
                        if (initialHealth > 0)
                        {
                            Console.WriteLine($"You slayed {command}.");
                        }
                        else
                        {
                            Console.WriteLine($"You died! Killed by {command}.");
                            Console.WriteLine($"Best room: {bestRoom}");

                            return;
                        }
                        break;
                }
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {initialBitcoins}");
            Console.WriteLine($"Health: {initialHealth}");
        }
    }
}
