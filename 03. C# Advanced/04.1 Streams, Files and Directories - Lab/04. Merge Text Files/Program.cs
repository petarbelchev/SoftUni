using System;
using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (var firstReader = new StreamReader(firstInputFilePath))
            {
                using (var secondReader = new StreamReader(secondInputFilePath))
                {
                    using (var writer = new StreamWriter(outputFilePath))
                    {
                        string firstLine = firstReader.ReadLine();
                        string secondLine = secondReader.ReadLine();

                        while (firstLine != null || secondLine != null)
                        {
                            if (firstLine != null)
                            {
                                writer.WriteLine(firstLine);
                            }
                            if (secondLine != null)
                            {
                                writer.WriteLine(secondLine);
                            }

                            firstLine = firstReader.ReadLine();
                            secondLine = secondReader.ReadLine();
                        }
                    }
                }
            }
        }
    }
}

