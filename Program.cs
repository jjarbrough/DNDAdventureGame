﻿namespace DnDAdventureGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"  _____        _____                _                 _                     _____                      ");
            Console.WriteLine(@" |  __ \      |  __ \      /\      | |               | |                   / ____|                     ");
            Console.WriteLine(@" | |  | |_ __ | |  | |    /  \   __| |_   _____ _ __ | |_ _   _ _ __ ___  | |  __  __ _ _ __ ___   ___ ");
            Console.WriteLine(@" | |  | | '_ \| |  | |   / /\ \ / _` \ \ / / _ \ '_ \| __| | | | '__/ _ \ | | |_ |/ _` | '_ ` _ \ / _ \");
            Console.WriteLine(@" | |__| | | | | |__| |  / ____ \ (_| |\ V /  __/ | | | |_| |_| | | |  __/ | |__| | (_| | | | | | |  __/");
            Console.WriteLine(@" |_____/|_| |_|_____/  /_/    \_\__,_| \_/ \___|_| |_|\__|\__,_|_|  \___|  \_____|\__,_|_| |_| |_|\___|");
            Console.WriteLine("\n\n\n\n\n\n\n");
            Console.WriteLine("You wake up, head throbbing, with no recollection of who, or where you are.");
            Console.WriteLine("Groggily you look around and see nothing but dense woods in your immediate surroundings.");
            Console.WriteLine("Looking down you see an unfamiliar body. What do you see?");
            Console.WriteLine("type a for Human, b for dwarf, c for Elf \nnote default is a human");
            string response = Console.ReadLine();
            BasicCharacter mainCharacter;
            switch (response)
            {
                case "a":
                    mainCharacter = new Human();
                    break;
                case "b":
                    mainCharacter = new Dwarf();
                    break;
                case "c":
                    mainCharacter = new Elf();
                    break;
                default: 
                    Console.WriteLine("not an option so you are a human!");
                    mainCharacter = new Human();
                    break;
            }
            Console.WriteLine("Some memory stirs in the back of your mind: a name, YOUR name");
            Console.WriteLine($"You let loose with a priaml roar: {mainCharacter.name}, your name is {mainCharacter.name}.");
            Console.WriteLine("Quietly you start taking stock of what you have, other that a ringing headache that is.");
            Console.WriteLine($"By your feet you see a {mainCharacter.weapon}. Slowly you pick up the {mainCharacter.weapon}.");
            Console.WriteLine("Just in time! as you stand back up you hear a loud rustling in the branches to your left.");
           // Thread.Sleep(15000);
            Console.WriteLine("Out pops a goblin!");
            Goblin firstEnemy = new Goblin();
            Console.WriteLine("he attacks!");
            Combat firstCombat = new Combat(mainCharacter, firstEnemy);
            if (mainCharacter is Human || mainCharacter is Dwarf)
            {
                firstCombat.EnemyAttackFirst();
            }
            else
            {
                firstCombat.YouhaveRangedWeapon();
            }

        }
    }
}