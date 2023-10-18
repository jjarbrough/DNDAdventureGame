﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    public class Combat
    {
        public BasicCharacter pC { get; set; }
        public List<Enemy> badGuys { get; set; }
        public Combat(BasicCharacter bc, List<Enemy> baddies)
        {
            pC = bc;
            badGuys = baddies;
        }

        //if surprised the enemy attacks first
        public void EnemyAttackFirst(SoundPlayer player)
        {
            player.SoundLocation = "Wounded (1).wav";
            player.Load();
            player.PlayLooping();
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
                        DeathScreen.deathScreen(player);
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
                        Console.WriteLine($"and {pC.intScore} gold in valuable materials (due to your intelligence)");
                        pC.gold += pC.intScore;
                        pC.xp += badGuy.xp;
                    }
                }
            }
            if (pC.isAlive)
            {
                player.SoundLocation = "676787__stevenmaertens__blinking-forest-acoustic.wav";
                player.Load();
                player.PlayLooping();
                Console.WriteLine($"You won the fight but took {sum} damage (reduced by your constitution score)");
                Console.WriteLine($"Your health is now {pC.health}");
                if (pC.xp >= 75)
                {
                    Console.WriteLine("You have gained enough experience to level up!");
                    pC.xp = pC.xp % 75;
                    pC.levelUp();
                }
            }
        }

        //if you surprise the enemy you attack first
        public void YouAttackFirst(SoundPlayer player)
        {
            player.SoundLocation = "Wounded (1).wav";
            player.Load();
            player.PlayLooping();
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
                        Console.WriteLine($"and {pC.intScore} gold in valuable materials (due to your intelligence)");
                        pC.gold += pC.intScore;
                        pC.xp += badGuy.xp;
                        break;
                    }
                    int num = badGuy.Attack();
                    Thread.Sleep(2000);
                    pC.Damage(num);
                    sum += num;
                    if (!pC.isAlive)
                    {
                        DeathScreen.deathScreen(player);
                        break;
                    }
                }
            }
            if (pC.isAlive)
            {
                player.SoundLocation = "676787__stevenmaertens__blinking-forest-acoustic.wav";
                player.Load();
                player.PlayLooping();
                Console.WriteLine($"you won the fight but took {sum} damage (reduced by your constitution score)");
                Console.WriteLine($"Your health is now {pC.health}");
                if (pC.xp >= 75)
                {
                    Console.WriteLine("You have gained enough experience to level up!");
                    pC.xp = pC.xp % 75;
                    pC.levelUp();
                }
            }
        }

        //If you have a ranged weapon you get a bonus attack first as they close the distance
        public void YouhaveRangedWeapon(SoundPlayer player)
        {
            player.SoundLocation = "Wounded (1).wav";
            player.Load();
            player.PlayLooping();
            Console.WriteLine("You have a ranged weapon so get a free attack");
            int num2 = pC.Attack();
            Thread.Sleep(2000);
            badGuys[0].Damage(num2);
            if (!badGuys[0].isAlive)
            {
                Console.WriteLine($"You killed the {badGuys[0].name}!");
                pC.gold += badGuys[0].gold;
                Console.WriteLine($"You collect {badGuys[0].gold} gold off of the {badGuys[0].name}'s corpse");
                Console.WriteLine($"and {pC.intScore} gold in valuable materials (due to your intelligence)");
                pC.gold += pC.intScore;
                pC.xp += badGuys[0].xp;
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
                        pC.xp += badGuy.xp;
                        break;
                    }
                    int num = badGuy.Attack();
                    Thread.Sleep(2000);
                    pC.Damage(num);
                    sum += num;
                    if (!pC.isAlive)
                    {
                        DeathScreen.deathScreen(player);
                        break;
                    }
                }
        
            if (pC.isAlive)
            {
                player.SoundLocation = "676787__stevenmaertens__blinking-forest-acoustic.wav";
                player.Load();
                player.PlayLooping();
                Console.WriteLine($"you won the fight but took {sum} damage (reduced by your constitution score)");
                Console.WriteLine($"Your health is now {pC.health}");
                if (pC.xp >= 75)
                {
                    Console.WriteLine("You have gained enough experience to level up!");
                    pC.xp = pC.xp % 75;
                    pC.levelUp();
                }
            }
        }
    }
}
