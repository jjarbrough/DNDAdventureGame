using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    internal class Combat
    {
        public BasicCharacter pC { get; set; }
        public List<Enemy> badGuys { get; set; }
        public Combat(BasicCharacter bc, List<Enemy> baddies)
        {
            pC = bc;
            badGuys = baddies;
        }
        public void EnemyAttackFirst()
        {
            int sum = 0;
            foreach (Enemy badGuy in badGuys)
            {
                while (pC.isAlive && badGuy.isAlive)
                {
                    int num = badGuy.Attack();
                    Thread.Sleep(2000);
                    pC.Damage(num);
                    sum += num;
                    if (!pC.isAlive)
                    {
                        DeathScreen.deathScreen();
                        break;
                    }
                    int num2 = pC.Attack();
                    Thread.Sleep(2000);
                    badGuy.Damage(num2);
                    if (!badGuy.isAlive)
                    {
                        Console.WriteLine($"You killed the {badGuy.name}!");
                        pC.gold += badGuy.gold;
                        Console.WriteLine($"You collect {badGuy.gold} gold off of the {badGuy.name}'s corpse");
                    }
                }
            }
            if (pC.isAlive)
            {
                Console.WriteLine($"You won the fight but took {sum} damage (reduced by your constitution score)");
                Console.WriteLine($"Your health is now {pC.health}");
            }
        }

        public void YouAttackFirst()
        {
            int sum = 0;
            foreach (Enemy badGuy in badGuys)
            {
                while (pC.isAlive && badGuy.isAlive)
                {
                    int num2 = pC.Attack();
                    Thread.Sleep(2000);
                    badGuy.Damage(num2);
                    if (!badGuy.isAlive)
                    {
                        Console.WriteLine($"You killed the {badGuy.name}!");
                        pC.gold += badGuy.gold;
                        Console.WriteLine($"You collect {badGuy.gold} gold off of the {badGuy.name}'s corpse");
                        break;
                    }
                    int num = badGuy.Attack();
                    Thread.Sleep(2000);
                    pC.Damage(num);
                    sum += num;
                    if (!pC.isAlive)
                    {
                        DeathScreen.deathScreen();
                        break;
                    }
                }
            }
            if (pC.isAlive)
            {
                Console.WriteLine($"you won the fight but took {sum} damage (reduced by your constitution score)");
                Console.WriteLine($"Your health is now {pC.health}");
            }
        }
        public void YouhaveRangedWeapon()
        {
            Console.WriteLine("You have a ranged weapon so get a free attack");
            int num2 = pC.Attack();
            Thread.Sleep(2000);
            badGuys[0].Damage(num2);
            if (!badGuys[0].isAlive)
            {
                Console.WriteLine($"You killed the {badGuys[0].name}!");
            }
            int sum = 0;
            foreach (Enemy badGuy in badGuys)
                while (pC.isAlive && badGuy.isAlive)
                {
                    int num3 = pC.Attack();
                    Thread.Sleep(2000);
                    badGuy.Damage(num3);
                    if (!badGuy.isAlive)
                    {
                        Console.WriteLine($"You killed the {badGuy.name}!");
                        pC.gold += badGuy.gold;
                        Console.WriteLine($"You collect {badGuy.gold} gold off of the {badGuy.name}'s corpse");
                        break;
                    }
                    int num = badGuy.Attack();
                    Thread.Sleep(2000);
                    pC.Damage(num);
                    sum += num;
                    if (!pC.isAlive)
                    {
                        DeathScreen.deathScreen();
                        break;
                    }
                }
        
            if (pC.isAlive)
            {
                Console.WriteLine($"you won the fight but took {sum} damage (reduced by your constitution score)");
                Console.WriteLine($"Your health is now {pC.health}");
            }
        }
    }
}
