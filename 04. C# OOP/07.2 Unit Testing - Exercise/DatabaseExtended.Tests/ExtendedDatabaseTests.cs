namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System.Text.Json;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void Initiate_With_More_Than_16_People_Should_Throw_An_Exception()
        {
            Person[] persons = new Person[17];
            for (int i = 0; i < persons.Length; i++)
                persons[i] = new Person(i + 1, $"p{i + 1}");

            Assert.That(() =>
            {
                Database database = new Database(persons);
            }, 
            Throws.ArgumentException);
        }

        [Test]
        public void Initiate_With_Lower_Than_16_People_Should_Not_Throw_An_Exception()
        {
            Person[] persons = new Person[15];
            for (int i = 0; i < persons.Length; i++)
                persons[i] = new Person(i + 1, $"p{i + 1}");
                Database database = new Database(persons);

            Assert.That(database.Count, Is.EqualTo(15));
        }

        [Test]
        public void Initiate_With_Empty_Ctor_And_Add_New_Person()
        {
            Database database = new Database();
            database.Add(new Person(1, "Name"));

            Assert.That(database.Count, Is.EqualTo(1));
        }

        [Test]
        public void Count_Property_Should_Return_Number_Of_Persons()
        {
            Person[] persons = new Person[3];
            for (int i = 0; i < persons.Length; i++)
                persons[i] = new Person(i + 1, $"p{i + 1}");
            Database database = new Database(persons);
            Assert.That(() => database.Count, Is.EqualTo(3));
        }

        [Test]
        public void Add_Person_With_Non_Unique_Name()
        {
            Person person = new Person(1, "Name");
            Database database = new Database(person);
            Assert.That(() => database.Add(new Person(2, "Name")), Throws.InvalidOperationException);
        }

        [Test]
        public void Add_Person_With_Non_Unique_Id()
        {
            Person person = new Person(1, "Name1");
            Database database = new Database(person);
            Assert.That(() => database.Add(new Person(1, "Name2")), Throws.InvalidOperationException);
        }

        [Test]
        public void Add_Person_With_Valid_Parameters()
        {
            Person person = new Person(1, "Name1");
            Database database = new Database(person);
            database.Add(new Person(2, "Name2"));
            Assert.That(database.Count, Is.EqualTo(2));
        }

        [Test]
        public void Add_Person_To_Full_Database()
        {
            Person[] persons = new Person[16];
            for (int i = 0; i < persons.Length; i++)
                persons[i] = new Person(i + 1, $"p{i + 1}");
            Database database = new Database(persons);
            Assert.That(() => database.Add(new Person(100, "Name2")), Throws.InvalidOperationException);
        }

        [Test]
        public void Remove_Person_From_Database_That_Have_Persons()
        {
            Person[] persons = new Person[3];
            for (int i = 0; i < persons.Length; i++)
                persons[i] = new Person(i + 1, $"p{i + 1}");
            Database database = new Database(persons);
            database.Remove();
            Assert.IsTrue(database.Count.Equals(2));
        }

        [Test]
        public void Remove_Person_From_Empty_Database()
        {
            Database database = new Database();
            Assert.That(() => database.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsername_With_Invalid_Username()
        {
            Person[] persons = new Person[3];
            for (int i = 0; i < persons.Length; i++)
                persons[i] = new Person(i + 1, $"p{i + 1}");
            Database database = new Database(persons);
            Assert.That(() => database.FindByUsername("Name"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsername_With_Valid_Username()
        {
            Person[] persons = new Person[3];
            for (int i = 0; i < persons.Length; i++)
                persons[i] = new Person(i + 1, $"p{i + 1}");
            Database database = new Database(persons);
            Person actual = database.FindByUsername("p2");
            Person expected = new Person(2, "p2");
            string jsonActual = JsonSerializer.Serialize(actual);
            string jsonExpected = JsonSerializer.Serialize(expected);
            Assert.That(jsonActual.Equals(jsonExpected));
        }

        [Test]
        public void FindByUsername_With_Empty_Username_Argument()
        {
            Person[] persons = new Person[3];
            for (int i = 0; i < persons.Length; i++)
                persons[i] = new Person(i + 1, $"p{i + 1}");
            Database database = new Database(persons);
            Assert.That(() => database.FindByUsername(""), Throws.ArgumentNullException);
        }

        [Test]
        public void FindByUsername_With_Null_Argument_When_Such_Person_Is_Not_Present()
        {
            Person[] persons = new Person[3];
            for (int i = 0; i < persons.Length; i++)
                persons[i] = new Person(i + 1, $"p{i + 1}");
            Database database = new Database(persons);
            Assert.That(() => database.FindByUsername(null), Throws.ArgumentNullException);
        }

        [Test]
        public void AddPersonWithNullNameParameter()
        {
            Assert.That(() =>
            {
                Database database = new Database(new Person(10, null));
            }, 
            Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsername_With_Invalid_CaseSensitive_Argument()
        {
            Person[] persons = new Person[3];
            for (int i = 0; i < persons.Length; i++)
                persons[i] = new Person(i + 1, $"p{i + 1}");
            Database database = new Database(persons);
            Assert.That(() => database.FindByUsername("P2"), Throws.InvalidOperationException);
        }        

        [Test]
        public void FindById_With_Negative_Id()
        {
            Person[] persons = new Person[3];
            for (int i = 0; i < persons.Length; i++)
                persons[i] = new Person(i + 1, $"p{i + 1}");
            Database database = new Database(persons);
            Assert.That(() => database.FindById(-1), Throws.Exception);
        }

        [Test]
        public void FindById_With_No_Present_Id()
        {
            Person[] persons = new Person[3];
            for (int i = 0; i < persons.Length; i++)
                persons[i] = new Person(i + 1, $"p{i + 1}");
            Database database = new Database(persons);
            Assert.That(() => database.FindById(100), Throws.InvalidOperationException);
        }

        [Test]
        public void FindById_With_Valid_Id()
        {
            Person[] persons = new Person[3];
            for (int i = 0; i < persons.Length; i++)
                persons[i] = new Person(i + 1, $"p{i + 1}");
            Database database = new Database(persons);
            Person actual = database.FindById(2);
            Person expected = new Person(2, "p2");
            string jsonActual = JsonSerializer.Serialize(actual);
            string jsonExpected = JsonSerializer.Serialize(expected);
            Assert.That(jsonActual.Equals(jsonExpected));
        }
    }
}