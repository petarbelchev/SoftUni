using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Collection
{
    public class ListyIterator <T> : IEnumerable<T>
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

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.elements.Count; i++)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
