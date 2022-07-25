using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            string[] words;

            using (var reader = new StreamReader(wordsFilePath))
                words = reader.ReadToEnd().ToLower().Split();

            string text;

            using (var reader = new StreamReader(textFilePath))
                text = reader.ReadToEnd().ToLower();

            var wordsAndMatchesCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                var regex = new Regex(@$"\b{word}\b");
                MatchCollection matches = regex.Matches(text);
                wordsAndMatchesCount[word] = matches.Count();
            }

            using (var writer = new StreamWriter(outputFilePath))
            {
                foreach (var word in wordsAndMatchesCount.OrderByDescending(x => x.Value))
                    writer.WriteLine(word.Key + " - " + word.Value);
            }
        }
    }
}

