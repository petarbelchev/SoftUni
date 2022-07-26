using System;
using System.IO;
using System.Linq;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int row = 1;
                string line = reader.ReadLine();

                using (var writer = new StreamWriter(outputFilePath))
                {
                    while (line != null)
                    {
                        char[] punctuations = new char[] { '.', ',', '!', '?', '-', '\'' };
                        int countOfPunc = line.Where(ch => char.IsPunctuation(ch)).ToArray().Count();
                        int countOfLetters = line.Where(ch => char.IsLetter(ch)).ToArray().Count();

                        writer.WriteLine($"Line {row++}: {line} ({countOfLetters})({countOfPunc})");

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
