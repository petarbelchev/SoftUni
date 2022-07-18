using System;

namespace _01._World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string travelStops = Console.ReadLine();

            string cmd = Console.ReadLine();

            while (cmd != "Travel")
            {
                string[] cmdArgs = cmd.Split(":", StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs[0] == "Add Stop")
                {
                    int index = int.Parse(cmdArgs[1]);
                    string newStop = cmdArgs[2];

                    if (index >= 0 && index <= travelStops.Length)
                    {
                        travelStops = travelStops.Insert(index, newStop);
                    }

                    Console.WriteLine(travelStops);
                }
                else if (cmdArgs[0] == "Remove Stop")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]) + 1;

                    if (startIndex >= 0 && startIndex <= travelStops.Length 
                        && endIndex >= 0 && endIndex <= travelStops.Length)
                    {
                        travelStops = travelStops.Remove(startIndex, endIndex - startIndex);
                    }

                    Console.WriteLine(travelStops);
                }
                else if (cmdArgs[0] == "Switch")
                {
                    string oldStop = cmdArgs[1];
                    string newStop = cmdArgs[2];

                    if (travelStops.Contains(oldStop))
                    {
                        travelStops = travelStops.Replace(oldStop, newStop);
                    }

                    Console.WriteLine(travelStops);
                }

                cmd = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {travelStops}");
        }
    }
}
