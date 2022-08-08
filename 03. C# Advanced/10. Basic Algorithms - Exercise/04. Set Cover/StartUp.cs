namespace SetCover
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<int> universe = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int numOfSets = int.Parse(Console.ReadLine());

            List<int[]> sets = new List<int[]>();

            for (int i = 0; i < numOfSets; i++)
            {
                int[] currSet = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                sets.Add(currSet);
            }

            List<int[]> takedSets = ChooseSetsTwo(sets, universe);

            Console.WriteLine($"Sets to take ({takedSets.Count}):");
            foreach (var set in takedSets)
            {
                Console.WriteLine("{ " + string.Join(", ", set) + " }");
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        public static List<int[]> ChooseSetsTwo(IList<int[]> sets, IList<int> universe)
        {
            List<int[]> takedSets = new List<int[]>();

            while (universe.Count > 0)
            {
                var setToTake = sets.OrderByDescending(currSet => currSet.Count(currNum => universe.Contains(currNum))).First();

                takedSets.Add(setToTake);

                for (int i = 0; i < universe.Count; i++)
                {
                    if (setToTake.Any(n => n == universe[i]))
                    {
                        universe.RemoveAt(i);
                        i--;
                    }
                }
            }

            return takedSets;
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            List<int[]> takedSets = new List<int[]>();

            while (universe.Count > 0)
            {
                int counter = 0;
                int[] setToTake = null;

                foreach (var set in sets)
                {
                    int currCounter = 0;

                    foreach (var unNum in universe)
                    {
                        if (set.Any(n => n == unNum))
                        {
                            currCounter++;
                        }
                    }

                    if (currCounter > counter)
                    {
                        setToTake = set;
                        counter = currCounter;
                    }
                }

                takedSets.Add(setToTake);

                for (int i = 0; i < universe.Count; i++)
                {
                    if (setToTake.Any(n => n == universe[i]))
                    {
                        universe.RemoveAt(i);
                        i--;
                    }
                }
            }

            return takedSets;
        }
    }
}
