namespace BookingApp.Core
{
    using BookingApp.Models.Bookings;
    using BookingApp.Models.Hotels;
    using BookingApp.Models.Hotels.Contacts;
    using BookingApp.Models.Rooms;
    using BookingApp.Repositories;
    using BookingApp.Repositories.Contracts;
    using BookingApp.Utilities.Messages;
    using Contracts;

    using System;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private IRepository<IHotel> hotels;

        public Controller() => this.hotels = new HotelRepository();

        public string AddHotel(string hotelName, int category)
        {
            if (this.hotels.Select(hotelName) != null)
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);

            this.hotels.AddNew(new Hotel(hotelName, category));

            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            var orderedHotelsWithThatCategory = this.hotels.All()
                .Where(h => h.Category == category)
                .OrderBy(h => h.FullName);

            if (orderedHotelsWithThatCategory.Count() == 0)
                return string.Format(OutputMessages.CategoryInvalid, category);

            foreach (var hotel in orderedHotelsWithThatCategory)
            {
                var room = hotel.Rooms.All()
                    .OrderBy(r => r.BedCapacity)
                    .FirstOrDefault(r => r.BedCapacity >= adults + children);

                if (room == null) 
                    continue;

                int bookingNumber = hotel.Bookings.All().Count() + 1;
                var booking = new Booking(room, duration, adults, children, bookingNumber);
                hotel.Bookings.AddNew(booking);

                return string.Format(OutputMessages.BookingSuccessful, bookingNumber, hotel.FullName);
            }

            return string.Format(OutputMessages.RoomNotAppropriate);
        }

        public string HotelReport(string hotelName)
        {
            var hotel = this.hotels.Select(hotelName);

            if (hotel == null)
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);

            var sb = new StringBuilder();
            sb.AppendLine($"Hotel name: {hotel.FullName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            sb.AppendLine("--Bookings:");

            var bookings = hotel.Bookings.All();

            if (bookings.Count > 0)
            {
                foreach (var book in bookings)
                    sb.AppendLine(book.BookingSummary());
            }
            else
            {
                sb.AppendLine();
                sb.AppendLine("none");
            }

            return sb.ToString().TrimEnd();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            var hotel = this.hotels.Select(hotelName);

            if (hotel == null)
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);

            if (roomTypeName != "DoubleBed"
                && roomTypeName != "Studio"
                && roomTypeName != "Apartment")
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            var room = hotel.Rooms.Select(roomTypeName);

            if (room == default)
                return string.Format(OutputMessages.RoomTypeNotCreated);

            if (room.PricePerNight > 0)
                throw new InvalidOperationException(ExceptionMessages.CannotResetInitialPrice);

            room.SetPrice(price);

            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            var hotel = this.hotels.Select(hotelName);

            if (hotel == null)
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);

            var room = hotel.Rooms.Select(roomTypeName);

            if (room != default)
                return string.Format(OutputMessages.RoomTypeAlreadyCreated);

            if (roomTypeName == "DoubleBed")
                room = new DoubleBed();
            else if (roomTypeName == "Studio")
                room = new Studio();
            else if (roomTypeName == "Apartment")
                room = new Apartment();
            else
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);

            hotel.Rooms.AddNew(room);

            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }
    }
}
