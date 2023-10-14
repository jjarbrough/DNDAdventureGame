using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    internal class Bear : Enemy
    {
        public Bear()
        {
            Random rnd = new Random();
            gold = rnd.Next(1, 5);
            armorScore = 4;
            weaponType = "claws";
            name = "bear";
            health = 75;
            damageDie = 8;
            isAlive = true;
        }
    }
}
