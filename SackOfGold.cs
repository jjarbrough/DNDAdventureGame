using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    internal class SackOfGold : Items
    {
        public override string name { get; set; }
        public override int healthAmount { get ; set ; }
        public override int goldAmount { get; set ; }
        public SackOfGold() 
        {
            healthAmount = 0;
            int num =  Program.DieRoller(50);
            goldAmount = num;
            name = "Sack of gold";
        }

    }
}
