﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    public abstract class BasicCharacter
    {
        public int magicCharges { get; set; }
        public int level { get; set; } = 1;
        public int xp { get; set; }
        public bool hasPack { get; set; } = false;
        public int maxHealth { get; set; }

        public List<Weapons> weaponInventory = new List<Weapons>();

        public List<Items> Inventory = new List<Items>();
        public int armorScore { get; set; }
        public int gold { get; set; }
        public int health { get; set; }
        public string name { get; set; }
        public int dexScore { get; set; } //bonus to running away at first(want to make it a bonus for dodge)
        public int strScore { get; set; } //bonus to damage (want to make damage bonus dependant on weapon type)
        public int chaScore { get; set; } //bonus to prices in town
        public int intScore { get; set; } //bonus to finding and disarming traps
        public int conScore { get; set; } //bonus to damage reduction and bonus to health
        public int wisScore { get; set; } //bonus to percieving things around you i:e hidden loot or surprises
        public bool isAlive { get; set; }
        public Weapons weapon { get; set; }


        //do damage
        public virtual int Attack()
        {
            Random rnd = new Random();
            int damage = rnd.Next((1 + strScore), (weapon.weaponDie + strScore + 1));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You swing your {weapon.name} and do {damage} damage");
            Console.ForegroundColor = ConsoleColor.White;
            return damage;
        }

        //take damage
        public virtual void Damage(int damage)
        {
                int totalDamage = damage - conScore;
                if (totalDamage <= 0)
                {
                    totalDamage = 0;
                }
                else
                {
                    health -= totalDamage;
                }
                if (health <= 0)
                {
                    isAlive = false;
                }
        }

        //use health potion and heal
        public virtual void Heal()
        {
            //figure out number of health potions
            int numberOfHealthPotions = 0;
            foreach (Items thing in Inventory)
            {
                if (thing is HealthPotion)
                {
                    numberOfHealthPotions++;
                }

            }
            //implement heal if health potions > 0
            if (numberOfHealthPotions > 0)
            {
                foreach (Items things in Inventory)
                {
                    if (things is HealthPotion)
                    {
                        Inventory.Remove(things);
                        if (health + things.healthAmount >= 80)
                        {
                            health = 80;
                            break;
                        }
                        else
                        {
                            health += things.healthAmount;
                            break;
                        }

                    }

                }
            }
            else
            {
                Console.WriteLine("You can't heal, you don't have any health potions");
            }
            Console.WriteLine($"Your health is now {health}");
        }

        //see what you have in your inventory
        public virtual void CheckInventory()
        {
            Console.WriteLine("Your inventory contains:");
            foreach (Items packItems in Inventory)
            {
                Console.WriteLine($"{packItems.name}");
            }
            Console.WriteLine($"And you currently have {gold} gold");

        }

        //see what your attributes are
        public virtual void CheckAttributes()
        {
            Console.WriteLine($"Your strength score is: {strScore}. This increases your damage if you are a dwarf or human");
            Console.WriteLine($"Your intelligence score is: {intScore}. This increases the amount of valuable artefacts you can find on enemies");
            Console.WriteLine($"Your dexterity score is: {dexScore}. This increases the Elves damage as well as increasing your chances to get away and to dodge attacks");
            Console.WriteLine($"Your charisma score is: {chaScore}. This decreases the amount of gold upgrades cost in town");
            Console.WriteLine($"Your wisdom score is: {wisScore}. This increases your chances of finding treasures in the environment");
            Console.WriteLine($"Your constitution score is: {conScore}. This increases your health and damage resistance");
        }

        //add items to your pack
        public virtual void AddToPack(Items item, BasicCharacter character)
        {
            if (item is SackOfGold)
            {
                Console.WriteLine($"You found a pouch of gold containing {item.goldAmount} gold");
                character.gold += item.goldAmount;
                Console.WriteLine($"you now have {character.gold}");
            }
            if (hasPack)
            {
                Console.WriteLine($"You add {item.name} to your pack");
                Inventory.Add(item);
            }
            else
            {
                Console.WriteLine("You have no where to put that");
            }
        }

        public virtual void levelUp()
        {
            Console.WriteLine("With your current experience fighting monsters you become more effective! \nYou gain two attribute points of your choice.");
            for (int i = 0; i < 2; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Which stat would you like to boost?\n s for strength, i for intelligence, d for dexterity, c for constitution, w for wisdom, h for charisma");
                Console.ForegroundColor = ConsoleColor.White;
                string input = Console.ReadLine();
                bool correctInput = false;
                while (!correctInput)
                {
                    switch (input)
                    {
                        case "s":
                            strScore++;
                            Console.WriteLine($"your strength is now {strScore}");
                            correctInput = true;
                            break;
                        case "i":
                            intScore++;
                            Console.WriteLine($"your intelligence is now {intScore}");
                            correctInput = true;
                            break;
                        case "d":
                            dexScore++;
                            Console.WriteLine($"your dexterity is now {dexScore}");
                            correctInput = true;
                            break;
                        case "c":
                            conScore++;
                            Console.WriteLine($"your constitution is now {conScore}");
                            correctInput = true;
                            break;
                        case "w":
                            wisScore++;
                            Console.WriteLine($"your wisdom is now {wisScore}");
                            correctInput = true;
                            break;
                        case "h":
                            chaScore++;
                            Console.WriteLine($"your charisma is now {chaScore}");
                            correctInput = true;
                            break;
                        default:
                            Console.WriteLine("not an available option");
                            break;
                    }
                }
            }
        }
    }
}
