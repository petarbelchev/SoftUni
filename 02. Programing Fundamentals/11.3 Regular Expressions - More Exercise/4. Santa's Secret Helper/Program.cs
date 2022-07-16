using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _4._Santa_s_Secret_Helper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());

            string encryptedMessage = Console.ReadLine();

            List<string> names = new List<string>();

            while (encryptedMessage != "end")
            {
                StringBuilder decryptedMessage = new StringBuilder();

                decryptedMessage.Append(new string (encryptedMessage.Select(ch => ch = (char)(ch - key)).ToArray()));

                Regex regex = new Regex(@"@(?<name>[A-Za-z]+)[^@\-!:>]*!(?<behavior>[GN]?)!");

                Match match = regex.Match(decryptedMessage.ToString());

                if (match.Success && match.Groups["behavior"].Value == "G")
                {
                    names.Add(match.Groups["name"].Value);
                }

                encryptedMessage = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
