using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class ListyIterator <T>
    {
        private List<T> elements;
        private int currentIndex;

        public void Create(params T[] elements)
        {
            this.elements = elements.ToList();
            this.currentIndex = 0;
        }

        public bool Move()
        {
            if (HasNext())
            {
                return ++this.currentIndex < elements.Count;
            }
            return false;
        }

        public bool HasNext()
        {
            return currentIndex + 1 < elements.Count;
        }

        public void Print()
        {
            if (this.elements.Count > 0)
            {
                Console.WriteLine(this.elements[currentIndex]);
            }
            else
            {
                Console.WriteLine("Invalid Operation!");
            }
        }
    }
}
