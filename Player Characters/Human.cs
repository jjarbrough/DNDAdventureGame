using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    public class Human : BasicCharacter
    {
        public Human()
        {
            armorScore = 0;
            gold = 15;
            isAlive = true;
            name = "Geoffrey";
            health = 60;
            maxHealth = 60;
            chaScore = 3;
            conScore = 1;
            dexScore = 1;
            strScore = 1;
            wisScore = 0;
            intScore = 2;
            Longsword longsword = new Longsword();
            weapon = longsword;
            Items healthPotion = new HealthPotion();
            Inventory.Add(healthPotion);
            magicCharges = intScore;
        }
    }
}
