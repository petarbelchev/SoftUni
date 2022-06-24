using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08._2_Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string cmd = Console.ReadLine();

            while (cmd != "3:1")
            {
                string[] cmdArgs = cmd
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string mainCmd = cmdArgs[0];

                switch (mainCmd)
                {
                    case "merge":
                        int startIndex = int.Parse(cmdArgs[1]);
                        int endIndex = int.Parse(cmdArgs[2]);
                        words = Merge(words, startIndex, endIndex);
                        break;

                    case "divide":
                        int index = int.Parse(cmdArgs[1]);
                        int part = int.Parse(cmdArgs[2]);
                        words = Givide(words, index, part);
                        break;
                }

                cmd = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", words));
        }

        static List<string> Givide(List<string> words, int index, int part)
        {
            int partLength = words[index].Length / part;
            int lastPartAd = words[index].Length - partLength * part;

            char[] newElement;
            List<string> listNewElements = new List<string>();

            for (int i = 0; i < part; i++)
            {
                newElement = words[index].Skip(partLength * i).Take(partLength).ToArray();
                listNewElements.Add(new string (newElement));

                if (i == part - 1)
                {
                    newElement = words[index].Skip(partLength * (i + 1)).Take(lastPartAd).ToArray();
                    listNewElements[listNewElements.Count - 1] += new string(newElement);
                }
            }

            words.RemoveAt(index);
            words.InsertRange(index, listNewElements);

            return words;
        }

        static List<string> Merge(List<string> words, int startIndex, int endIndex)
        {
            if (startIndex < 0)
            {
                startIndex = 0;
            }

            if (endIndex >= words.Count)
            {
                endIndex = words.Count - 1;
            }

            for (int i = startIndex; i < endIndex; i++)
            {
                words[startIndex] += words[startIndex + 1];
                words.RemoveAt(startIndex + 1);
            }

            return words;
        }
    }
}
