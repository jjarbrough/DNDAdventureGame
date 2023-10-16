using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    internal abstract class BasicCharacter
    {
        public bool hasPack { get; set; } = false;
        public int maxHealth {  get; set; } 

        public List<Items> Inventory = new List<Items>();   
        public int armorScore { get; set; }
        public int gold { get; set; }
        public int health { get; set; }
        public string name { get; set; }
        public int dexScore { get; set; } //bonus to running away at first(want to make it a bonus for dodge)
        public int strScore { get; set; } //bonus to damage (want to make damage bonus dependant on weapon type)
        public int chaScore { get; set; } //bonus to prices in town
        public int intScore { get; set; } //bonus to finding and disarming traps
        public int conScore { get; set; } //bonus to damage reduction and bonus to health
        public int wisScore { get; set; } //bonus to percieving things around you i:e hidden loot or surprises
        public bool isAlive { get; set; }
        public string weapon { get; set; }
        public int weaponDie { get; set; }


        //do damage
        public abstract int Attack();

        //take damage
        public abstract void Damage(int damage);

        //use health potion and heal
        public abstract void Heal();

        //see what you have in your inventory
        public virtual void CheckInventory()
        {
            Console.WriteLine("Your inventory contains:");
            foreach (Items packItems in Inventory)
            {
                Console.WriteLine($"{packItems.name}");
            }
            Console.WriteLine($"And you currently have {gold} gold");

        }

        //see what your attributes are
        public virtual void CheckAttributes()
        {
            Console.WriteLine($"Your strength score is: {strScore}. This increases your damage if you are a dwarf or human");
            Console.WriteLine($"Your intelligence score is: {intScore}. This increases the amount of valuable artefacts you can find on enemies");
            Console.WriteLine($"Your dexterity score is: {dexScore}. This increases the Elves damage as well as increasing your chances to get away");
            Console.WriteLine($"Your charisma score is: {chaScore}. This decreases the amount of gold upgrades cost in town");
            Console.WriteLine($"Your wisdom score is: {wisScore}. This increases your chances of finding treasures in the environment");
            Console.WriteLine($"Your constitution score is: {conScore}. This increases your health and damage resistance");
        }

        public virtual void AddToPack(Items item)
        {
            if (hasPack)
            {
                Console.WriteLine($"You add {item.name} to your pack");
                Inventory.Add(item);
            }
            else
            {
                Console.WriteLine("You have no where to put that");
            }
        }
    }
}
