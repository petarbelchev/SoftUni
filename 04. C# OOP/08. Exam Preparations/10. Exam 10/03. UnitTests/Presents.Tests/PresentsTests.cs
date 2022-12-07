namespace Presents.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void CreateWhenPresentIsNullShouldThrow()
        {
            Bag bag = new Bag();
            Present present = null;

            Assert.That(() =>
            {
                bag.Create(present);
            }, Throws.ArgumentNullException, "Present is null");
        }

        [Test]
        public void CreateWhenPresentExistsShouldThrow()
        {
            Bag bag = new Bag();
            Present present = new Present("Present1", 5.00);
            bag.Create(present);

            Assert.That(() =>
            {
                bag.Create(present);
            }, Throws.InvalidOperationException, "This present already exists!");
        }

        [Test]
        public void RemoveShouldWorkCorrectly()
        {
            Bag bag = new Bag();
            Present present = new Present("Present1", 5.00);
            bag.Create(present);

            bool result = bag.Remove(present);
            bool result2 = bag.Remove(present);

            Assert.That(result, Is.True);
            Assert.That(result2, Is.False);
        }

        [Test]
        public void GetPresentWithLeastMagicShouldWorkCorrectly()
        {
            Bag bag = new Bag();
            Present present1 = new Present("Present1", 5.00);
            Present present2 = new Present("Present2", 3.00);
            bag.Create(present1);
            bag.Create(present2);

            Present returnedPresent = bag.GetPresentWithLeastMagic();

            Assert.That(returnedPresent, Is.EqualTo(present2));
        }

        [Test]
        public void GetPresentShouldWorkCorrectly()
        {
            Bag bag = new Bag();
            Present present1 = new Present("Present1", 5.00);
            Present present2 = new Present("Present2", 3.00);
            bag.Create(present1);
            bag.Create(present2);

            Present returnedPresent = bag.GetPresent("Present1");

            Assert.That(returnedPresent, Is.EqualTo(present1));
        }

        [Test]
        public void GetPresentsShouldWorkCorrectly()
        {
            Bag bag = new Bag();
            Present present1 = new Present("Present1", 5.00);
            Present present2 = new Present("Present2", 3.00);
            bag.Create(present1);
            bag.Create(present2);

            var returnedPresents = bag.GetPresents();

            Assert.That(returnedPresents.Count, Is.EqualTo(2));
        }
    }
}
