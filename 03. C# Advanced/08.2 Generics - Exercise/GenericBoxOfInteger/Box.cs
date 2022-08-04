namespace GenericBoxOfInteger
{
    public class Box<T>
    {
        public Box(T item)
        {
            Item = item;
        }

        public T Item { get; set; }

        public override string ToString()
        {
            return $"{typeof(T)}: {Item}";
        }
    }
}
