using System;

namespace _03._Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] filePath = Console.ReadLine()
                .Split('\\', StringSplitOptions.RemoveEmptyEntries);

            string fileName = filePath[filePath.Length - 1].Split('.')[0];
            string fileExtension = filePath[filePath.Length - 1].Split('.')[1];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}
