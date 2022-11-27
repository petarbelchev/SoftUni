namespace BookingApp.Repositories
{
    using BookingApp.Models.Bookings.Contracts;
    using Contracts;
    
    using System.Collections.Generic;
    using System.Linq;
    
    public class BookingRepository : IRepository<IBooking>
    {
        private ICollection<IBooking> bookings;

        public BookingRepository() => this.bookings = new List<IBooking>();

        public void AddNew(IBooking booking) => this.bookings.Add(booking);

        public IReadOnlyCollection<IBooking> All() 
            => (IReadOnlyCollection<IBooking>)this.bookings;

        public IBooking Select(string bookingNumberToString) 
            => this.bookings.FirstOrDefault(b => b.BookingNumber == int.Parse(bookingNumberToString));
    }
}
