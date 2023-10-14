using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    internal class Human : BasicCharacter
    {
        public Human()
        {
            armorScore = 0;
            gold = 15;
            isAlive = true;
            name = "Geoffrey";
            health = 60;
            chaScore = 3;
            conScore = 1;
            dexScore = 0;
            strScore = 0;
            wisScore = 0;
            intScore = 3;
            weapon = "longsword";
            weaponDie = 10;
        }

        public override int Attack()
        {
            Random rnd = new Random();
            int damage = rnd.Next((1 + strScore), (weaponDie + strScore + 1));
            Console.WriteLine($"You swing your {weapon} and do {damage} damage");
            return damage;
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

        public override void Damage(int damage)
        {
            health -= (damage - (armorScore/4));
        }

        public override void Heal(int health)
        {
            throw new NotImplementedException();
        }
    }
}
