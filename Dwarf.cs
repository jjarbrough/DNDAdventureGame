using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    internal class Dwarf : BasicCharacter
    {
        public Dwarf()
        {
            armorScore = 0;
            gold = 50;
            isAlive = true;
            name = "Rangrim";
            health = 80;
            chaScore = -1;
            conScore = 3;
            dexScore = 0;
            strScore = 3;
            wisScore = 2;
            intScore = 0;
            weapon = "BattleAxe";
            weaponDie = 12;
        }

        public override bool checkAlive()
        {
            if (health > 0)
            {
                return true;
            }
            else
            {
                isAlive = false;
                return false;
            }
        }

        public override int Attack()
        {
            Random rnd = new Random();
            int damage = rnd.Next((1 + strScore), (weaponDie + strScore + 1));
            Console.WriteLine($"You swing your {weapon} and do {damage} damage");
            return damage;
        }

        public override void Damage(int damage)
        {
            health -= (damage - (armorScore / 4) - conScore);
            if (health <= 0)
            {
                isAlive = false;
            }
        }

        public override void Heal(int health)
        {
            this.health += health;
        }
    }
}
