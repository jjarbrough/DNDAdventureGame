using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    internal abstract class BasicCharacter
    {
        public int armorScore { get; set; }
        public int gold {  get; set; }
        public int health { get; set; }
        public string name { get; set; }
        public int dexScore { get; set; } //bonus to running away at first(want to make it a bonus for dodge)
        public int strScore { get; set; } //bonus to damage (want to make damage bonus dependant on weapon type)
        public int chaScore { get; set; } //bonus to prices in town
        public int intScore { get; set; } //bonus to finding goodies on baddies
        public int conScore { get; set; } //bonus to damage reduction and bonus to health
        public int wisScore { get; set; }
        public bool isAlive { get; set; }
        public string weapon { get; set; }
        public int weaponDie { get; set; }

        public abstract int Attack();
        public abstract void Damage(int damage);
        public abstract void Heal(int health);
        public abstract bool checkAlive();


    }
}
