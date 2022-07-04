using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();

            Dictionary<string, int> junkMaterials = new Dictionary<string, int>();

            while (true)
            {
                string[] quantityAndMaterials = Console.ReadLine()
                    .ToLower()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 1; i < quantityAndMaterials.Length; i += 2)
                {
                    int quantity = int.Parse(quantityAndMaterials[i - 1]);
                    string material = quantityAndMaterials[i];

                    if (IsLegendaryMaterial(material))
                    {
                        if (keyMaterials.ContainsKey(material))
                        {
                            keyMaterials[material] += quantity;
                        }
                        else
                        {
                            keyMaterials.Add(material, quantity);
                        }

                        if (keyMaterials[material] >= 250)
                        {
                            keyMaterials[material] -= 250;

                            string legendaryItem = GetTheLegendaryItem(material);

                            Console.WriteLine($"{legendaryItem} obtained!");

                            foreach (var item in keyMaterials)
                            {
                                Console.WriteLine($"{item.Key}: {item.Value}");
                            }

                            foreach (var item in junkMaterials)
                            {
                                Console.WriteLine($"{item.Key}: {item.Value}");
                            }

                            return;
                        }
                    }
                    else
                    {
                        if (junkMaterials.ContainsKey(material))
                        {
                            junkMaterials[material] += quantity;
                        }
                        else
                        {
                            junkMaterials.Add(material, quantity);
                        }
                    }
                }
            }
        }

        static bool IsLegendaryMaterial(string material)
        {
            if (material == "shards" || material == "motes" || material == "fragments")
            {
                return true;
            }

            return false;
        }

        static string GetTheLegendaryItem(string obtainedMaterial)
        {
            if (obtainedMaterial == "shards")
            {
                return "Shadowmourne";
            }
            else if (obtainedMaterial == "fragments")
            {
                return "Valanyr";
            }
            else if (obtainedMaterial == "motes")
            {
                return "Dragonwrath";
            }
            else
            {
                return null;
            }
        }
    }
}
