namespace Tuple
{
    internal class Tuple<TFirst, TSecond>
    {
        private TFirst item1;
        private TSecond item2;
        
        public Tuple(TFirst item1,TSecond item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public TFirst Item1 { get { return item1; } }

        public TSecond Item2 { get { return item2; } }

        public override string ToString()
        {
            return $"{Item1} -> {Item2}";
        }
    }
}
