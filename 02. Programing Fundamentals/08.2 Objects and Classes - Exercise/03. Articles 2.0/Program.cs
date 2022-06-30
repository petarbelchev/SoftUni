using System;
using System.Collections.Generic;

namespace _03._Articles_2._0
{
    internal class Program
    {
        class Article
        {
            public Article(string title, string content, string author)
            {
                this.Title = title;
                this.Content = content;
                this.Author = author;
            }

            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }
        }

        static void Main(string[] args)
        {
            int numsOfArticles = int.Parse(Console.ReadLine());
            
            List<Article> articles = new List<Article>();

            for (int i = 1; i <= numsOfArticles; i++)
            {
                string[] article = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string title = article[0];
                string content = article[1];
                string author = article[2];

                Article newArticle = new Article(title, content, author);

                articles.Add(newArticle);
            }

            foreach (Article article in articles)
            {
                Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
            }
        }
    }
}