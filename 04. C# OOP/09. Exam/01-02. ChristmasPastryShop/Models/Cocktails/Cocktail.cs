namespace ChristmasPastryShop.Models.Cocktails
{
    using Contracts;
    using ChristmasPastryShop.Utilities.Messages;
    
    using System;

    public abstract class Cocktail : ICocktail
    {
        private string name;
        private double price;

        protected Cocktail(string cocktailName, string size, double price)
        {
            Name = cocktailName;
            Size = size;
            Price = price;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);

                name = value;
            }
        }

        public string Size { get; private set; }

        public double Price
        {
            get => price;
            private set
            {
                if (Size == "Large")
                    price = value;
                else if (Size == "Middle")
                    price = (value / 3) * 2;
                else if (Size == "Small")
                    price = (value / 3);
            }
        }

        public override string ToString()
            => $"--{Name} ({Size}) - {Price:F2} lv";
    }
}
