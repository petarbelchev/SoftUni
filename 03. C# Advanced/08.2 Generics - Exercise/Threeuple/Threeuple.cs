namespace Threeuple
{
    internal class Threeuple<TFirst, TSecond, TThird>
    {
        public Threeuple(TFirst item1, TSecond item2, TThird item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }

        public TFirst Item1 { get; set; }

        public TSecond Item2 { get; set; }

        public TThird Item3 { get; set; }

        public override string ToString()
        {
            return $"{Item1} -> {Item2} -> {Item3}";
        }
    }
}