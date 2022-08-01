using System;

class Program
{
    static void Main()
    {
        string activationKey = Console.ReadLine();

        string cmd;

        while ((cmd = Console.ReadLine()) != "Generate")
        {
            string[] cmdArgs = cmd.Split(">>>", StringSplitOptions.RemoveEmptyEntries);
            string mainCmd = cmdArgs[0];

            switch (mainCmd)
            {
                case "Contains":
                    string substring = cmdArgs[1];
                    if (activationKey.Contains(substring))
                    {
                        Console.WriteLine($"{activationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                    break;

                case "Flip":
                    string secondCmd = cmdArgs[1];
                    int startIndex = int.Parse(cmdArgs[2]);
                    int endIndex = int.Parse(cmdArgs[3]);
                    substring = activationKey.Substring(startIndex, endIndex - startIndex);
                    if (secondCmd == "Upper")
                    {
                        substring = substring.ToUpper();
                    }
                    else if (secondCmd == "Lower")
                    {
                        substring = substring.ToLower();
                    }
                    activationKey = activationKey.Remove(startIndex, endIndex - startIndex);
                    activationKey = activationKey.Insert(startIndex, substring);
                    Console.WriteLine(activationKey);
                    break;

                case "Slice":
                    startIndex = int.Parse(cmdArgs[1]);
                    endIndex = int.Parse(cmdArgs[2]);
                    activationKey = activationKey.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(activationKey);
                    break;
            }
        }
        Console.WriteLine($"Your activation key is: {activationKey}");
    }
}
