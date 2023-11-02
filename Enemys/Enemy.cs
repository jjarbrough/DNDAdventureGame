using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    public class Enemy
    {
        public int idEnemies { get; set; }
        public int xp { get; set; }
        public int conScore { get; set; }
        public int gold { get; set; }
        public string weaponType { get; set; }
        public string name { get; set; }
        public int health { get; set; }
        public int damageDie { get; set; }
        public bool isAlive { get; set; }

        //taking damage and cheking if still alive
        public void Damage(int damage)
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

        //doing damage
        public int Attack()
        {
            Random rnd = new Random();
            int damage = rnd.Next((1), (damageDie + 1));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"The {name} swings with its {weaponType} for {damage} damage");
            Console.ForegroundColor = ConsoleColor.White;
            return damage;
        }

    }
}
