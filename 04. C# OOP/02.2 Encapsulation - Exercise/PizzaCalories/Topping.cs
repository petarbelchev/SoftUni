using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Topping
    {
        private string toppingType;
        private int grams;
        private int baseCalories = 2;
        private Dictionary<string, double> modifiers = new Dictionary<string, double>()
        {
            {"meat", 1.2 },
            {"veggies", 0.8 },
            {"cheese", 1.1 },
            {"sauce", 0.9 }
        };

        public Topping(string toppingType, int grams)
        {
            this.ToppingType = toppingType;
            this.Grams = grams;
        }

        public string ToppingType 
        {
            get => this.toppingType;
            set
            {
                string valueToLower = value.ToLower();
                if (modifiers.ContainsKey(valueToLower) == false)
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }

                this.toppingType = value;
            }
        }
        public int Grams 
        {
            get => this.grams;
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{this.toppingType} weight should be in the range [1..50].");
                }

                this.grams = value;
            }
        }

        public double GetCalories => baseCalories * this.grams * modifiers[this.toppingType.ToLower()];
    }
}
