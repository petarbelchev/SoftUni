using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Dummy dummy;

        [SetUp]
        public void InitialSetUp()
        {
            this.dummy = new Dummy(30, 20);
        }

        [Test]
        public void WeaponShouldLosesDurabilityAfterEachAttack()
        {
            Axe axe = new Axe(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe doesn't change his DurabilityPoints!");

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(8), "Axe doesn't change his DurabilityPoints!");
        }

        [Test]
        public void AttackingWithABrokenWeapon()
        {
            Axe axe = new Axe(10, 0);

            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException, "Axe attacks with broken weapon!");
        }
    }
}