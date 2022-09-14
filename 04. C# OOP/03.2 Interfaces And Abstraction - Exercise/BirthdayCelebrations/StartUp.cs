using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main()
        {
            List<IBirthable> birthables = new List<IBirthable>();

            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "End") break;

                string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs[0] == "Citizen")
                {
                    var citizen = new Citizen(cmdArgs[1], int.Parse(cmdArgs[2]), cmdArgs[3], cmdArgs[4]);
                    birthables.Add(citizen);
                }
                else if (cmdArgs[0] == "Pet")
                {
                    var pet = new Pet(cmdArgs[1], cmdArgs[2]);
                    birthables.Add(pet);
                }
            }

            string yearOfBirth = Console.ReadLine();

            foreach (var birthable in birthables)
            {
                if (birthable.Birthdate.EndsWith(yearOfBirth))
                {
                    Console.WriteLine(birthable.Birthdate);
                }
            }
        }
    }
}
