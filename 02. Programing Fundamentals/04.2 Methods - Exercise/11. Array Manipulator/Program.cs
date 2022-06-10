using System;
using System.Linq;
using System.Text;

namespace _11._Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] initialArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commands = command.Split().ToArray();

                if (commands[0] == "exchange")
                {
                    if (int.Parse(commands[1]) >= 0 && int.Parse(commands[1]) < initialArray.Length)
                    {
                        initialArray = GetExchange(initialArray, int.Parse(commands[1]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (commands[0] == "max" || commands[0] == "min")
                {
                    Console.WriteLine(GetMaxMinEvenOdds(initialArray, commands[0], commands[1]));
                }
                else if (commands[0] == "first" || commands[0] == "last")
                {
                    if (int.Parse(commands[1]) <= initialArray.Length)
                    {
                        GetFirstLastEl(initialArray, commands[0], int.Parse(commands[1]), commands[2]);
                    }
                    else
                    {
                        Console.WriteLine("Invalid count");
                    }
                }
            }

            Console.Write("[");
            Console.Write(string.Join(", ", initialArray));
            Console.Write("]");
        }

        static void GetFirstLastEl(int[] array, string firstOrLast, int count, string oddOrEven)
        {
            string result = string.Empty;
            bool isNeedReverse = false;

            if (firstOrLast == "first")
            {
                if (oddOrEven == "odd")
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] % 2 != 0 && count > 0)
                        {
                            result += array[i] + " ";
                            count--;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] % 2 == 0 && count > 0)
                        {
                            result += array[i] + " ";
                            count--;
                        }
                    }
                }
            }
            else if (firstOrLast == "last")
            {
                isNeedReverse = true;

                if (oddOrEven == "even")
                {
                    for (int i = array.Length - 1; i >= 0; i--)
                    {
                        if (array[i] % 2 == 0 && count > 0)
                        {
                            result += array[i] + " ";
                            count--;
                        }
                    }
                }
                else
                {
                    for (int i = array.Length - 1; i >= 0; i--)
                    {
                        if (array[i] % 2 != 0 && count > 0)
                        {
                            result += array[i] + " ";
                            count--;
                        }
                    }
                }
            }

            Console.Write("[");
            string[] arrResult = result
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            if (isNeedReverse)
            {
                Array.Reverse(arrResult);
            }

            Console.Write(String.Join(", ", arrResult));
            Console.WriteLine("]");
        }

        static string GetMaxMinEvenOdds(int[] array, string command, string evenOrOdd)
        {
            bool isMatches = false;
            int index = 0;
            int valueElement = 0;

            if (command == "max")
            {
                if (evenOrOdd == "odd")
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] >= valueElement && array[i] % 2 != 0)
                        {
                            valueElement = array[i];
                            index = i;
                            isMatches = true;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] >= valueElement && array[i] % 2 == 0)
                        {
                            valueElement = array[i];
                            index = i;
                            isMatches = true;
                        }
                    }
                }
            }
            else if (command == "min")
            {
                valueElement = 1000;

                if (evenOrOdd == "odd")
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] <= valueElement && array[i] % 2 != 0)
                        {
                            valueElement = array[i];
                            index = i;
                            isMatches = true;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] <= valueElement && array[i] % 2 == 0)
                        {
                            valueElement = array[i];
                            index = i;
                            isMatches = true;
                        }
                    }
                }
            }

            if (isMatches)
            {
                return index.ToString();
            }

            return "No matches";
        }

        static int[] GetExchange(int[] array, int index)
        {
            int[] firstPart = new int[index + 1];

            for (int i = 0; i <= index; i++)
            {
                firstPart[i] = array[i];
            }

            for (int i = 0; i < array.Length - 1 - index; i++)
            {
                array[i] = array[index + 1 + i];
            }

            for (int i = 0; i < firstPart.Length; i++)
            {
                array[array.Length - 1 - index + i] = firstPart[i];
            }

            return array;
        }
    }
}
