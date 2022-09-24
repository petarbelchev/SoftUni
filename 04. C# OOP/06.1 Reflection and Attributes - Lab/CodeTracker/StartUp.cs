using System;

namespace AuthorProblem
{
    [Author("Petar")]
    public class StartUp
    {
        [Author("Stoyan")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();

            tracker.PrintMethodsByAuthor();
        }
    }
}
