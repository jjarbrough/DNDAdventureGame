using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    public class StatBoost : Items
    {
        public override string name { get; set ; }
        public override int healthAmount { get; set; }
        public override int goldAmount { get; set; }

        public StatBoost()
        {
            name = "+1 to an attribute of your choice";
            healthAmount = 0;
            goldAmount = 100;
        }
    }

}
