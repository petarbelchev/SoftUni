using System;

namespace GenericCountMethodStrings
{
    public class Box<T> : IComparable<T> where T : IComparable<T>
    {
        public Box(T item)
        {
            Item = item;
        }

        public T Item { get; set; }

        public int CompareTo(T other)
        {
            return Item.CompareTo(other);
        }

        public override string ToString()
        {
            return $"{typeof(T)}: {Item}";
        }
    }
}
