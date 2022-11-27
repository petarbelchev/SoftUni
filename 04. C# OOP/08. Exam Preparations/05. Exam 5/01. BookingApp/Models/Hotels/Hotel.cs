namespace BookingApp.Models.Hotels
{
    using BookingApp.Models.Bookings.Contracts;
    using Contacts;
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Repositories;
    using BookingApp.Repositories.Contracts;
    using BookingApp.Utilities.Messages;

    using System;
    
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;

        public Hotel(string fullName, int category)
        {
            this.FullName = fullName;
            this.Category = category;
            this.Rooms = new RoomRepository();
            this.Bookings = new BookingRepository();
        }

        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);

                this.fullName = value;
            }
        }

        public int Category
        {
            get => this.category;
            private set
            {
                if (value < 1 || value > 5)
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);

                this.category = value;
            }
        }

        public double Turnover
        {
            get
            {
                double sum = 0;
                
                foreach (var booking in this.Bookings.All())
                    sum += booking.ResidenceDuration * booking.Room.PricePerNight;

                return Math.Round(sum, 2);
            }
        }

        public IRepository<IRoom> Rooms { get; set; }

        public IRepository<IBooking> Bookings { get; set; }
    }
}
