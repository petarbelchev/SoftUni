using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirdTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> books = Console.ReadLine()
                .Split("&", StringSplitOptions.RemoveEmptyEntries).ToList();

            string cmd = Console.ReadLine();

            while (cmd != "Done")
            {
                string[] cmdArgs = cmd.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                string mainCmd = cmdArgs[0];
                string nameFirstBook = cmdArgs[1];

                switch (mainCmd)
                {
                    case "Add Book":
                        if (!books.Contains(nameFirstBook))
                        {
                            books.Insert(0, nameFirstBook);
                        }
                        break;

                    case "Take Book":
                        if (books.Contains(nameFirstBook))
                        {
                            books.Remove(nameFirstBook);
                        }
                        break;

                    case "Swap Books":
                        string nameSecondBook = cmdArgs[2];
                        if (books.Contains(nameFirstBook) && books.Contains(nameSecondBook))
                        {
                            int indexFirstBook = books.IndexOf(nameFirstBook);
                            int indexSecondBook = books.IndexOf(nameSecondBook);
                            books.Remove(nameSecondBook);
                            books.Insert(indexSecondBook, nameFirstBook);
                            books.Remove(nameFirstBook);
                            books.Insert(indexFirstBook, nameSecondBook);
                        }
                        break;

                    case "Insert Book":
                        if (!books.Contains(nameFirstBook))
                        {
                            books.Add(nameFirstBook);
                        }
                        break;

                    case "Check Book":
                        int index = int.Parse(cmdArgs[1]);
                        if (index >= 0 && index < books.Count)
                        {
                            Console.WriteLine(books[index]);
                        }
                        break;
                }

                cmd = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", books));
        }
    }
}
