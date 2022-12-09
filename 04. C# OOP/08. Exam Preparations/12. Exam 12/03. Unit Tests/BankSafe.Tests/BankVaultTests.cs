using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        //[SetUp]
        //public void Setup()
        //{
        //    BankVault defBank = new BankVault();
        //}

        [Test]
        public void AddItemShouldThrowWhenCellDoesntExists()
        {
            BankVault defBank = new BankVault();
            Item item = new Item("Me", "Id");

            Assert.That(() =>
            {
                defBank.AddItem("E1", item);
            }, Throws.ArgumentException, "Cell doesn't exists!");
        }

        [Test]
        public void AddItemShouldThrowWhenCellIsTaken()
        {
            BankVault defBank = new BankVault();
            defBank.AddItem("A1", new Item("Me", "Id1"));
            Item item = new Item("Me", "Id2");

            Assert.That(() =>
            {
                defBank.AddItem("A1", item);
            }, Throws.ArgumentException, "Cell is already taken!");
        }

        [Test]
        public void AddItemShouldThrowWhenCellExists()
        {
            BankVault defBank = new BankVault();
            defBank.AddItem("A1", new Item("Me", "Id1"));
            Item item = new Item("Me", "Id1");

            Assert.That(() =>
            {
                defBank.AddItem("C1", item);
            }, Throws.InvalidOperationException, "Item is already in cell!");
        }

        [Test]
        public void RemoveItemShouldThrowWhenCellDoesntExists()
        {
            BankVault defBank = new BankVault();
            Item item = new Item("Me", "Id1");
            defBank.AddItem("A1", item);

            Assert.That(() =>
            {
                defBank.RemoveItem("E1", item);
            }, Throws.ArgumentException, "Cell doesn't exists!");
        }

        [Test]
        public void RemoveItemShouldThrowWhenItemIsNotTheSame()
        {
            BankVault defBank = new BankVault();
            Item item = new Item("Me", "Id1");
            defBank.AddItem("A1", item);

            Assert.That(() =>
            {
                defBank.RemoveItem("A1", new Item("Me", "Id2"));
            }, Throws.ArgumentException, "Item in that cell doesn't exists!");
        }

        [Test]
        public void RemoveItemShouldWorkCorrectly()
        {
            BankVault defBank = new BankVault();
            Item item = new Item("Me", "Id1");
            defBank.AddItem("A1", item);
            defBank.RemoveItem("A1", item);
            var cells = defBank.VaultCells;
            Assert.That(cells["A1"], Is.EqualTo(null));
        }
    }
}