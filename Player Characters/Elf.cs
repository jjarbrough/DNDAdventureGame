using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    public class Elf : BasicCharacter
    {
        public Elf()
        {
            armorScore = 0;
            gold = 0;
            isAlive = true;
            name = "Imadril";
            health = 50;
            maxHealth = 50;
            chaScore = 1;
            conScore = 0;
            dexScore = 3;
            strScore = 0;
            wisScore = 3;
            intScore = 0;
            Bow bow = new Bow();
            weapon = bow;
            Items healthPotion = new HealthPotion();
            Inventory.Add(healthPotion);
        }

        //Do damage
        public override int Attack()
        {
            Random rnd = new Random();
            int damage = rnd.Next((1 + dexScore), (weapon.weaponDie + dexScore + 1));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You attack with your {weapon.name} and do {damage} damage");
            Console.ForegroundColor = ConsoleColor.White;
            return damage;
        }

        //take damage and check if still alive
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

        //use health potin and heal
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
                        if (health + things.healthAmount >= 50)
                        {
                            health = 50;
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
