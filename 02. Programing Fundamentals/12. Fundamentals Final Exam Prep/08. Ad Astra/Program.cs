using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string text = Console.ReadLine();
        Regex regex = new Regex(@"((\|)|(#))(?<itemName>[A-Z][A-Za-z\s]+)(\1)(?<date>\d{2}\/\d{2}\/\d{2})(\1)(?<calories>\d+)(\1)");
        MatchCollection matches = regex.Matches(text);
        int sumOfCalories = 0;
        foreach (Match match in matches)
        {
            sumOfCalories += int.Parse(match.Groups["calories"].Value);
        }
        int neededCaloriesPerDay = 2000;
        Console.WriteLine($"You have food to last you for: {sumOfCalories/neededCaloriesPerDay} days!");
        foreach (Match match in matches)
        {
            Console.WriteLine($"Item: {match.Groups["itemName"]}, Best before: {match.Groups["date"]}, Nutrition: {match.Groups["calories"]}");
        }
    }
}