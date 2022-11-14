using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(999)]
        public void TestConstructorWithValidParams(int capacity)
        {
            Shop shop = new Shop(capacity);
            Assert.AreEqual(shop.Capacity, capacity);
            Assert.AreEqual(shop.Count, 0);
        }

        [TestCase(-1)]
        [TestCase(-5)]
        [TestCase(-999)]
        public void TestConstructorWithInvalidParams(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(capacity);
            }, "Invalid capacity.");
        }

        [Test]
        public void Test_AddExistPhone()
        {
            Shop shop = new Shop(5);
            Smartphone smartPhone = new Smartphone("myPhone", 100);
            shop.Add(smartPhone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smartPhone);
            }, $"The phone model myPhone already exist.");
        }

        [Test]
        public void Test_AddPhoneToFullShop()
        {
            Shop shop = new Shop(1);
            shop.Add(new Smartphone("phone1", 100));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("phone2", 100));
            }, "The shop is full.");
        }

        [Test]
        public void Test_AddPhoneToShop()
        {
            Shop shop = new Shop(1);
            shop.Add(new Smartphone("phone1", 100));

            Assert.AreEqual(shop.Count, 1);
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("phone3")]
        public void Test_RemoveDoesntExistPhone(string phoneName)
        {
            Smartphone smartPhone = new Smartphone("phone1", 100);
            Smartphone smartPhone2 = new Smartphone("phone2", 110);
            Shop shop = new Shop(3);
            shop.Add(smartPhone);
            shop.Add(smartPhone2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove(phoneName);
            }, "The phone model phone1 doesn't exist.");
        }

        [Test]
        public void Test_RemovePhone()
        {
            Smartphone smartPhone = new Smartphone("phone1", 100);
            Smartphone smartPhone2 = new Smartphone("phone2", 110);
            Shop shop = new Shop(3);
            shop.Add(smartPhone);
            shop.Add(smartPhone2);
            shop.Remove("phone1");

            Assert.AreEqual(shop.Count, 1);
        }

        [Test]
        public void Test_TestPhoneWhenPhoneDoesntExist()
        {
            Shop shop = new Shop(1);
            shop.Add(new Smartphone("myPhone", 100));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("phone1", 20);
            }, "The phone model phone1 doesn't exist.");
        }

        [Test]
        public void Test_TestPhoneWhenPhoneBatteryUsageIsBigger()
        {
            Shop shop = new Shop(1);
            Smartphone smartPhone = new Smartphone("phone1", 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("phone1", 110);
            }, "The phone model phone1 is low on batery.");
        }

        [Test]
        public void Test_TestPhoneWhenPhoneBatteryUsageIsLower()
        {
            Shop shop = new Shop(1);
            Smartphone smartPhone = new Smartphone("phone1", 100);
            shop.Add(smartPhone);
            shop.TestPhone("phone1", 30);

            Assert.AreEqual(smartPhone.CurrentBateryCharge, smartPhone.MaximumBatteryCharge - 30);
        }

        [Test]
        public void Test_TestPhoneWhenPhoneBatteryUsageIsEqual()
        {
            Shop shop = new Shop(1);
            Smartphone smartPhone = new Smartphone("phone1", 100);
            shop.Add(smartPhone);
            shop.TestPhone("phone1", 100);

            Assert.AreEqual(smartPhone.CurrentBateryCharge, smartPhone.MaximumBatteryCharge - 100);
        }

        [TestCase("")]
        [TestCase("phone1")]
        [TestCase(null)]
        public void Test_ChargePhoneWhenPhoneDoesntExist(string phoneName)
        {
            Shop shop = new Shop(1);
            shop.Add(new Smartphone("phone2", 100));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone(phoneName);
            }, $"The phone model {phoneName} doesn't exist.");
        }

        [TestCase("phone1", 100)]
        [TestCase("phone2", 30)]
        [TestCase("phone3", 40)]
        public void Test_ChargePhone(string phoneName, int maximumBatteryCharge)
        {
            Shop shop = new Shop(1);
            Smartphone smartPhone = new Smartphone(phoneName, maximumBatteryCharge);
            shop.Add(smartPhone);
            shop.TestPhone(phoneName, 30);

            Assert.AreEqual(smartPhone.CurrentBateryCharge, smartPhone.MaximumBatteryCharge - 30);

            shop.ChargePhone(phoneName);

            Assert.AreEqual(smartPhone.CurrentBateryCharge, smartPhone.MaximumBatteryCharge);
        }
    }
}