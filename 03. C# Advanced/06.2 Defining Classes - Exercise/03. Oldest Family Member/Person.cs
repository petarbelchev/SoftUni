﻿namespace _03._Oldest_Family_Member
{
    public class Person
    {
        private string name;
        private int age;

        public Person()
        {
            Name = "No name";
            Age = 1;
        }

        public Person(int age)
            : this()
        {
            Age = age;
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name 
        {
            get { return name; }
            set { name = value; }
        }

        public int Age 
        {
            get { return age; }
            set { age = value; }
        }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
