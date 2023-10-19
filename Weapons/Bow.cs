using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    internal class Bow : Weapons
    {
        public Bow() 
        {
            name = "bow";
            weaponDie = 8;
            goldAmount = 25;
        }
    }
}
