namespace BookingApp.Models.Bookings.Contracts
{
    using BookingApp.Models.Rooms.Contracts;

    public interface IBooking
    {
        IRoom Room { get; }
        int ResidenceDuration { get; }
        int AdultsCount { get; }
        int ChildrenCount { get; }
        public int BookingNumber { get; }
        string BookingSummary();
    }
}
