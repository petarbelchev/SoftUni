namespace ChristmasPastryShop.Models.Booths
{
    using Contracts;
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using ChristmasPastryShop.Repositories;
    using ChristmasPastryShop.Repositories.Contracts;
    using ChristmasPastryShop.Utilities.Messages;

    using System;
    using System.Text;

    public class Booth : IBooth
    {
        private int capacity;

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            CurrentBill = 0;
            Turnover = 0;
            IsReserved = false;
            DelicacyMenu = new DelicacyRepository();
            CocktailMenu = new CocktailRepository();
        }

        public int BoothId { get; private set; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);

                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu { get; private set; }

        public IRepository<ICocktail> CocktailMenu { get; private set; }

        public double CurrentBill { get; private set; }

        public double Turnover { get; private set; }

        public bool IsReserved { get; private set; }

        public void ChangeStatus()
            => IsReserved = !IsReserved;

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
            => CurrentBill += amount;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Booth: {BoothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover:F2} lv");
            sb.AppendLine($"-Cocktail menu:");

            foreach (var c in CocktailMenu.Models)
                sb.AppendLine(c.ToString());

            sb.AppendLine($"-Delicacy menu:");

            foreach (var d in DelicacyMenu.Models)
                sb.AppendLine(d.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}
