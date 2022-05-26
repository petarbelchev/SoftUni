using System;

namespace _05._Decrypting_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int charsCount = int.Parse(Console.ReadLine());
            string decryptedMessage = string.Empty;

            for (int numOfChar = 1; numOfChar <= charsCount; numOfChar++)
            {
                char currChar = (char)(char.Parse(Console.ReadLine()) + key);
                decryptedMessage += currChar;
            }

            Console.WriteLine(decryptedMessage);
        }
    }
}
