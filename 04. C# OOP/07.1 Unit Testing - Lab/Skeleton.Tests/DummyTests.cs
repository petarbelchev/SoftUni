using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Axe axe;

        [SetUp]
        public void InitialSetUp()
        {
            this.axe = new Axe(10, 20);
        }

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            Dummy dummy = new Dummy(100, 50);            
            axe.Attack(dummy);

            Assert.That(dummy.Health, Is.EqualTo(90), "Dummy does not lose a health after attack!");
        }

        [Test]
        public void DeadDummyThrowsAnExceptionIfAttacked()
        {
            Dummy dummy = new Dummy(0, 20);

            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException, "You atack a dead Dummy!");
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(0, 20);

            Assert.That(() => dummy.GiveExperience(), Is.EqualTo(20), "Dead Dummy doesn't give a XP!");
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            Dummy dummy = new Dummy(100, 20);

            Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException, "Alive Dummy give a XP!");
        }
    }
}