using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void TestConstructorAndGetters()
            {
                Garage garage = new Garage("TestGarage", 10);
                Assert.IsTrue(garage.Name == "TestGarage");
                Assert.IsTrue(garage.MechanicsAvailable == 10);
            }

            [TestCase("")]
            [TestCase(null)]
            public void TestNameSetterWithInvalidParameters(string garageName)
            {
                Assert.Throws<ArgumentNullException>(() => 
                { 
                    Garage garage = new Garage(garageName, 10); 
                }, 
                "Invalid garage name.", "");
            }

            [Test]
            public void TestMechanicsAvailableSetterWithInvalidParameter()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage("TestGarage", 0);
                },
                "At least one mechanic must work in the garage.");
            }

            [Test]
            public void TestAddCarMethodWithMoreCarsThanMechanics()
            {
                Garage garage = new Garage("TestGarage", 1);
                garage.AddCar(new Car("Audi", 2));

                Assert.Throws<InvalidOperationException>(() => garage.AddCar(new Car("BMW", 2)),
                    "No mechanic available.");
            }

            [Test]
            public void TestAddCarMethodWithLessCarsThanMechanics()
            {
                Garage garage = new Garage("TestGarage", 2);
                garage.AddCar(new Car("Audi", 2));
                garage.AddCar(new Car("BMW", 2));

                Assert.IsTrue(garage.CarsInGarage == 2);
            }

            [Test]
            public void TestFixCarMethodWithNonExistedCar()
            {
                Garage garage = new Garage("TestGarage", 2);
                garage.AddCar(new Car("Audi", 2));
                garage.AddCar(new Car("BMW", 2));

                Assert.Throws<InvalidOperationException>(() => garage.FixCar("Mercedes"), 
                    "The car Mercedes doesn't exist.");
            }

            [Test]
            public void TestFixCarMethodWithExistingCar()
            {
                Garage garage = new Garage("TestGarage", 2);
                Car car = new Car("Audi", 2);
                garage.AddCar(car);
                Car fixedCar = garage.FixCar("Audi");

                Assert.IsTrue(fixedCar.NumberOfIssues == 0);
            }

            [Test]
            public void TestRemoveFixedCarsMethodWhenGarageDoesntHaveFixedCars ()
            {
                Garage garage = new Garage("TestGarage", 2);
                Car car = new Car("Audi", 2);
                Car car2 = new Car("BMW", 2);
                garage.AddCar(car);
                garage.AddCar(car2);

                Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar(),
                    "No fixed cars available.");
            }

            [Test]
            public void TestRemoveFixedCarsMethodWhenGarageHaveFixedCars()
            {
                Garage garage = new Garage("TestGarage", 2);
                Car car = new Car("Audi", 2);
                Car car2 = new Car("BMW", 2);
                garage.AddCar(car);
                garage.AddCar(car2);
                garage.FixCar("BMW");

                int fixedCars = garage.RemoveFixedCar();

                Assert.IsTrue(fixedCars == 1);
                Assert.IsTrue(garage.CarsInGarage == 1);
            }

            [Test]
            public void TestReportMethodWithUnfixedCars()
            {
                Garage garage = new Garage("TestGarage", 2);
                Car car = new Car("Audi", 2);
                Car car2 = new Car("BMW", 2);
                garage.AddCar(car);
                garage.AddCar(car2);

                string actual = garage.Report();
                string expected = "There are 2 which are not fixed: Audi, BMW.";

                Assert.IsTrue(actual.Equals(expected));
            }

            [Test]
            public void TestReportMethodWithFixedCars()
            {
                Garage garage = new Garage("TestGarage", 3);
                Car car = new Car("Audi", 2);
                Car car2 = new Car("BMW", 2);
                Car car3 = new Car("Mercedes", 2);
                garage.AddCar(car);
                garage.AddCar(car2);
                garage.AddCar(car3);
                garage.FixCar("Audi");

                string actual = garage.Report();
                string expected = "There are 2 which are not fixed: BMW, Mercedes.";

                Assert.IsTrue(actual.Equals(expected));
            }
        }
    }
}