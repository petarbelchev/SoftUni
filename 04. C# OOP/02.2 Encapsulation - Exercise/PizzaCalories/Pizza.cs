using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> topping;
        //private Dough dough;

        public Pizza(string name)
        {
            this.Name = name;
            this.topping = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public Dough Dough { get; set; }

        public int NumberOfToppings => this.topping.Count;

        public double GetTotalCalories => this.CalculateCalories();

        private double CalculateCalories()
        {
            if (NumberOfToppings > 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            double sumCalories = this.Dough.GetCalories;
            this.topping.ForEach(t => sumCalories += t.GetCalories);
            return sumCalories;
        }

        public void AddTopping(Topping topping)
        {
            this.topping.Add(topping);
        }
    }
}
