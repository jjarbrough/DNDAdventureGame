using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    public class Bear : Enemy
    {
        public Bear()
        {
            xp = 15;
            conScore = 2;
            Random rnd = new Random();
            gold = rnd.Next(10, 30);
            armorScore = 4;
            weaponType = "claws";
            name = "bear";
            health = 25;
            damageDie = 8;
            isAlive = true;
        }
    }
}
