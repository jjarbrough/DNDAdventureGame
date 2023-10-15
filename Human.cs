using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    internal class Human : BasicCharacter
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
            dexScore = 0;
            strScore = 0;
            wisScore = 0;
            intScore = 3;
            weapon = "longsword";
            weaponDie = 10;
            Items healthPotion = new HealthPotion();
            Inventory.Add(healthPotion);
        }

        //attacking
        public override int Attack()
        {
            Random rnd = new Random();
            int damage = rnd.Next((1 + strScore), (weaponDie + strScore + 1));
            Console.WriteLine($"You swing your {weapon} and do {damage} damage");
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
            foreach (HealthPotion thing in Inventory)
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
