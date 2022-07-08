using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<char> chars = Console.ReadLine().ToList();

            int remainStrength = 0;

            for (int currChar = 0; currChar < chars.Count; currChar++)
            {
                if (chars[currChar] == '>')
                {
                    int explosionStrength = int.Parse(chars[currChar + 1].ToString()) + remainStrength;
                    
                    if (explosionStrength != 0)
                    {
                        remainStrength = explosionStrength;

                        int indexForRemove = currChar + 1;

                        for (int explosion = 1; explosion <= explosionStrength; explosion++)
                        {
                            if (indexForRemove < chars.Count && chars[indexForRemove] != '>')
                            {
                                chars.RemoveAt(indexForRemove);
                                remainStrength--;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(string.Join("", chars));
        }
    }
}
