using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExtractBytes
{
    public class ExtractBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            List<byte> lookedBytes = new List<byte>();
            using (StreamReader bytesReader = new StreamReader(bytesFilePath))
            {
                string line = bytesReader.ReadLine();

                while (line != null)
                {
                    lookedBytes.Add(byte.Parse(line));

                    line = bytesReader.ReadLine();
                }
            }

            using (FileStream imageReader = new FileStream(binaryFilePath, FileMode.Open))
            {
                using (FileStream writer = new FileStream(outputPath, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    int countBuffer = imageReader.Read(buffer, 0, buffer.Length);

                    while (countBuffer != 0)
                    {
                        byte[] mathesBytes = buffer.Where(b => lookedBytes.Contains(b)).ToArray();

                        writer.Write(mathesBytes, 0, mathesBytes.Length);

                        countBuffer = imageReader.Read(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}


