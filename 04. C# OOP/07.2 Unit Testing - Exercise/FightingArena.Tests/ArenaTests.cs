namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void TestConstructor()
        {
            Arena arena = new Arena();
            Assert.That(arena.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestEnrollMethod()
        {
            Assert.That(() =>
            {
                Arena arena = new Arena();
                arena.Enroll(new Warrior("Warrior1", 100, 100));
                return arena.Count;
            }, 
            Is.EqualTo(1), 
                "Enroll method doesn't add valid warriors properly!");

            Assert.That(() =>
            {
                Arena arena = new Arena();
                arena.Enroll(new Warrior("Warrior1", 100, 100));
                arena.Enroll(new Warrior("Warrior1", 90, 90));
            },
            Throws.InvalidOperationException.With.Property("Message")
                .EqualTo("Warrior is already enrolled for the fights!"),
                    "Enroll method should throw an exception when try to add warrior with name that already exist!");
        }

        [Test]
        public void TestFightMethod()
        {
            Assert.That(() =>
            {
                Arena arena = new Arena();
                arena.Enroll(new Warrior("Warrior1", 100, 100));
                arena.Enroll(new Warrior("Warrior2", 90, 90));
                arena.Fight("Warrior1", null);
            }, 
            Throws.InvalidOperationException.With.Property("Message")
                .EqualTo($"There is no fighter with name {null} enrolled for the fights!"),
                    "Fight method should throw an exception when defender is a null");

            Assert.That(() =>
            {
                Arena arena = new Arena();
                arena.Enroll(new Warrior("Warrior1", 100, 100));
                arena.Enroll(new Warrior("Warrior2", 90, 90));
                arena.Fight(null, "Warrior2");
            }, 
            Throws.InvalidOperationException.With.Property("Message")
                .EqualTo($"There is no fighter with name {null} enrolled for the fights!"),
                     "Fight method should throw an exception when attacker is a null");

            Assert.That(() =>
            {
                Warrior warrior1 = new Warrior("Warrior1", 40, 100);
                Warrior warrior2 = new Warrior("Warrior2", 30, 100);
                Arena arena = new Arena();
                arena.Enroll(warrior1);
                arena.Enroll(warrior2);
                arena.Fight("Warrior1", "Warrior2");
                return $"{warrior1.HP} {warrior2.HP}";
            }, 
            Is.EqualTo("70 60"), "Attack method doesn't work properly with valid parameters!");
        }
    }
}
