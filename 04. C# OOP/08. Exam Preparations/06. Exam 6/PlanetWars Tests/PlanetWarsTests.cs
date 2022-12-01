using NUnit.Framework;
using System;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestCase("", 0)]
        [TestCase(null, 0)]
        public void Test_CtorWithInvalidName(string name, double budget)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Planet planet = new Planet(name, budget);
            }, "Invalid planet Name");
        }

        [TestCase("MyPlanet", -1)]
        [TestCase("MyPlanet", -100)]
        public void Test_CtorWithInvalidBudget(string name, double budget)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Planet planet = new Planet(name, budget);
            }, "Budget cannot drop below Zero!");
        }

        [TestCase("MyPlanet", 0)]
        [TestCase("MyPlanet", 100)]
        public void Test_CtorWithValidParams(string name, double budget)
        {
            Planet planet = new Planet(name, budget);

            Assert.That(planet.Name, Is.EqualTo(name));
            Assert.That(planet.Budget, Is.EqualTo(budget));
            Assert.That(planet.Weapons.Count, Is.EqualTo(0));
        }

        [Test]
        public void Test_MilitaryPowerRatio()
        {
            Planet planet = new Planet("MyPlanet", 100);
            Weapon weapon1 = new Weapon("Weapon1", 10, 1);
            Weapon weapon2 = new Weapon("Weapon2", 20, 2);
            planet.AddWeapon(weapon1);
            planet.AddWeapon(weapon2);
            double expectedDestLevel = 1 + 2;
            double actualDestLevel = planet.MilitaryPowerRatio;

            Assert.That(actualDestLevel, Is.EqualTo(expectedDestLevel));
        }

        [Test]
        public void Test_Profit()
        {
            Planet planet = new Planet("MyPlanet", 100);
            planet.Profit(50);

            double expectedBudget = 100 + 50;
            double actualBudget = planet.Budget;

            Assert.That(actualBudget, Is.EqualTo(expectedBudget));
        }

        [Test]
        public void Test_SpendFunds()
        {
            Planet planet = new Planet("MyPlanet", 100);
            planet.SpendFunds(50);

            double expectedBudget = 100 - 50;
            double actualBudget = planet.Budget;

            Assert.That(actualBudget, Is.EqualTo(expectedBudget));
        }

        [Test]
        public void Test_SpendFundsWithLessBudget()
        {
            Planet planet = new Planet("MyPlanet", 100);

            Assert.That(() => planet.SpendFunds(150),
                Throws.InvalidOperationException,
                "Not enough funds to finalize the deal.");
        }

        [Test]
        public void Test_AddExistingWeapon()
        {
            Planet planet = new Planet("MyPlanet", 100);
            planet.AddWeapon(new Weapon("Weapon", 10, 1));

            Assert.That(() => planet.AddWeapon(new Weapon("Weapon", 10, 1)),
                Throws.InvalidOperationException,
                "There is already a Weapon weapon.");
        }

        [Test]
        public void Test_RemoveWeapon()
        {
            Planet planet = new Planet("MyPlanet", 100);
            planet.AddWeapon(new Weapon("Weapon", 10, 1));
            planet.RemoveWeapon("Weapon");
            int expectedCount = 0;
            int actualCount = planet.Weapons.Count;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Test_UpgradeWeaponWithInvalidName()
        {
            Planet planet = new Planet("MyPlanet", 100);
            planet.AddWeapon(new Weapon("Weapon", 10, 1));

            Assert.That(() => 
            planet.UpgradeWeapon("NotExistWeapon"),
            Throws.InvalidOperationException,
            "NotExistWeapon does not exist in the weapon repository of MyPlanet");
        }

        [Test]
        public void Test_UpgradeWeaponWithValidName()
        {
            Planet planet = new Planet("MyPlanet", 100);
            planet.AddWeapon(new Weapon("Weapon", 10, 1));
            planet.UpgradeWeapon("Weapon");

            int expectedDestLevel = 1 + 1;
            int actualDestLevel = planet.Weapons.FirstOrDefault(w => w.Name == "Weapon").DestructionLevel;

            Assert.That(actualDestLevel, Is.EqualTo(expectedDestLevel));
        }

        [Test]
        public void Test_DestructOpponentWithBiggerPower()
        {
            Planet planet = new Planet("MyPlanet", 100);
            planet.AddWeapon(new Weapon("Weapon", 10, 1));
            Planet opponent = new Planet("Opponent", 100);
            opponent.AddWeapon(new Weapon("Weapon2", 10, 2));

            Assert.That(() => planet.DestructOpponent(opponent), 
                Throws.InvalidOperationException,
                "Opponent is too strong to declare war to!");
        }

        [Test]
        public void Test_DestructOpponentWithLessPower()
        {
            Planet planet = new Planet("MyPlanet", 100);
            planet.AddWeapon(new Weapon("Weapon", 10, 2));
            Planet opponent = new Planet("Opponent", 100);
            opponent.AddWeapon(new Weapon("Weapon2", 10, 1));

            string expectedResult = "Opponent is destructed!";
            string actualResult = planet.DestructOpponent(opponent);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [TestCase("Weapon", -1, 1)]
        [TestCase("Weapon", -10, 1)]
        public void Test_CtorWeaponWithInvalidPrice(string name, double price, int destructionLevel)
        {
            Assert.That(() => { Weapon weapon = new Weapon(name, price, destructionLevel); },
                Throws.ArgumentException, "Price cannot be negative.");
        }

        [TestCase("Weapon", 1, 1)]
        [TestCase("Weapon", 10, 1)]
        public void Test_CtorWeaponWithValidParams(string name, double price, int destructionLevel)
        {
            Weapon weapon = new Weapon(name, price, destructionLevel);

            Assert.That(weapon.Name, Is.EqualTo(name));
            Assert.That(weapon.Price, Is.EqualTo(price));
            Assert.That(weapon.DestructionLevel, Is.EqualTo(destructionLevel));
        }

        [Test]
        public void Test_IsNuclearWhenFalse()
        {
            Weapon weapon = new Weapon("Weapon", 10, 1);

            Assert.That(weapon.IsNuclear, Is.False);
        }

        [Test]
        public void Test_IsNuclearWhenTrue()
        {
            Weapon weapon = new Weapon("Weapon", 10, 10);

            Assert.That(weapon.IsNuclear, Is.True);
        }
    }
}
