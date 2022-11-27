namespace BookingApp.Models.Hotels.Contacts
{
    using BookingApp.Models.Bookings.Contracts;
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Repositories.Contracts;

    public interface IHotel
    {
        string FullName { get; }
        int Category { get; }
        double Turnover { get; }

        public IRepository<IRoom> Rooms { get; }
        public IRepository<IBooking> Bookings { get; }
    }
}
