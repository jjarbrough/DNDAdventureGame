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
        public  Enemy badGuy { get; set; }
        public Combat(BasicCharacter bc, Enemy[] baddies) 
        {
            pC = bc;
            badGuy = baddies[0];
        }
        public void EnemyAttackFirst()
        {
            int sum = 0;
            while (pC.checkAlive() && badGuy.checkAlive())
            {
                int num = badGuy.Attack();
                Thread.Sleep(1000);
                pC.Damage(num);
                sum += num;
                if(!pC.checkAlive())
                {
                    Console.WriteLine("You are dead!");
                }
                int num2 = pC.Attack();
                Thread.Sleep(1000);
                badGuy.Damage(num2);
                if(!badGuy.checkAlive())
                {
                    Console.WriteLine($"You killed the {badGuy.name}!");
                    pC.gold += badGuy.gold;
                    Console.WriteLine($"You collect {badGuy.gold} gold off of the {badGuy.name}'s corpse");
                }
            }
            Console.WriteLine($"you won the fight but took {sum} damage");
        }

        public void YouAttackFirst()
        {
            int sum = 0;
            while (pC.checkAlive() && badGuy.checkAlive())
            {
                int num2 = pC.Attack();
                Thread.Sleep(1000);
                badGuy.Damage(num2);
                if (!badGuy.checkAlive())
                {
                    Console.WriteLine($"You killed the {badGuy.name}!");
                    pC.gold += badGuy.gold;
                    Console.WriteLine($"You collect {badGuy.gold} gold off of the {badGuy.name}'s corpse");
                    break;
                }
                int num = badGuy.Attack();
                Thread.Sleep(1000);
                pC.Damage(num);
                sum += num;
                if (!pC.checkAlive())
                {
                    Console.WriteLine("You are dead!");
                }
            }
            Console.WriteLine($"you won the fight but took {sum} damage");
        }
        public void YouhaveRangedWeapon()
        {
            Console.WriteLine("You have a ranged weapon so get a free attack");
            int num2 = pC.Attack();
            Thread.Sleep(1000);
            badGuy.Damage(num2);
            if (!badGuy.checkAlive())
            {
                Console.WriteLine($"You killed the {badGuy.name}!");
            }
            int sum = 0;
            while (pC.checkAlive() && badGuy.checkAlive())
            {
                int num3 = pC.Attack();
                Thread.Sleep(1000);
                badGuy.Damage(num3);
                if (!badGuy.checkAlive())
                {
                    Console.WriteLine($"You killed the {badGuy.name}!");
                    pC.gold += badGuy.gold;
                    Console.WriteLine($"You collect {badGuy.gold} gold off of the {badGuy.name}'s corpse");
                    break;
                }
                int num = badGuy.Attack();
                Thread.Sleep(1000);
                pC.Damage(num);
                sum += num;
                if (!pC.checkAlive())
                {
                    Console.WriteLine("You are dead!");
                }
            }
            Console.WriteLine($"you won the fight but took {sum} damage");
        }
    }
}
