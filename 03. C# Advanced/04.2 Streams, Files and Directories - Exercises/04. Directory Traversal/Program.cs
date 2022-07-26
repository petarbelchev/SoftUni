using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{
    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            DirectoryInfo dir = new DirectoryInfo(inputFolderPath);
            FileInfo[] files = dir.GetFiles();

            var sortedFiles = new Dictionary<string, Dictionary<string, long>>();

            foreach (var file in files)
            {
                if (!sortedFiles.ContainsKey(file.Extension))
                {
                    sortedFiles[file.Extension] = new Dictionary<string, long>();
                }

                sortedFiles[file.Extension][file.Name] = file.Length;
            }

            StringBuilder sb = new StringBuilder();

            foreach (var extension in sortedFiles
                .OrderByDescending(x => x.Value.Count))
            {
                sb.AppendLine(extension.Key);
                foreach (var file in extension.Value.OrderBy(x => x.Value))
                {
                    sb.AppendLine($"--{file.Key} - {file.Value / (double)1000:f3}kb");
                }
            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = @"..\..\..\..\..\..\.." + reportFileName;

            using (File.Create(filePath))
            {

            }

            using (var writer = new StreamWriter(filePath))
            {
                writer.Write(textContent);
            }
        }
    }
}

