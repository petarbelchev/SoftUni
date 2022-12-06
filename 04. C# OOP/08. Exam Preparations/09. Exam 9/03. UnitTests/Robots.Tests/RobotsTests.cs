namespace Robots.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void InvalidCapacityShouldThrowException()
        {
            Assert.That(() =>
            {
                RobotManager manager = new RobotManager(-1);
            }, Throws.ArgumentException, "Invalid capacity!");
        }

        [Test]
        public void CtorShouldWorkCorrectly()
        {
            RobotManager manager = new RobotManager(10);

            Assert.That(manager.Capacity, Is.EqualTo(10));
            Assert.That(manager.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddRobotWhenExistsShouldThrowException()
        {
            RobotManager manager = new RobotManager(10);
            manager.Add(new Robot("Robot1", 100));

            Assert.That(() =>
            {
                manager.Add(new Robot("Robot1", 100));
            }, Throws.InvalidOperationException, 
                "There is already a robot with name Robot1!");
        }

        [Test]
        public void AddRobotWhenNotEnoughCapacityShouldThrowException()
        {
            RobotManager manager = new RobotManager(1);
            manager.Add(new Robot("Robot1", 100));

            Assert.That(() =>
            {
                manager.Add(new Robot("Robot2", 90));
            }, Throws.InvalidOperationException,
                "Not enough capacity!");
        }

        [Test]
        public void RemoveRobotWhenRobotDoesntExistShouldThrowException()
        {
            RobotManager manager = new RobotManager(1);
            manager.Add(new Robot("Robot1", 100));

            Assert.That(() =>
            {
                manager.Remove("Robot2");
            }, Throws.InvalidOperationException,
                "Robot with the name Robot2 doesn't exist!");
        }

        [Test]
        public void RemoveRobotWhenRobotExistShouldWorkCorrectly()
        {
            RobotManager manager = new RobotManager(1);
            manager.Add(new Robot("Robot1", 100));
            manager.Remove("Robot1");

            Assert.That(manager.Count, Is.EqualTo(0));
        }

        [Test]
        public void WorkWhenRobotDoesntExistShouldThrowException()
        {
            RobotManager manager = new RobotManager(1);
            manager.Add(new Robot("Robot1", 100));

            Assert.That(() =>
            {
                manager.Work("Robot2", "Cleaner", 50);
            }, Throws.InvalidOperationException,
                "Robot with the name Robot2 doesn't exist!");
        }

        [Test]
        public void WorkWhenRobotDoesntHaveEnoughBatteryShouldThrowException()
        {
            RobotManager manager = new RobotManager(1);
            manager.Add(new Robot("Robot1", 50));

            Assert.That(() =>
            {
                manager.Work("Robot1", "Cleaner", 100);
            }, Throws.InvalidOperationException,
                "Robot1 doesn't have enough battery!");
        }

        [Test]
        public void WorkWhenRobotShouldWorkCorrectly()
        {
            RobotManager manager = new RobotManager(1);
            Robot robot = new Robot("Robot1", 100);
            manager.Add(robot);
            manager.Work("Robot1", "Cleaner", 50);

            Assert.That(robot.Battery, Is.EqualTo(100 - 50));
        }

        [Test]
        public void ChargeWhenRobotDoesntExistShouldThrowException()
        {
            RobotManager manager = new RobotManager(1);
            manager.Add(new Robot("Robot1", 100));

            Assert.That(() =>
            {
                manager.Charge("Robot2");
            }, Throws.InvalidOperationException,
                "Robot with the name Robot2 doesn't exist!");
        }

        [Test]
        public void ChargeRobotShouldWorkCorrectly()
        {
            RobotManager manager = new RobotManager(1);
            Robot robot = new Robot("Robot1", 100);
            manager.Add(robot);
            manager.Work("Robot1", "Clean", 50);

            Assert.That(robot.Battery, Is.EqualTo(100 - 50));

            manager.Charge("Robot1");

            Assert.That(robot.Battery, Is.EqualTo(100));
        }
    }
}
