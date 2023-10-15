using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    public abstract class Items
    {
        public abstract string name { get; set; }
        public abstract int healthAmount { get; set; }
    }
}
