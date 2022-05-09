using System;

namespace _02._Letters_Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            char startLetter = char.Parse(Console.ReadLine());
            char finishLetter = char.Parse(Console.ReadLine());
            char missLetter = char.Parse(Console.ReadLine());
            int combinationsCounter = 0;

            for (char firstLeter = startLetter; firstLeter <= finishLetter; firstLeter++)
            {
                if (firstLeter != missLetter)
                {
                    for (char secondLetter = startLetter; secondLetter <= finishLetter; secondLetter++)
                    {
                        if (secondLetter != missLetter)
                        {
                            for (char thirdLetter = startLetter; thirdLetter <= finishLetter; thirdLetter++)
                            {
                                if (thirdLetter != missLetter)
                                {
                                    Console.Write($"{firstLeter.ToString()}{secondLetter.ToString()}{thirdLetter.ToString()} ");
                                    combinationsCounter++;
                                }
                            }
                        }
                    }
                }
            }

            Console.Write(combinationsCounter);
        }
    }
}
