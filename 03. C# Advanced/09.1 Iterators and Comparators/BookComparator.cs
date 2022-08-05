using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            int result = x.Title.CompareTo(y.Title);
            if (result == 0)
            {
                result = x.Year.CompareTo(y.Year);
                if (result < 0)
                {
                    return 1;
                }
                else if (result > 0)
                {
                    return -1;
                }
            }
            return result;
        }
    }
}
