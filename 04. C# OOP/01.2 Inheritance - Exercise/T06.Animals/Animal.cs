using System;
using System.Text;

namespace T06.Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.Name), "Name can't be empty string!");
                }
                this.name = value;
            }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException(nameof(this.Name), "Age can't be negative or zero!");
                }
                this.age = value;
            }
        }
        public string Gender
        {
            get { return this.gender; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.Name), "Gender can't be negative or zero!");
                }
                this.gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine($"{this.ProduceSound()}");
            return sb.ToString().TrimEnd();
        }
    }
}
