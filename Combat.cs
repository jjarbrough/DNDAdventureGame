using System;
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
                    if (TryHit())
                    {
                        int num = badGuy.Attack();
                        Thread.Sleep(2000);
                        pC.Damage(num);
                        sum += num;
                    }
                    else
                    {
                        Console.WriteLine("You dodged the attack!");
                        Thread.Sleep(2000);
                    }
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
                //sets the enemy back to alive for next time
                badGuy.isAlive = true;
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
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You have gained enough experience to level up!");
                    pC.xp = pC.xp % 75;
                    pC.levelUp();
                    pC.level++;
                    Console.WriteLine($"You are now Level {pC.level}");
                    Console.ForegroundColor = ConsoleColor.White;
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
                    if (TryHit())
                    {
                        int num = badGuy.Attack();
                        Thread.Sleep(2000);
                        pC.Damage(num);
                        sum += num;
                    }
                    else
                    {
                        Console.WriteLine("You dodged the attack!");
                        Thread.Sleep(2000);
                    }
                    if (!pC.isAlive)
                    {
                        DeathScreen.deathScreen(player);
                        break;
                    }
                }
                //sets the enemy back to alive for next time
                badGuy.isAlive = true;
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
                    pC.level++;
                    pC.magicCharges = pC.intScore;
                    Console.WriteLine($"You are now Level {pC.level}");
                }
            }
        }

        //If you have a ranged weapon you get a bonus attack first as they close the distance
        public void YouhaveRangedWeapon(SoundPlayer player)
        {
            player.SoundLocation = "Wounded (1).wav";
            player.Load();
            player.PlayLooping();
            Console.WriteLine("You are an elf so you get a free attack");
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
                try
                {
                    badGuys[1].isAlive = true;
                }
                catch (Exception ex)
                {
                    //if the list of enemies only has one enemy catches the exception
                }
            }
                int sum = 0;
                foreach (Enemy badGuy in badGuys)
                {
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
                            badGuy.isAlive = true;
                            break;
                        }
                        if (TryHit())
                        {
                            int num = badGuy.Attack();
                            Thread.Sleep(2000);
                            pC.Damage(num);
                            sum += num;
                        }
                        else
                        {
                            Console.WriteLine("You dodged the attack!");
                            Thread.Sleep(2000);
                        }
                        if (!pC.isAlive)
                        {
                            DeathScreen.deathScreen(player);
                            break;
                        }
                    }
                    //sets the enemy back to alive for next time
                    badGuy.isAlive = true;
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
                        pC.level++;
                        Console.WriteLine($"You are now Level {pC.level}");
                    }
                }
        }
        

            //checks to see if an enemies attack hits
            public bool TryHit()
            {
                if (pC.dexScore + Program.DieRoller(20) > 15)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
    }
}
