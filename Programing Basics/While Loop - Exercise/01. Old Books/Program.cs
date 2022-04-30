using System;

namespace _01._Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookForSearch = Console.ReadLine();
            string nextBook = null;
            int checkedBooksQuantity = 0;

            while (bookForSearch != nextBook)
            {
                nextBook = Console.ReadLine();

                if (nextBook == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {checkedBooksQuantity} books.");
                    break;
                }

                if (nextBook == bookForSearch)
                {
                    Console.WriteLine($"You checked {checkedBooksQuantity} books and found it.");
                    break;
                }

                checkedBooksQuantity++;
            }
        }
    }
}
