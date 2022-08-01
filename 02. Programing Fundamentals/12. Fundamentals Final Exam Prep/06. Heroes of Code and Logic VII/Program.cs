using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int numOfHeroes = int.Parse(Console.ReadLine());
        var heroes = new Dictionary<string, Hero>();
        for (int i = 0; i < numOfHeroes; i++)
        {
            string[] heroesData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = heroesData[0];
            int health = int.Parse(heroesData[1]);
            if (health > 100)
                health = 100;
            int mana = int.Parse(heroesData[2]);
            if (mana > 200)
                mana = 200;
            heroes[name] = new Hero(health, mana);
        }
        string cmd;
        while ((cmd = Console.ReadLine()) != "End")
        {
            string[] cmdArgs = cmd.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
            string heroName = cmdArgs[1];
            if (cmdArgs[0] == "CastSpell")
            {
                int manaNeeded = int.Parse(cmdArgs[2]);
                string spellName = cmdArgs[3];
                if (heroes[heroName].Mana >= manaNeeded)
                {
                    heroes[heroName].Mana -= manaNeeded;
                    Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName].Mana} MP!");
                }
                else
                    Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
            }
            else if (cmdArgs[0] == "TakeDamage")
            {
                int damage = int.Parse(cmdArgs[2]);
                string attacker = cmdArgs[3];
                heroes[heroName].Health -= damage;
                if (heroes[heroName].Health > 0)
                {
                    Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName].Health} HP left!");
                }
                else
                {
                    heroes.Remove(heroName);
                    Console.WriteLine($"{heroName} has been killed by {attacker}!");
                }
            }
            else if (cmdArgs[0] == "Recharge")
            {
                int amount = int.Parse(cmdArgs[2]);
                int manaBefore = heroes[heroName].Mana;
                heroes[heroName].Mana += amount;
                if (heroes[heroName].Mana > 200)
                    heroes[heroName].Mana = 200;
                Console.WriteLine($"{heroName} recharged for {heroes[heroName].Mana - manaBefore} MP!");
            }
            else if (cmdArgs[0] == "Heal")
            {
                int amount = int.Parse(cmdArgs[2]);
                int healthBefore = heroes[heroName].Health;
                heroes[heroName].Health += amount;
                if (heroes[heroName].Health > 100)
                    heroes[heroName].Health = 100;
                Console.WriteLine($"{heroName} healed for {heroes[heroName].Health - healthBefore} HP!");
            }
        }
        foreach (var hero in heroes)
        {
            Console.WriteLine($"{hero.Key}");
            Console.WriteLine($"  HP: {hero.Value.Health}");
            Console.WriteLine($"  MP: {hero.Value.Mana}");
        }
    }
}

class Hero
{
    public Hero(int health, int mana)
    {
        Health = health;
        Mana = mana;
    }
    public int Health { get; set; }
    public int Mana { get; set; }
}
