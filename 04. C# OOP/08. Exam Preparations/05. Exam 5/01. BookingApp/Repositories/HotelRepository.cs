namespace BookingApp.Repositories
{
    using BookingApp.Models.Hotels.Contacts;
    using Contracts;

    using System.Collections.Generic;
    using System.Linq;

    public class HotelRepository : IRepository<IHotel>
    {
        private ICollection<IHotel> hotels;

        public HotelRepository() => this.hotels = new List<IHotel>();

        public void AddNew(IHotel hotel) => this.hotels.Add(hotel);

        public IReadOnlyCollection<IHotel> All() => (IReadOnlyCollection<IHotel>)this.hotels;

        public IHotel Select(string hotelName) => this.hotels.FirstOrDefault(h => h.FullName == hotelName);
    }
}
