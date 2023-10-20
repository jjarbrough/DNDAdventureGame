using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    public class Dwarf : BasicCharacter
    {
        public Dwarf()
        {
            armorScore = 4;
            gold = 0;
            isAlive = true;
            name = "Rangrim";
            health = 80;
            maxHealth = 80;
            chaScore = -1;
            conScore = 3;
            dexScore = -2;
            strScore = 3;
            wisScore = 2;
            intScore = 0;
            BattleAxe axe = new BattleAxe();
            weapon = axe;
            Items healthPotion = new HealthPotion();
            Inventory.Add(healthPotion);
            magicCharges = intScore;
        }

        //do damage 

        public override int Attack()
        {
            Random rnd = new Random();
            int damage = rnd.Next((1 + strScore), (weapon.weaponDie + strScore + 1));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You swing your {weapon.name} and do {damage} damage");
            Console.ForegroundColor = ConsoleColor.White;
            return damage;
        }

        //take damage and check if alive
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

        //use health potion and heal
        public override void Heal()
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
    }
}
