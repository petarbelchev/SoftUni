namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void TestConstructorAndGetters()
        {
            Warrior warrior = new Warrior("Warrior", 50, 100);

            Assert.That(warrior.Name, Is.EqualTo("Warrior"), "Constructor doesn't set Name right!");
            Assert.That(warrior.Damage, Is.EqualTo(50), "Constructor doesn't set Damage right!");
            Assert.That(warrior.HP, Is.EqualTo(100), "Constructor doesn't set HP right!");
        }

        [Test]
        public void TestSetters()
        {
            Assert.That(() =>
            {
                Warrior warrior = new Warrior("", 50, 100);
            }, 
            Throws.ArgumentException.With.Property("Message")
                .EqualTo("Name should not be empty or whitespace!"), 
                    "Name setter doesn't throw an exception with empty parameter!");

            Assert.That(() =>
            {
                Warrior warrior = new Warrior(null, 50, 100);
            },
            Throws.ArgumentException.With.Property("Message")
                .EqualTo("Name should not be empty or whitespace!"),
                    "Name setter doesn't throw an exception with \"null\" parameter!");

            Assert.That(() =>
            {
                Warrior warrior = new Warrior(" ", 50, 100);
            },
            Throws.ArgumentException.With.Property("Message")
                .EqualTo("Name should not be empty or whitespace!"),
                    "Name setter doesn't throw an exception with white space parameter!");

            Assert.That(() =>
            {
                Warrior warrior = new Warrior("Warrior", 0, 100);
            },
            Throws.ArgumentException.With.Property("Message")
                .EqualTo("Damage value should be positive!"),
                    "Damage setter doesn't throw an exception with non positive parameter!");

            Assert.That(() =>
            {
                Warrior warrior = new Warrior("Warrior", 50, -1);
            },
            Throws.ArgumentException.With.Property("Message")
                .EqualTo("HP should not be negative!"),
                    "HP setter doesn't throw an exception with negative parameter!");
        }

        [Test]
        public void TestAttackMethod()
        {
            Assert.That(() =>
            {
                Warrior warrior1 = new Warrior("Warrior1", 40, 30);
                Warrior warrior2 = new Warrior("Warrior2", 30, 100);
                warrior1.Attack(warrior2);
            }, 
            Throws.InvalidOperationException.With.Property("Message")
                .EqualTo("Your HP is too low in order to attack other warriors!"),
                    "Attack method should throw an exception when attacker HP is below or equal to 30!");

            Assert.That(() =>
            {
                Warrior warrior1 = new Warrior("Warrior1", 40, 100);
                Warrior warrior2 = new Warrior("Warrior2", 30, 30);
                warrior1.Attack(warrior2);
            }, 
            Throws.InvalidOperationException.With.Property("Message")
                .EqualTo("Enemy HP must be greater than 30 in order to attack him!"),
                    "Attack method should throw an exception when defender HP is below or equal to 30!");

            Assert.That(() =>
            {
                Warrior warrior1 = new Warrior("Warrior1", 40, 35);
                Warrior warrior2 = new Warrior("Warrior2", 36, 50);
                warrior1.Attack(warrior2);
            },
            Throws.InvalidOperationException.With.Property("Message")
                .EqualTo("You are trying to attack too strong enemy"),
                    "Attack method should throw an exception when attacker HP is below defender's damage!");

            Assert.That(() =>
            {
                Warrior warrior1 = new Warrior("Warrior1", 60, 100);
                Warrior warrior2 = new Warrior("Warrior2", 36, 50);
                warrior1.Attack(warrior2);
                return warrior2.HP;
            }, 
            Is.EqualTo(0), 
                "Attack method doesn't subtract defender HP properly when attacker damager is bigger!");
        }
    }
}