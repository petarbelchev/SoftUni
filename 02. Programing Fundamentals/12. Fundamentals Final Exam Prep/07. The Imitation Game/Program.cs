using System;

class Program
{
    static void Main()
    {
        string message = Console.ReadLine();
        string cmd = Console.ReadLine();
        while (cmd != "Decode")
        {
            string[] cmdArgs = cmd.Split('|', StringSplitOptions.RemoveEmptyEntries);
            switch (cmdArgs[0])
            {
                case "Move":
                    int numOfLetters = int.Parse(cmdArgs[1]);
                    string substr = message.Substring(0, numOfLetters);
                    message = message.Remove(0, numOfLetters);
                    message = message.Insert(message.Length, substr);
                    break;

                case "Insert":
                    int index = int.Parse(cmdArgs[1]);
                    string value = cmdArgs[2];
                    message = message.Insert(index, value);
                    break;

                case "ChangeAll":
                    string substring = cmdArgs[1];
                    string replacement = cmdArgs[2];
                    message = message.Replace(substring, replacement);
                    break;
            }
            cmd = Console.ReadLine();
        }
        Console.WriteLine($"The decrypted message is: {message}");
    }
}