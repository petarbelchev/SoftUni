using System;
using System.Linq;

namespace _03._Treasure_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] keys = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            string input = Console.ReadLine();

            while (input != "find")
            {
                char[] cryptedMessage = input.ToCharArray();

                int keyIndex = 0;

                for (int i = 0; i < cryptedMessage.Length; i++)
                {
                    cryptedMessage[i] -= (char)keys[keyIndex];
                    keyIndex++;

                    if (keyIndex >= keys.Length)
                    {
                        keyIndex = 0;
                    }
                }

                string decyptedMessage = new string(cryptedMessage);

                int startIndexType = decyptedMessage.IndexOf('&') + 1;
                int endIndexType = decyptedMessage.LastIndexOf('&');
                string type = decyptedMessage.Substring(startIndexType, endIndexType - startIndexType);

                int startIndexCoordinates = decyptedMessage.IndexOf('<') + 1;
                int endIndexCoordinates = decyptedMessage.IndexOf('>');
                string coordinates = decyptedMessage.Substring(startIndexCoordinates, endIndexCoordinates - startIndexCoordinates);

                Console.WriteLine($"Found {type} at {coordinates}");

                input = Console.ReadLine();
            }
        }
    }
}
