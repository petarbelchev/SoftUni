using System;
using System.Text;

namespace _05._HTML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder htmlArticle = new StringBuilder();

            htmlArticle.AppendLine("<h1>");
            htmlArticle.AppendLine($"    {Console.ReadLine()}");
            htmlArticle.AppendLine("</h1>");
            htmlArticle.AppendLine("<article>");
            htmlArticle.AppendLine($"    {Console.ReadLine()}");
            htmlArticle.AppendLine("</article>");

            string comment = Console.ReadLine();

            while (comment != "end of comments")
            {
                htmlArticle.AppendLine("<div>");
                htmlArticle.AppendLine($"    {comment}");
                htmlArticle.AppendLine("</div>");

                comment = Console.ReadLine();
            }

            Console.WriteLine(htmlArticle.ToString().TrimEnd());
        }
    }
}
