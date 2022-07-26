using System;
using System.IO;
using System.Text;

namespace EvenLines
{
    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder sb = new StringBuilder();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line = reader.ReadLine();
                int row = 0;

                while (line != null)
                {
                    if (row % 2 == 0)
                    {
                        char[] chars = new char[] { '-', ',', '.', '!', '?' };

                        foreach (char ch in chars)
                        {
                            line = line.Replace(ch, '@');
                        }

                        string[] reversedLine = line.Split();
                        Array.Reverse(reversedLine);

                        sb.AppendLine(string.Join(' ', reversedLine));

                    }
                    row++;

                    line = reader.ReadLine();
                }
            }

            return sb.ToString();
        }
    }
}

