using System;

namespace _03._Stream_Of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            string secretMessege = null;
            string forPrint = null;
            char symbol;
            bool cCheck = false;
            bool oCheck = false;
            bool nCheck = false;

            while (true)
            {
                string input = Console.ReadLine();

                if (cCheck && oCheck && nCheck)
                {
                    secretMessege += " ";
                    forPrint += secretMessege;
                    secretMessege = null;
                    cCheck = false;
                    oCheck = false;
                    nCheck = false;
                }

                if (input == "End")
                {
                    Console.WriteLine(forPrint);
                    break;
                }
                else
                {
                    symbol = char.Parse(input);
                }

                if (symbol >= 'a' && symbol <= 'z' || symbol >= 'A' && symbol <= 'Z')
                {
                    if (symbol == 'c' && cCheck == false)
                    {
                        cCheck = true;
                        continue;
                    }
                    else if (symbol == 'o' && oCheck == false)
                    {
                        oCheck = true;
                        continue;
                    }
                    else if (symbol == 'n' && nCheck == false)
                    {
                        nCheck = true;
                        continue;
                    }

                    secretMessege += symbol;
                }
            }
        }
    }
}
