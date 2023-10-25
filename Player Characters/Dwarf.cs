using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    public class Dwarf : BasicCharacter
    {
        public Dwarf()
        {
            armorScore = 4;
            gold = 0;
            isAlive = true;
            name = "Rangrim";
            health = 80;
            maxHealth = 80;
            chaScore = -1;
            conScore = 3;
            dexScore = -2;
            strScore = 3;
            wisScore = 2;
            intScore = 0;
            BattleAxe axe = new BattleAxe();
            weapon = axe;
            Items healthPotion = new HealthPotion();
            Inventory.Add(healthPotion);
            magicCharges = intScore;
        }
    }
}
