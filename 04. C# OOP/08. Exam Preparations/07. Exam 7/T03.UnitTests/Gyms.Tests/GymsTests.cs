using NUnit.Framework;
using System;
using System.Drawing;
using System.Xml.Linq;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [TestCase(null, 0)]
        [TestCase("", 0)]
        public void InvalidName(string name, int size)
        {
            Assert.That(() => 
            { 
                Gym gym = new Gym(name, size); 
            },Throws.ArgumentNullException, "Invalid gym name.");
        }

        [TestCase("Gym", -1)]
        [TestCase("Gym", -10)]
        public void InvalidCapacity(string name, int size)
        {
            Assert.That(() =>
            {
                Gym gym = new Gym(name, size);
            }, Throws.ArgumentException, "Invalid gym capacity.");
        }

        [TestCase("Gym", 0)]
        [TestCase("Gym", 10)]
        public void CtorShouldWorkCorectly(string name, int size)
        {
            Gym gym = new Gym(name, size);

            Assert.That(gym.Name, Is.EqualTo(name));
            Assert.That(gym.Capacity, Is.EqualTo(size));
            Assert.That(gym.Count, Is.EqualTo(0));
        }

        [TestCase("Gym", 1)]
        public void AddAthleteWithoutCapacityShouldThrow(string name, int size)
        {
            Gym gym = new Gym(name, size);
            gym.AddAthlete(new Athlete("Athlete1"));

            Assert.That(gym.Count, Is.EqualTo(1));

            Assert.That(() =>
            {
                gym.AddAthlete(new Athlete("Athlete2"));
            }, Throws.InvalidOperationException, "The gym is full.");
        }

        [TestCase("Gym", 1)]
        public void RemoveAthleteWhenDoesnExistShouldThrow(string name, int size)
        {
            Gym gym = new Gym(name, size);
            gym.AddAthlete(new Athlete("Athlete1"));

            Assert.That(() =>
            {
                gym.RemoveAthlete("Athlete2");
            }, Throws.InvalidOperationException,  "The athlete Athlete2 doesn't exist.");
        }

        [TestCase("Gym", 1)]
        public void RemoveAthleteWhenExist(string name, int size)
        {
            Gym gym = new Gym(name, size);
            gym.AddAthlete(new Athlete("Athlete1"));
            gym.RemoveAthlete("Athlete1");

            Assert.That(gym.Count, Is.EqualTo(0));
        }

        [TestCase("Gym", 1)]
        public void InjureAthleteWhenDoesnExistShouldThrow(string name, int size)
        {
            Gym gym = new Gym(name, size);
            gym.AddAthlete(new Athlete("Athlete1"));

            Assert.That(() =>
            {
                gym.InjureAthlete("Athlete2");
            }, Throws.InvalidOperationException, "The athlete Athlete2 doesn't exist.");
        }

        [TestCase("Gym", 1)]
        public void InjureAthleteWhenExist(string name, int size)
        {
            Gym gym = new Gym(name, size);
            gym.AddAthlete(new Athlete("Athlete1"));
            var injuredAthlete = gym.InjureAthlete("Athlete1");

            Assert.IsTrue(injuredAthlete.IsInjured);
        }

        [TestCase("Gym", 10)]
        public void TestReport(string name, int size)
        {
            Gym gym = new Gym(name, size);
            gym.AddAthlete(new Athlete("Athlete1"));
            gym.AddAthlete(new Athlete("Athlete2"));
            gym.AddAthlete(new Athlete("Athlete3"));

            gym.InjureAthlete("Athlete2");

            string expectedReport = "Active athletes at Gym: Athlete1, Athlete3";
            string actualReport = gym.Report();

            Assert.That(expectedReport, Is.EqualTo(actualReport));
        }
    }
}
