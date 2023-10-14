using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    internal class Elf : BasicCharacter
    {
        public Elf()
        {
            armorScore = 0;
            gold = 0;
            isAlive = true;
            name = "Imadril";
            health = 50;
            chaScore = 1;
            conScore = 0;
            dexScore = 3;
            strScore = 0;
            wisScore = 3;
            intScore = 0;
            weapon = "bow";
            weaponDie = 8;
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
            int damage = rnd.Next((1 + dexScore), (weaponDie + dexScore +1));
            Console.WriteLine($"You shoot your {weapon} and do {damage} damage");
            return damage;
        }

        public override void Damage(int damage)
        {
            health -= (damage - (armorScore / 4) - conScore);
        }

        public override void Heal(int health)
        {
            this.health += health;
        }
    }
}
