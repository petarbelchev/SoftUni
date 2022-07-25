using System.IO;

namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\input.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            var read = new StreamReader(inputFilePath);
            var write = new StreamWriter(outputFilePath);
            int row = 0;

            using (read)
            {
                string line = read.ReadLine();

                using (write)
                {
                    while (line != null)
                    {
                        if (row % 2 != 0)
                        {
                            write.WriteLine(line);
                        }
                        row++;

                        line = read.ReadLine();
                    }
                }
            }
        }
    }
}

