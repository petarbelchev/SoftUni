using System;
using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\input.txt";
            string outputPath = @"..\..\..\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            var reader = new StreamReader(inputFilePath);
            var writer = new StreamWriter(outputFilePath);

            using (reader)
            {
                string line = reader.ReadLine();

                using (writer)
                {
                    int row = 1;

                    while (line != null)
                    {
                        writer.WriteLine($"{row++}. {line}");

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}

