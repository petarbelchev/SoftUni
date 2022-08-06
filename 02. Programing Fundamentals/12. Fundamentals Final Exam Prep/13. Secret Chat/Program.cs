using System;
class Program
{
    static void Main()
    {
        string concealsMessage = Console.ReadLine();

        string cmd;

        while ((cmd = Console.ReadLine()) != "Reveal")
        {
            string[] cmdArgs = cmd.Split(":|:", StringSplitOptions.RemoveEmptyEntries);

            if (cmdArgs[0] == "InsertSpace")
            {
                int index = int.Parse(cmdArgs[1]);
                concealsMessage = concealsMessage.Insert(index, " ");
                Console.WriteLine(concealsMessage);
            }
            else if (cmdArgs[0] == "Reverse")
            {
                string substring = cmdArgs[1];
                if (concealsMessage.Contains(substring))
                {
                    int startIndex = concealsMessage.IndexOf(substring);
                    concealsMessage = concealsMessage.Remove(startIndex, substring.Length);
                    char[] substrToChars = substring.ToCharArray();
                    Array.Reverse(substrToChars);
                    substring = new string(substrToChars);
                    concealsMessage = concealsMessage.Insert(concealsMessage.Length, substring);
                    Console.WriteLine(concealsMessage);
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (cmdArgs[0] == "ChangeAll")
            {
                string substring = cmdArgs[1];
                string replacement = cmdArgs[2];
                concealsMessage = concealsMessage.Replace(substring, replacement);
                Console.WriteLine(concealsMessage);
            }
        }
        Console.WriteLine($"You have a new text message: {concealsMessage}");
    }
}
