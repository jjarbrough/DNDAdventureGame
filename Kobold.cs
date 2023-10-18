using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    public class Kobold : Enemy
    {
        public Kobold()
        {
            xp = 3;
            conScore = 1;
            Random rnd = new Random();
            gold = rnd.Next(1, 10);
            armorScore = 4;
            weaponType = "claws";
            name = "kobold";
            health = 5;
            damageDie = 4;
            isAlive = true;
        }
    }
}
