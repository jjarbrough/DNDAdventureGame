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
            conScore = 0;
            armorScore = 0;
            Random rnd = new Random();
            gold = rnd.Next(1,16);
            name = "Goblin"; 
            health = 10;
            damageDie = 4;
            isAlive = true;
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
                isAlive = false;
                return false;
            }
        }
    }
}
