using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Snowwhite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dwarfs = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "Once upon a time")
            {
                string[] inputArgs = input.Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);

                string dwarfId = inputArgs[0] + ':' + inputArgs[1];
                int dwarfPhysics = int.Parse(inputArgs[2]);

                if (!dwarfs.ContainsKey(dwarfId))
                {
                    dwarfs.Add(dwarfId, dwarfPhysics);
                }
                else
                {
                    if (dwarfs[dwarfId] < dwarfPhysics)
                    {
                        dwarfs[dwarfId] = dwarfPhysics;
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var dwarf in dwarfs
                .OrderByDescending(d => d.Value)
                .ThenByDescending(x => dwarfs.Where(y => y.Key.Split(':')[1] == x.Key.Split(':')[1]).Count()))
            {
                Console.WriteLine
                    ($"({dwarf.Key.Split(':')[1]}) {dwarf.Key.Split(':')[0]} <-> {dwarf.Value}");
            }
        }
    }
}
