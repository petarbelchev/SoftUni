namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    //using Z.EntityFramework.Plus;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //2. Age Restriction
            //string command = Console.ReadLine();
            //Console.WriteLine(GetBooksByAgeRestriction(db, command));

            //3. Golden Books
            //Console.WriteLine(GetGoldenBooks(db));

            //4. Books by Price
            //Console.WriteLine(GetBooksByPrice(db));

            //5. Not Released In
            //int year = int.Parse(Console.ReadLine());
            //Console.WriteLine(GetBooksNotReleasedIn(db, year));

            //6. Book Titles by Category
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBooksByCategory(db, input));

            //7. Released Before Date
            //string date = Console.ReadLine();
            //Console.WriteLine(GetBooksReleasedBefore(db, date));

            //8. Author Search
            //string input = Console.ReadLine();
            //Console.WriteLine(GetAuthorNamesEndingIn(db, input));

            //9. Book Search
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBookTitlesContaining(db, input));

            //10. Book Search by Author
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBooksByAuthor(db, input));

            //11. Count Books
            //int lengthCheck = int.Parse(Console.ReadLine());
            //Console.WriteLine(CountBooks(db, lengthCheck)); 

            //12. Total Book Copies
            //Console.WriteLine(CountCopiesByAuthor(db));

            //13. Profit by Category
            //Console.WriteLine(GetTotalProfitByCategory(db));

            //14. Most Recent Books
            //Console.WriteLine(GetMostRecentBooks(db));

            //15. Increase Prices
            //IncreasePrices(db);

            //16. Remove Books
            //Console.WriteLine(RemoveBooks(db));
        }

        //2. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            if (!Enum.TryParse(command, true, out AgeRestriction ageRest))
                return string.Empty;

            var bookTitles = context.Books
                .Where(b => b.AgeRestriction == ageRest)
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        //3. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBookTitles = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, goldenBookTitles);
        }

        //4. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => $"{b.Title} - ${b.Price:F2}")
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        //5. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        //6. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] bookTitles = context.BooksCategories
                .Where(bc => categories.Contains(bc.Category.Name))
                .Select(bc => bc.Book.Title)
                .OrderBy(t => t)
                .ToArray();


            //That works in Judge!

            //int[] categoriesIds = context.Categories
            //    .Where(c => categories.Contains(c.Name.ToLower()))
            //    .Select(c => c.CategoryId)
            //    .ToArray();

            //var bookTitles = context.BooksCategories
            //    .Where(bc => categoriesIds.Contains(bc.CategoryId))
            //    .Select(bc => bc.Book.Title) 
            //    .OrderBy(t => t)
            //    .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        //7. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < dateTime)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}")
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        //8. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorNames = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToArray()
                .OrderBy(fn => fn)
                .ToArray();

            return string.Join(Environment.NewLine, authorNames);
        }

        //9. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string inputToLower = input.ToLower();

            var bookTitles = context.Books
                .Where(b => b.Title.ToLower().Contains(inputToLower))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        //10. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            string inputToLower = input.ToLower();

            var bookInfo = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(inputToLower))
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToArray();

            return string.Join(Environment.NewLine, bookInfo);
        }

        //11. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int booksCount = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return booksCount;
        }

        //12. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    Copies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.Copies)
                .ToArray();

            var output = new StringBuilder();

            foreach (var author in authors)
                output.AppendLine($"{author.FirstName} {author.LastName} - {author.Copies}");

            return output.ToString().TrimEnd();
        }

        //13. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new { c.Name, Profit = c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies) })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .ToArray();

            var output = new StringBuilder();

            foreach (var c in categories)
                output.AppendLine($"{c.Name} ${c.Profit:F2}");

            return output.ToString().TrimEnd();
        }

        //14. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Top3Recent = c.CategoryBooks
                        .OrderByDescending(b => b.Book.ReleaseDate)
                        .Take(3)
                        .Select(b => $"{b.Book.Title} ({b.Book.ReleaseDate.Value.Year})")
                        .ToArray()
                })
                .OrderBy(c => c.Name)
                .ToArray();

            var output = new StringBuilder();

            foreach (var c in categories)
            {
                output.AppendLine($"--{c.Name}");

                foreach (var b in c.Top3Recent)
                    output.AppendLine($"{b}");
            }

            return output.ToString().TrimEnd();
        }

        //15. Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            IQueryable<Book> booksBefore2010 = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            //booksBefore2010.Update(book => new Book { Price = book.Price + 5 });

            //That works in Judge!
            foreach (var book in booksBefore2010)
                book.Price += 5;

            context.SaveChanges();
        }

        //16. Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            //int output = context.Books
            //    .Where(b => b.Copies < 4200)
            //    .Delete();


            //That works in Judge!

            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            context.RemoveRange(books);
            context.SaveChanges();

            int output = books.Length;

            return output;
        }
    }
}
