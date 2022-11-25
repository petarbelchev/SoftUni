namespace Book.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        [Test]
        [TestCase("", "Peter")]
        [TestCase(null, "Peter")]
        public void TestConstructorWithInvalidBookName(string bookName, string author)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book myBook = new Book(bookName, author);
            }, "Invalid BookName!");
        }

        [Test]
        [TestCase("MyBook", "")]
        [TestCase("MyBook", null)]
        public void TestConstructorWithInvalidAuthor(string bookName, string author)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book myBook = new Book(bookName, author);
            }, "Invalid Author!");
        }

        [TestCase("MyBook", "Peter")]
        public void TestConstructorWithValidParams(string bookName, string author)
        {
            Book myBook = new Book(bookName, author);
            Assert.AreEqual(bookName, myBook.BookName);
            Assert.AreEqual(author, myBook.Author);
            Assert.AreEqual(myBook.FootnoteCount, 0);
        }

        [Test]
        public void AddFootnoteMethodShouldThrowExceptionWithExistingFootnote()
        {
            string bookName = "MyBook";
            string author = "Peter";
            Book myBook = new Book(bookName, author);
            myBook.AddFootnote(1, "MyFootnote");

            Assert.Throws<InvalidOperationException>(() =>
            {
                myBook.AddFootnote(1, "MySecondFootnote");
            }, "Footnote already exists!");
        }

        [Test]
        public void TestAddFootnoteMethodWithValidParams()
        {
            string bookName = "MyBook";
            string author = "Peter";
            Book myBook = new Book(bookName, author);
            myBook.AddFootnote(1, "MyFootnote");

            Assert.AreEqual(myBook.FootnoteCount, 1);
        }

        [Test]
        public void TestFindFootnoteWithExistingFootnote()
        {
            string bookName = "MyBook";
            string author = "Peter";
            Book myBook = new Book(bookName, author);
            myBook.AddFootnote(1, "MyFootnote");

            string expected = "Footnote #1: MyFootnote";
            string actual = myBook.FindFootnote(1);

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void TestFindFootnoteWithNotExistingFootnote()
        {
            string bookName = "MyBook";
            string author = "Peter";
            Book myBook = new Book(bookName, author);
            myBook.AddFootnote(1, "MyFootnote");

            Assert.Throws<InvalidOperationException>(() =>
            {
                myBook.FindFootnote(2);
            }, "Footnote doesn't exists!");
        }

        [Test]
        public void TestAlterFootnoteWithExistingFootnote()
        {
            string bookName = "MyBook";
            string author = "Peter";
            Book myBook = new Book(bookName, author);
            myBook.AddFootnote(1, "MyFootnote");

            myBook.AlterFootnote(1, "MyEditedFootnote");

            string expected = "Footnote #1: MyEditedFootnote";
            string actual = myBook.FindFootnote(1);

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void TestAlterFootnoteWithNotExistingFootnote()
        {
            string bookName = "MyBook";
            string author = "Peter";
            Book myBook = new Book(bookName, author);
            myBook.AddFootnote(1, "MyFootnote");

            Assert.Throws<InvalidOperationException>(() =>
            {
                myBook.AlterFootnote(2, "MyEditedFootnote");

            }, "Footnote does not exists!");
        }
    }
}