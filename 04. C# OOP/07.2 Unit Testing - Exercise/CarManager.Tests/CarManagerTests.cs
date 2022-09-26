namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void Test_Constructors_And_Getters()
        {
            Car car = new Car("Audi", "A8", 9.5, 65.5);
            Assert.That(car.FuelAmount, Is.EqualTo(0), "The private ctor doesn't work properly!");
            Assert.That(car.Make, Is.EqualTo("Audi"), "The public ctor doesn't set Make properly!");
            Assert.That(car.Model, Is.EqualTo("A8"), "The public ctor doesn't set Model properly!");
            Assert.That(car.FuelConsumption, Is.EqualTo(9.5), "The public ctor doesn't set FuelConsumption properly!");
            Assert.That(car.FuelCapacity, Is.EqualTo(65.5), "The public ctor doesn't set FuelCapacity properly!");
        }

        [Test]
        public void Test_Properties_Setters()
        {
            Assert.That(() =>
            {
                Car car = new Car(null, "A8", 9.5, 65.5);
            },
            Throws.ArgumentException.With.Property("Message")
                .EqualTo("Make cannot be null or empty!"));

            Assert.That(() =>
            {
                Car car = new Car("", "A8", 9.5, 65.5);
            },
            Throws.ArgumentException.With.Property("Message")
                .EqualTo("Make cannot be null or empty!"));

            Assert.That(() =>
            {
                Car car = new Car("Audi", "", 9.5, 65.5);
            },
            Throws.ArgumentException.With.Property("Message")
                .EqualTo("Model cannot be null or empty!"));

            Assert.That(() =>
            {
                Car car = new Car("Audi", null, 9.5, 65.5);
            },
            Throws.ArgumentException.With.Property("Message")
                .EqualTo("Model cannot be null or empty!"));

            Assert.That(() =>
            {
                Car car = new Car("Audi", "A8", 0, 65.5);
            },
            Throws.ArgumentException.With.Property("Message")
                .EqualTo("Fuel consumption cannot be zero or negative!"));

            Assert.That(() =>
            {
                Car car = new Car("Audi", "A8", 9.5, 0);
            },
            Throws.ArgumentException.With.Property("Message")
                .EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]
        public void Test_Refuel_Method_With_Invalid_Amount()
        {
            Car car = new Car("Audi", "A8", 9.5, 65.5);

            Assert.That(() => car.Refuel(0),
                Throws.ArgumentException
                    .With.Property("Message")
                    .EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void Test_Refuel_Method_With_More_Than_Capacity_Amount()
        {
            Car car = new Car("Audi", "A8", 9.5, 65.5);

            Assert.That(() =>
            {
                car.Refuel(65.6);
                return car.FuelAmount;
            },
            Is.EqualTo(65.5), "Refuel with more than capacity doesn't work properly!");
        }

        [Test]
        public void Test_Refuel_Method_With_Valid_Amount()
        {
            Car car = new Car("Audi", "A8", 9.5, 65.5);

            Assert.That(() =>
            {
                car.Refuel(30);
                return car.FuelAmount;
            },
            Is.EqualTo(30), "Refuel with valid amount doesn't work properly!");
        }

        [Test]
        public void Test_Drive_With_Not_Enough_Fuel_Amount()
        {
            Car car = new Car("Audi", "A8", 9.5, 65.5);
            car.Refuel(14.24);

            Assert.That(() => car.Drive(150),
                Throws.InvalidOperationException
                    .With.Property("Message")
                    .EqualTo("You don't have enough fuel to drive!"));
        }

        [Test]
        public void Test_Drive_With_Enough_Fuel_Amount()
        {
            Car car = new Car("Audi", "A8", 9.5, 65.5);
            car.Refuel(14.26);
            car.Drive(150);

            Assert.That(car.FuelAmount, Is.EqualTo(14.26 - 14.25), "Drive method doesn't work properly with valid fuel amount!");
        }
    }
}