using System;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string places = Console.ReadLine();

        var regex = new Regex(@"((=)|(\/))(?<place>[A-Z][A-Za-z]{2,})(\1)");

        MatchCollection matches = regex.Matches(places);

        string[] destinations = matches.Select(x => x.Groups["place"].Value).ToArray();
        int travelPoints = destinations.Select(x => x.Length).Sum();

        Console.WriteLine("Destinations: " + string.Join(", ", destinations));
        Console.WriteLine($"Travel Points: {travelPoints}");
    }
}