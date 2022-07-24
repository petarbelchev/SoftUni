using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HashSet<string> usernames = new HashSet<string>();
        int countOfUsernames = int.Parse(Console.ReadLine());
        for (int i = 0; i < countOfUsernames; i++)
        {
            string name = Console.ReadLine();
            usernames.Add(name);
        }
        Console.WriteLine(string.Join(Environment.NewLine, usernames));
    }
}
