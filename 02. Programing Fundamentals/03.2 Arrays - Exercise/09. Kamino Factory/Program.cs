using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sequenceLength = int.Parse(Console.ReadLine());

            string[] bestDna = new string[sequenceLength];
            int lengthBestDna = 0;
            int startOfSequenceBestDna = 0;
            int onesCountBestDna = 0;
            int dnasCounter = 0;
            int bestDnaNumber = 0;

            string input = Console.ReadLine();

            while (input != "Clone them!")
            {
                string[] currentDna = input.Split("!", StringSplitOptions.RemoveEmptyEntries).ToArray();
                dnasCounter++;
                int lengthCurrentDna = 0;
                int counter = 1;
                int startOfSequence = 0;

                for (int i = 1; i < sequenceLength; i++)
                {
                    if (currentDna[i] == currentDna[i - 1] && currentDna[i] == "1")
                    {
                        counter++;
                        if (counter == 2 && counter > lengthCurrentDna)
                        {
                            startOfSequence = i - 1;
                        }
                        if (counter > lengthCurrentDna)
                        {
                            lengthCurrentDna = counter;
                        }
                    }
                    else
                    {
                        if (counter > lengthCurrentDna)
                        {
                            lengthCurrentDna = counter;
                        }
                        counter = 1;
                    }
                }

                int onesCounter = 0;
                foreach (string item in currentDna)
                {
                    if (item == "1")
                    {
                        onesCounter++;
                    }
                }

                if ((lengthCurrentDna > lengthBestDna) 
                    || (lengthCurrentDna == lengthBestDna && startOfSequence < startOfSequenceBestDna) 
                    || (lengthCurrentDna == lengthBestDna && startOfSequence == startOfSequenceBestDna && onesCounter > onesCountBestDna))
                {
                    bestDna = currentDna;
                    bestDnaNumber = dnasCounter;
                    lengthBestDna = lengthCurrentDna;
                    onesCountBestDna = onesCounter;
                    startOfSequenceBestDna = startOfSequence;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestDnaNumber} with sum: {onesCountBestDna}.");

            foreach (string item in bestDna)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
