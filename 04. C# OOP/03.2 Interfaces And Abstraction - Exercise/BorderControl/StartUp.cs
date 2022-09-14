using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main()
        {
            List<IHaveId> citizensAndRobots = new List<IHaveId>();

            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "End") break;

                string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs.Length == 3)
                {
                    var citizen = new Citizen(cmdArgs[0], int.Parse(cmdArgs[1]), cmdArgs[2]);
                    citizensAndRobots.Add(citizen);
                }
                else
                {
                    var robot = new Robot(cmdArgs[0], cmdArgs[1]);
                    citizensAndRobots.Add(robot);
                }
            }

            string lastDigits = Console.ReadLine();

            foreach (var citOrRob in citizensAndRobots)
            {
                if (citOrRob.Id.EndsWith(lastDigits))
                {
                    Console.WriteLine(citOrRob.Id);
                }
            }
        }
    }
}
