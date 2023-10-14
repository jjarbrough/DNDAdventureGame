using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    internal class Goblin : Enemy
    {
        public Goblin()
        {
            armorScore = 0;
            Random rnd = new Random();
            gold = rnd.Next(1,16);
            name = "Goblin"; 
            health = 20;
            damageDie = 4;
            isDead = false;
            weaponType = "knife";
        }
        public bool checkAlive()
        {
            if (health > 0)
            {
                return true;
            }
            else
            {
                isDead = true;
                return false;
            }
        }
    }
}
