using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main()
        {
            try
            {
                string pizzaName = Console.ReadLine().Split(' ')[1];

                var pizza = new Pizza(pizzaName);

                string[] doughData = Console.ReadLine().Split(' ');

                pizza.Dough = new Dough(doughData[1], doughData[2], int.Parse(doughData[3]));

                while (true)
                {
                    string cmd = Console.ReadLine();

                    if (cmd == "END") break;

                    string[] toppingData = cmd.Split(' ');

                    pizza.AddTopping(new Topping(toppingData[1], int.Parse(toppingData[2])));
                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetTotalCalories:f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
