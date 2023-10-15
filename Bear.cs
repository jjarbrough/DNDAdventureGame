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
            conScore = 3;
            Random rnd = new Random();
            gold = rnd.Next(1, 5);
            armorScore = 4;
            weaponType = "claws";
            name = "bear";
            health = 25;
            damageDie = 8;
            isAlive = true;
        }
    }
}
