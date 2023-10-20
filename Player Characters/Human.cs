using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    public class Human : BasicCharacter
    {
        public Human()
        {
            armorScore = 0;
            gold = 15;
            isAlive = true;
            name = "Geoffrey";
            health = 60;
            maxHealth = 60;
            chaScore = 3;
            conScore = 1;
            dexScore = 1;
            strScore = 1;
            wisScore = 0;
            intScore = 2;
            Longsword longsword = new Longsword();
            weapon = longsword;
            Items healthPotion = new HealthPotion();
            Inventory.Add(healthPotion);
        }

        //attacking
        public override int Attack()
        {
            Random rnd = new Random();
            int damage = rnd.Next((1 + strScore), (weapon.weaponDie + strScore + 1));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You swing your {weapon.name} and do {damage} damage");
            Console.ForegroundColor = ConsoleColor.White;
            return damage;
        }

        //taking damage and checking if still alive
        public override void Damage(int damage)
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

        //check potions in inventory and heal if there are potions
        public override void Heal()
        {
            int numberOfHealthPotions = 0;
            foreach (Items thing in Inventory)
            {
                if (thing is HealthPotion)
                {
                    numberOfHealthPotions++;
                }

            }
            if (numberOfHealthPotions > 0)
            {
                foreach (Items things in Inventory)
                {
                    if (things is HealthPotion)
                    {
                        Inventory.Remove(things);
                        if (health + things.healthAmount >= 60)
                        {
                            health = 60;
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
    }
}
