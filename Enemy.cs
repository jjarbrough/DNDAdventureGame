using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    internal abstract class Enemy
    {
        public int conScore { get; set; }
        public int armorScore {  get; set; }
        public int gold { get; set; }
        public string weaponType { get; set; }
        public string name { get; set; }
        public int health { get; set; }
        public int damageDie { get; set; }
        public bool isAlive { get; set; }


        public void Damage(int damage)
        {
            health -= (damage - (armorScore / 4) - conScore);
            if (health <= 0)
            {
                isAlive = false;
            }
        }
        public bool checkAlive ()
        {
            if (health > 0)
            {
                return true;
            }
            else
            {
                isAlive = false;
                return false;
            }
        }
        public int Attack()
        {
            Random rnd = new Random();
            int damage = rnd.Next((1), (damageDie + 1));
            Console.WriteLine($"The {name} stabs with its {weaponType} for {damage} damage");
            return damage;
        }

    }
}
