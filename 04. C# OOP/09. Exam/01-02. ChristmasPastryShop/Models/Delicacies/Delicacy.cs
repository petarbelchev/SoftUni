namespace ChristmasPastryShop.Models.Delicacies
{
    using Contracts;
    using ChristmasPastryShop.Utilities.Messages;
    
    using System;

    public abstract class Delicacy : IDelicacy
    {
        private string name;

        protected Delicacy(string delicacyName, double price)
        {
            Name = delicacyName;
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

        public double Price { get; private set; }

        public override string ToString()
            => $"--{Name} - {Price:F2} lv";
    }
}
