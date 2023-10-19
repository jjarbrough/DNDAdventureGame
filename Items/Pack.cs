using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    public class Pack : Items
    {
        public override string name { get; set; }
        public override int healthAmount { get; set; }
        public override int goldAmount { get; set; }

        public Pack()
        {
            name = "Adventuring pack";
            goldAmount = 25; 
        }
    }
}
