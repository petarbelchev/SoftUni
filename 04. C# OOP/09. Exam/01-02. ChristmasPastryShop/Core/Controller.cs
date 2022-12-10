namespace ChristmasPastryShop.Core
{
    using ChristmasPastryShop.Models.Booths;
    using ChristmasPastryShop.Models.Booths.Contracts;
    using ChristmasPastryShop.Models.Cocktails;
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Models.Delicacies;
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using ChristmasPastryShop.Repositories;
    using ChristmasPastryShop.Repositories.Contracts;
    using ChristmasPastryShop.Utilities.Messages;
    using Contracts;

    using System;
    using System.Linq;

    public class Controller : IController
    {
        private IRepository<IBooth> booths;

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothId = booths.Models.Count + 1;
            IBooth booth = new Booth(boothId, capacity);
            booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != nameof(Hibernation) && cocktailTypeName != nameof(MulledWine))
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);

            if (size != "Large" && size != "Middle" && size != "Small")
                return string.Format(OutputMessages.InvalidCocktailSize, size);

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == cocktailName && c.Size == size);

            if (cocktail != null)
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);

            if (cocktailTypeName == nameof(Hibernation))
                cocktail = new Hibernation(cocktailName, size);
            else if (cocktailTypeName == nameof(MulledWine))
                cocktail = new MulledWine(cocktailName, size);

            booth.CocktailMenu.AddModel(cocktail);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == delicacyName);

            if (delicacy != null)
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);

            if (delicacyTypeName == nameof(Gingerbread))
                delicacy = new Gingerbread(delicacyName);
            else if (delicacyTypeName == nameof(Stolen))
                delicacy = new Stolen(delicacyName);
            else
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);

            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            booth.Charge();
            booth.ChangeStatus();

            return $"Bill {booth.Turnover:f2} lv" + Environment.NewLine + $"Booth {boothId} is now available!";
        }

        public string ReserveBooth(int countOfPeople)
        {
            var suitableBooth = booths.Models
                .Where(b => !b.IsReserved && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();

            if (suitableBooth == null)
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);

            suitableBooth.ChangeStatus();

            return string.Format(OutputMessages.BoothReservedSuccessfully, suitableBooth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] orderData = order.Split("/", StringSplitOptions.RemoveEmptyEntries);
            string itemTypeName = orderData[0];
            string itemName = orderData[1];
            int countPieces = int.Parse(orderData[2]);

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (itemTypeName == nameof(MulledWine) || itemTypeName == nameof(Hibernation))
            {
                string size = orderData[3];
                ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == itemName);

                if (cocktail == null)
                    return string.Format(OutputMessages.CocktailStillNotAdded, itemTypeName, itemName);

                if (cocktail.Size != size)
                    return string.Format(OutputMessages.NotRecognizedItemName, size, itemName);

                booth.UpdateCurrentBill(cocktail.Price * countPieces);

                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countPieces, itemName);
            }
            else if (itemTypeName == nameof(Gingerbread) || itemTypeName == nameof(Stolen))
            {
                IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == itemName);

                if (delicacy == null)
                    return string.Format(OutputMessages.CocktailStillNotAdded, itemTypeName, itemName);

                booth.UpdateCurrentBill(delicacy.Price * countPieces);

                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countPieces, itemName);
            }
            else
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }
        }
    }
}
