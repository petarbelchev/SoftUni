using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int grams;
        private const int baseCaloriesPerGram = 2;
        private Dictionary<string, double> modifiers = new Dictionary<string, double>()
        {
            {"white", 1.5 },
            {"wholegrain", 1.0 },
            {"crispy", 0.9 },
            {"chewy", 1.1 },
            {"homemade", 1.0 }
        };
        public Dough(string flourType, string bakingTechnique, int grams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
        }

        public string FlourType 
        {
            get => this.flourType;
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                    throw new Exception("Invalid type of dough.");

                this.flourType = value;
            }
        }
        public string BakingTechnique 
        {
            get => this.bakingTechnique;
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                    throw new Exception("Invalid type of dough.");

                this.bakingTechnique = value;
            }
        }
        public int Grams 
        {
            get => this.grams;
            private set
            {
                if (value < 1 || value > 200)
                    throw new Exception("Dough weight should be in the range [1..200].");

                this.grams = value;
            }
        }

        public double GetCalories => (baseCaloriesPerGram * this.grams) * modifiers[this.flourType.ToLower()] * modifiers[this.bakingTechnique.ToLower()];
    }
}
