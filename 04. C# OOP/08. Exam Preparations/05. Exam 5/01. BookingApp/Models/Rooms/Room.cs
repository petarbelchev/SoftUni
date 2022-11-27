namespace BookingApp.Models.Rooms
{
    using Contracts;
    using BookingApp.Utilities.Messages;

    using System;

    public abstract class Room : IRoom
    {
        protected Room(int bedCapacity)
        {
            this.BedCapacity = bedCapacity;
            this.PricePerNight = 0;
        }

        public int BedCapacity { get; private set; }

        public double PricePerNight { get; private set; }

        public void SetPrice(double price)
        {
            if (price < 0)
                throw new ArgumentException(ExceptionMessages.PricePerNightNegative);

            this.PricePerNight = price;
        }
    }
}
