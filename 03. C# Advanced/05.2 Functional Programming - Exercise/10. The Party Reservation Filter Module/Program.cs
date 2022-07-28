using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._The_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> filteredNames = new List<string>();
            string cmd;

            while ((cmd = Console.ReadLine()) != "Print")
            {
                string mainCmd = cmd.Split(';')[0];
                string filter = cmd.Split(';')[1];
                string parameter = cmd.Split(';')[2];

                Predicate<string> predicate = null;

                if (filter == "Starts with")
                    predicate = name => name.StartsWith(parameter);
                else if (filter == "Ends with")
                    predicate = name => name.EndsWith(parameter);
                else if (filter == "Length")
                    predicate = name => name.Length == int.Parse(parameter);
                else if (filter == "Contains")
                    predicate = name => name.Contains(parameter);

                if (mainCmd == "Add filter")
                    filteredNames.AddRange(names.Where(name => predicate(name)));
                else if (mainCmd == "Remove filter")
                    filteredNames.RemoveAll(name => predicate(name));
            }

            if (names.Count > filteredNames.Count)
                Console.WriteLine(string.Join(' ', names.Where(name => !filteredNames.Contains(name)).ToList()));
        }
    }
}
