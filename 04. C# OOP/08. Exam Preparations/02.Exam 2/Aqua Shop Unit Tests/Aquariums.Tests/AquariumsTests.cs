namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    public class AquariumsTests
    {
        [Test]
        public void Constructor_Create_Aquarium_With_Valid_Parameteres()
        {
            string name = "MyAquarium";
            int capacity = 10;
            Aquarium aquarium = new Aquarium(name, capacity);
            Assert.AreEqual(aquarium.Name, name);
            Assert.AreEqual(aquarium.Capacity, capacity);
            Assert.AreEqual(aquarium.Count, 0);
        }

        [TestCase("", 10)]
        [TestCase(null, 10)]
        public void Invalid_Name_Parameter_Throws_Exception(string name, int capacity)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(name, capacity);
            }, "Invalid aquarium name!");
        }

        [TestCase("MyAquarium", -1)]
        public void Invalid_Capacity_Parameter_Throws_Exception(string name, int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium(name, capacity);
            }, "Invalid aquarium capacity!");
        }

        [Test]
        public void Add_Valid_Fish_To_Aquarium()
        {
            Fish fish = new Fish("MyFish");
            Aquarium aquarium = new Aquarium("MyAquarium", 10);
            aquarium.Add(fish);
            Assert.AreEqual(aquarium.Count, 1);
        }

        [Test]
        public void Try_To_Add_Fish_To_Full_Aquarium_Throws_Exception()
        {
            Fish firstFish = new Fish("FirstFish");
            Aquarium aquarium = new Aquarium("MyAquarium", 1);
            aquarium.Add(firstFish);
            Fish secondFish = new Fish("secondFish");

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(secondFish);
            }, "Aquarium is full!");
        }

        [Test]
        public void Try_To_Remove_Fish_That_Does_Not_Exist_Throws_Exception()
        {
            Fish firstFish = new Fish("FirstFish");
            Aquarium aquarium = new Aquarium("MyAquarium", 1);
            aquarium.Add(firstFish);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("secondFish");
            }, "Fish with the name secondFish doesn't exist!");
        }

        [Test]
        public void Remove_Fish_That_Exist()
        {
            Fish firstFish = new Fish("FirstFish");
            Aquarium aquarium = new Aquarium("MyAquarium", 1);
            aquarium.Add(firstFish);

            aquarium.RemoveFish("FirstFish");

            Assert.AreEqual(aquarium.Count, 0);
        }

        [Test]
        public void Try_To_Sell_Fish_That_Does_Not_Exist_Throws_Exception()
        {
            Fish firstFish = new Fish("FirstFish");
            Aquarium aquarium = new Aquarium("MyAquarium", 1);
            aquarium.Add(firstFish);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish("secondFish");
            }, "Fish with the name secondFish doesn't exist!");
        }

        [Test]
        public void Sell_Fish_That_Exist()
        {
            Fish firstFish = new Fish("FirstFish");
            Aquarium aquarium = new Aquarium("MyAquarium", 1);
            aquarium.Add(firstFish);

            var selledFish = aquarium.SellFish("FirstFish");

            Assert.AreEqual(selledFish.Name, "FirstFish");
        }

        [Test]
        public void Report_From_Empty_Aquarium()
        {
            Aquarium aquarium = new Aquarium("MyAquarium", 10);

            var actualReport = aquarium.Report();
            var expectedReport = "Fish available at MyAquarium: ";

            Assert.AreEqual(actualReport, expectedReport);
        }

        [Test]
        public void Report_From_Non_Empty_Aquarium()
        {
            Aquarium aquarium = new Aquarium("MyAquarium", 10);
            Fish firstFish = new Fish("FirstFish");
            Fish secondFish = new Fish("secondFish");
            aquarium.Add(firstFish);
            aquarium.Add(secondFish);

            var actualReport = aquarium.Report();
            var expectedReport = "Fish available at MyAquarium: FirstFish, secondFish";

            Assert.AreEqual(actualReport, expectedReport);
        }
    }
}
