using System;

namespace _02._Articles
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

            public Article(/*object newContent, object newAuthor, object newTitle*/)
            {
                Edit(newContent.ToString());
                ChangeAuthor(newAuthor.ToString());
                Rename(newTitle.ToString());
            }

            public object newContent;
            public object newAuthor;
            public object newTitle;

            public void Rename(string newTitle)
            {
                this.Title = newTitle;
            }

            public void ChangeAuthor(string newAuthor)
            {
                this.Author = newAuthor;
            }

            public void Edit(string newContent)
            {
                this.Content = newContent;
            }
        }
        static void Main(string[] args)
        {
            string[] article = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string title = article[0];
            string content = article[1];
            string author = article[2];

            Article newArticle = new Article(title, content, author);

            int numsOfCmds = int.Parse(Console.ReadLine());

            for (int cmd = 1; cmd <= numsOfCmds; cmd++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string mainCmd = cmdArgs[0];
                switch (mainCmd)
                {
                    case "Edit":
                        string newContent = cmdArgs[1];
                        newArticle.Edit(newContent);
                        break;

                    case "ChangeAuthor":
                        string newAuthor = cmdArgs[1];
                        newArticle.ChangeAuthor(newAuthor);
                        break;

                    case "Rename":
                        string newTitle = cmdArgs[1];
                        newArticle.Rename(newTitle);
                        break;
                }
            }

            Console.WriteLine($"{newArticle.Title} - {newArticle.Content}: {newArticle.Author}");
        }
    }
}
