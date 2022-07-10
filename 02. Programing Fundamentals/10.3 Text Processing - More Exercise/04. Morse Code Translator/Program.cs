using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04._Morse_Code_Translator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, char> morsecode = new Dictionary<string, char>()
            {
                {".-", 'A'},
                {"-...", 'B'},
                {"-.-.", 'C'},
                {"-..", 'D'},
                {".", 'E'},
                {"..-.", 'F'},
                {"--.", 'G'},
                {"....", 'H'},
                {"..", 'I'},
                {".---", 'J'},
                {"-.-", 'K'},
                {".-..", 'L'},
                {"--", 'M'},
                {"-.", 'N'},
                {"---", 'O'},
                {".--.", 'P'},
                {"--.-", 'Q'},
                {".-.", 'R'},
                {"...", 'S'},
                {"-", 'T'},
                {"..-", 'U'},
                {"...-", 'V'},
                {".--", 'W'},
                {"-..-", 'X'},
                {"-.--", 'Y'},
                {"--..", 'Z'}
            };

            string cryptedMessage = Console.ReadLine();

            StringBuilder currCryptedChar = new StringBuilder();
            StringBuilder decryptedMessage = new StringBuilder();

            foreach (char symbol in cryptedMessage)
            {
                if (symbol == '.' || symbol == '-')
                {
                    currCryptedChar.Append(symbol);
                }
                else if (symbol == ' ' && currCryptedChar.Length > 0)
                {
                    decryptedMessage.Append(morsecode[currCryptedChar.ToString()]);
                    currCryptedChar.Clear();
                }
                else if (symbol == '|')
                {
                    decryptedMessage.Append(' ');
                }
            }

            if (currCryptedChar.Length > 0)
            {
                decryptedMessage.Append(morsecode[currCryptedChar.ToString()]);
            }

            Console.WriteLine(decryptedMessage.ToString().TrimEnd());
        }
    }
}
