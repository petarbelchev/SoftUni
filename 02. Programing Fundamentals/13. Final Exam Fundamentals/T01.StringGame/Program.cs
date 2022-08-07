using System;

class Program
{
    static void Main()
    {
        string text = Console.ReadLine();

        string cmd;

        while ((cmd = Console.ReadLine()) != "Done")
        {
            string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (cmdArgs[0] == "Change")
            {
                char ch = char.Parse(cmdArgs[1]);
                char replacement = char.Parse(cmdArgs[2]);
                text = text.Replace(ch, replacement);
                Console.WriteLine(text);
            }
            else if (cmdArgs[0] == "Includes")
            {
                string substring = cmdArgs[1];
                Console.WriteLine(text.Contains(substring));
            }
            else if (cmdArgs[0] == "End")
            {
                string substring = cmdArgs[1];
                Console.WriteLine(text.EndsWith(substring));
            }
            else if (cmdArgs[0] == "Uppercase")
            {
                text = text.ToUpper();
                Console.WriteLine(text);
            }
            else if (cmdArgs[0] == "FindIndex")
            {
                char ch = char.Parse(cmdArgs[1]);
                int index = text.IndexOf(ch);
                Console.WriteLine(index);
            }
            else if (cmdArgs[0] == "Cut")
            {
                int startIndex = int.Parse(cmdArgs[1]);
                int count = int.Parse(cmdArgs[2]);
                text = text.Substring(startIndex, count);
                Console.WriteLine(text);
            }
        }
    }
}