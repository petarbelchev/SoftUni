using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        public Stack<T> Elements { get; set; } = new Stack<T>();
        public int Count { get { return Elements.Count; } }

        public void Add(T element)
        {
            Elements.Push(element);
        }

        public T Remove()
        {
            return Elements.Pop();
        }
    }
}
