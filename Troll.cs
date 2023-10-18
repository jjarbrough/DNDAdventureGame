using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    public class Troll : Enemy
    {
        public Troll()
        {
            xp = 25;
            conScore = 1;
            Random rnd = new Random();
            gold = rnd.Next(25, 50);
            armorScore = 4;
            weaponType = "club";
            name = "troll";
            health = 35;
            damageDie = 12;
            isAlive = true;
        }
    }
}
