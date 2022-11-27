using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        [TestCase("", 3)]
        [TestCase(null, 3)]
        [TestCase(" ", 3)]
        public void TestConstructorWithInvalidName(string fullName, int category)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Hotel hotel = new Hotel(fullName, category);
            });
        }

        [TestCase("MyHotel", 0)]
        [TestCase("MyHotel", -1)]
        [TestCase("MyHotel", 6)]
        [TestCase("MyHotel", 10)]
        public void TestConstructorWithInvalidCategory(string fullName, int category)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Hotel hotel = new Hotel(fullName, category);
            });
        }

        [TestCase("MyHotel", 1)]
        [TestCase("MyHotel", 3)]
        [TestCase("MyHotel", 5)]
        public void TestConstructorWithValidParams(string fullName, int category)
        {
            Hotel hotel = new Hotel(fullName, category);

            Assert.AreEqual(hotel.FullName, fullName);
            Assert.AreEqual(hotel.Category, category);
            Assert.AreEqual(hotel.Turnover, 0);
            Assert.AreEqual(hotel.Rooms.Count, 0);
            Assert.AreEqual(hotel.Bookings.Count, 0);
        }

        [TestCase("MyHotel", 1)]
        public void TestAddRoomMethod(string fullName, int category)
        {
            Hotel hotel = new Hotel(fullName, category);

            hotel.AddRoom(new Room(2, 20));

            Assert.AreEqual(hotel.Rooms.Count, 1);
        }

        [TestCase("MyHotel", 1, 0, 2, 2, 100, 4, 40)] // invalid adults
        [TestCase("MyHotel", 1, 2, -1, 2, 100, 4, 40)] // invalid children
        [TestCase("MyHotel", 1, 2, 2, 0, 100, 4, 40)] // invalid residenceDuration
        public void TestBookRoomWithInvalidParams(string fullName, int category, int adults, int children, int residenceDuration, double budget, int bedCapacity, double pricePerNight)
        {
            Hotel hotel = new Hotel(fullName, category);
            Room room = new Room(bedCapacity, pricePerNight);
            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(adults, children, residenceDuration, budget);
            });
        }

        [TestCase("MyHotel", 1, 2, 2, 2, 100, 3, 40)]
        public void TestNeededBedsWhenRoomDontHaveEnoughtBeds(string fullName, int category, int adults, int children, int residenceDuration, double budget, int bedCapacity, double pricePerNight)
        {
            Hotel hotel = new Hotel(fullName, category);
            Room room = new Room(bedCapacity, pricePerNight);
            hotel.AddRoom(room);
            hotel.BookRoom(adults, children, residenceDuration, budget);
            Assert.AreEqual(0, hotel.Bookings.Count);
        }

        [TestCase("MyHotel", 1, 2, 2, 2, 70, 4, 40)]
        public void TestNeededBudgetWhenDontHaveMoney(string fullName, int category, int adults, int children, int residenceDuration, double budget, int bedCapacity, double pricePerNight)
        {
            Hotel hotel = new Hotel(fullName, category);
            Room room = new Room(bedCapacity, pricePerNight);
            hotel.AddRoom(room);
            hotel.BookRoom(adults, children, residenceDuration, budget);
            Assert.AreEqual(0, hotel.Bookings.Count);
        }

        [TestCase("MyHotel", 1, 2, 2, 2, 100, 4, 40)]
        public void TestWithValidParams(string fullName, int category, int adults, int children, int residenceDuration, double budget, int bedCapacity, double pricePerNight)
        {
            Hotel hotel = new Hotel(fullName, category);
            Room room = new Room(bedCapacity, pricePerNight);
            hotel.AddRoom(room);
            hotel.BookRoom(adults, children, residenceDuration, budget);
            Assert.AreEqual(1, hotel.Bookings.Count);
            Assert.AreEqual(80, hotel.Turnover);
        }
    }
}