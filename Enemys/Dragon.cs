using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DnDAdventureGame.Enemys
{
    internal class Dragon : Enemy
    {
        public Dragon() 
        {
            xp = 75;
            conScore = 3;
            gold = 500;
            armorScore = 4;
            weaponType = "claws";
            name = "Dragon";
            health = 125;
            damageDie = 12;
            isAlive = true;
        }
    }
}
