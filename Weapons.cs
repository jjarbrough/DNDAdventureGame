using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    public class Weapons : Items
    {
        public override string name { get; set; }
        public override int healthAmount { get ; set; }
        public override int goldAmount { get; set; }
        public int weaponDie { get; set; }
    }
}
