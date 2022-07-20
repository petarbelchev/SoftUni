using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfOperations = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < numOfOperations; i++)
            {
                string[] cmd = Console.ReadLine().Split(' ');
                string mainCmd = cmd[0];
                if (mainCmd == "1")
                {
                    string textToAppend = cmd[1];
                    stack.Push(text.ToString());
                    text.Append(textToAppend);
                }
                else if (mainCmd == "2")
                {
                    int countForRemove = int.Parse(cmd[1]);
                    int startIndex = text.Length - countForRemove;
                    stack.Push(text.ToString());
                    text.Remove(startIndex, countForRemove);
                }
                else if (mainCmd == "3")
                {
                    int positionToShow = int.Parse(cmd[1]) - 1;
                    Console.WriteLine(text[positionToShow]);
                }
                else if (mainCmd == "4")
                {
                    text.Clear();
                    text.Append(stack.Pop());
                }
            }
        }
    }
}
