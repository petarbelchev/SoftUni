using System;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);
            if (result == 0) 
                return this.Age.CompareTo(other.Age);
            return result;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Age.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Person otherPerson = obj as Person;
            if (otherPerson == null) 
                return false;
            return this.Name == otherPerson.Name && this.Age == otherPerson.Age;
        }
    }
}
