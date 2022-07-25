using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            List<byte> sourseBytes = new List<byte>();

            using (FileStream fileReader = new FileStream(sourceFilePath, FileMode.Open))
            {
                byte[] buffer = new byte[1024];
                int bytesRead = fileReader.Read(buffer, 0, buffer.Length);

                while (bytesRead != 0)
                {
                    sourseBytes.AddRange(buffer);

                    bytesRead = fileReader.Read(buffer, 0, buffer.Length);
                }
            }

            using (FileStream writer = new FileStream(partOneFilePath, FileMode.Create))
            {
                if (sourseBytes.Count % 2 == 0)
                {
                    writer.Write(sourseBytes.ToArray(), 0, sourseBytes.Count / 2);
                }
                else
                {
                    writer.Write(sourseBytes.ToArray(), 0, sourseBytes.Count / 2 + 1);
                }
            }

            using (FileStream writer = new FileStream(partTwoFilePath, FileMode.Create))
            {
                if (sourseBytes.Count % 2 == 0)
                {
                    writer.Write(sourseBytes.ToArray(), sourseBytes.Count / 2, sourseBytes.Count - sourseBytes.Count / 2);
                }
                else
                {
                    writer.Write(sourseBytes.ToArray(), sourseBytes.Count / 2 + 1, sourseBytes.Count - sourseBytes.Count / 2 + 1);
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream writer = new FileStream(joinedFilePath, FileMode.Create))
            {
                using (FileStream reader = new FileStream(partOneFilePath, FileMode.Open))
                {
                    byte[] buffer = new byte[1024];
                    int readedBytes = reader.Read(buffer, 0, buffer.Length);

                    while (readedBytes != 0)
                    {
                        writer.Write(buffer, 0, readedBytes);

                        readedBytes = reader.Read(buffer, 0, buffer.Length);
                    }
                }

                using (FileStream reader = new FileStream(partTwoFilePath, FileMode.Open))
                {
                    byte[] buffer = new byte[1024];
                    int readedBytes = reader.Read(buffer, 0, buffer.Length);

                    while (readedBytes != 0)
                    {
                        writer.Write(buffer, 0, readedBytes);

                        readedBytes = reader.Read(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
