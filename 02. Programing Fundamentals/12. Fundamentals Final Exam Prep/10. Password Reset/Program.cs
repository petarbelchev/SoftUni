using System;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        string password = Console.ReadLine();
        string cmd = Console.ReadLine();
        
        while (cmd != "Done")
        {
            string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            switch (cmdArgs[0])
            {
                case "TakeOdd":
                    var sb = new StringBuilder();
                    for (int i = 1; i < password.Length; i += 2)
                    {
                        sb.Append(password[i]);
                    }
                    password = sb.ToString().TrimEnd();
                    Console.WriteLine(password);
                    break;

                case "Cut":
                    int index = int.Parse(cmdArgs[1]);
                    int length = int.Parse(cmdArgs[2]);
                    string substring = password.Substring(index, length);
                    int startIndex = password.IndexOf(substring);
                    password = password.Remove(startIndex, substring.Length);
                    Console.WriteLine(password);
                    break;

                case "Substitute":
                    substring = cmdArgs[1];
                    string substitute = cmdArgs[2];
                    if (password.Contains(substring))
                    {
                        password = password.Replace(substring, substitute);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine($"Nothing to replace!");
                    }
                    break;
            }
            cmd = Console.ReadLine();
        }
        Console.WriteLine($"Your password is: {password}");
    }
}