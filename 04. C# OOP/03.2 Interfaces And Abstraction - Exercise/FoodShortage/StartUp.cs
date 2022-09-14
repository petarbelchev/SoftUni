using System;
using System.Collections.Generic;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main()
        {
            List<IBuyer> people = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (personData.Length == 4)
                {
                    var citizen = new Citizen(personData[0], int.Parse(personData[1]), personData[2], personData[3]);
                    people.Add(citizen);
                }
                else if (personData.Length == 3)
                {
                    var rebel = new Rebel(personData[0], int.Parse(personData[1]), personData[2]);
                    people.Add(rebel);
                }
            }

            while (true)
            {
                string buyerOfFood = Console.ReadLine();

                if (buyerOfFood == "End") break;

                IBuyer person = people.Find(p => p.Name == buyerOfFood);
                
                if (person != null) person.BuyFood();
            }

            int totalAmountOfFood = 0;

            people.ForEach(p => totalAmountOfFood += p.Food);

            Console.WriteLine(totalAmountOfFood);
        }
    }
}
