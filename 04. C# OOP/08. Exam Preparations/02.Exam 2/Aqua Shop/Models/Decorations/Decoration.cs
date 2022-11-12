namespace AquaShop.Models.Decorations
{
    using Contracts;

    public abstract class Decoration : IDecoration
    {
        protected Decoration(int comfort, decimal price)
        {
            this.Comfort= comfort;
            this.Price= price;
        }

        public int Comfort { get; protected set; }

        public decimal Price { get; protected set; }
    }
}
