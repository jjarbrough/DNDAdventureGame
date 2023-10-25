using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    public class Elf : BasicCharacter
    {
        public Elf()
        {
            armorScore = 0;
            gold = 0;
            isAlive = true;
            name = "Imadril";
            health = 50;
            maxHealth = 50;
            chaScore = 1;
            conScore = 0;
            dexScore = 3;
            strScore = 0;
            wisScore = 3;
            intScore = 0;
            Bow bow = new Bow();
            weapon = bow;
            Items healthPotion = new HealthPotion();
            Inventory.Add(healthPotion);
            magicCharges = intScore;
        }

        //Do damage
        public override int Attack()
        {
            Random rnd = new Random();
            int damage = rnd.Next((1 + dexScore), (weapon.weaponDie + dexScore + 1));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You attack with your {weapon.name} and do {damage} damage");
            Console.ForegroundColor = ConsoleColor.White;
            return damage;
        }
    }
}
