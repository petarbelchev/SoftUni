namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void InitiateWithCapacityBiggerThan16()
        {
            Assert.That(() =>
            {
                Database database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);
            }, 
            Throws.InvalidOperationException);
        }

        [Test]
        public void InitiateWithCapacitySmallerThan16()
        {
            Assert.That(() =>
            {
                Database database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
            }, 
            Throws.Nothing);
        }

        [Test]
        public void AddOperationShouldAddAnElementAtTheNextFreeCell()
        {
            Database database = new Database(1, 2, 3);
            database.Add(4);
            int[] resultArr = database.Fetch();

            Assert.That(() => resultArr[3], Is.EqualTo(4));
        }

        [Test]
        public void ThrowExceptionWhenTryToAddElementToFullDatabase()
        {
            Database database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.That(() => database.Add(17), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveOperationShouldSupportOnlyRemovingAnElementAtTheLastIndex()
        {
            Database database = new Database(1, 2, 3);
            database.Remove();
            int[] actual = database.Fetch();
            int[] expected = new int[] { 1, 2 };

            Assert.IsTrue(actual.SequenceEqual(expected));
        }

        [Test]
        public void ThrowExceptionWhenTryToRemoveElementFromEmptyDatabase()
        {
            Database database = new Database();

            Assert.That(() => database.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void FetchMethodShouldReturnTheElementsAsAnArray()
        {
            Database database = new Database(1, 2, 3);

            Assert.That(() => database.Fetch(), Is.EqualTo(new int[] { 1, 2, 3 }));
        }

        [Test]
        public void CountPropertyShouldReturnNumberOfElements()
        {
            Database database = new Database(1, 2, 3);
            int actual = database.Count;
            int expected = 3;

            Assert.IsTrue(actual.Equals(expected));
        }
    }
}
