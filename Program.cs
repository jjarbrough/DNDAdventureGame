using System.Runtime.Remoting;
using System.Security.Cryptography.X509Certificates;

namespace DnDAdventureGame
{
    internal class Program
    {
        public static List<Encounter> GetRandomEncounters(List<Encounter> mainListOfEncounters)
        {
            List<Encounter> temp = new List<Encounter>();
            for (int i = 0; i < mainListOfEncounters.Count; i++)
            {
                int num = Program.DieRoller(mainListOfEncounters.Count()) - 1;
                temp.Add(mainListOfEncounters[num]);
            }
            return temp;
        }

        public static List<Enemy> GetRandomEnemies(List<List<Enemy>> mainListOfEnemies)
        {
            List<Enemy> temp = new List<Enemy>();
            for (int i = 0; i < mainListOfEnemies.Count; i++)
            {
                int num = Program.DieRoller(mainListOfEnemies.Count()) - 1;
                temp = mainListOfEnemies[num];
            }
            return temp;
        }

        public static void Continue()
        {
            bool moveOn = false;
            while (!moveOn)
            {
                Console.WriteLine("Are you ready to continue? y/n");
                string response = Console.ReadLine();
                if (response.Equals("y"))
                {
                    moveOn = true;
                }
            }
        }
        public static int DieRoller(int number)
        {
            Random rnd = new Random();
            int num = rnd.Next(1, (number + 1));
            return num;
        }

        public static List<Encounter> makeFourEnvironmentsAndPopulate(BasicCharacter mainCharacter)
        {
            Goblin gobbo = new Goblin();
            Goblin gobbo1 = new Goblin();
            Goblin gobbo2 = new Goblin();
            Goblin gobbo3 = new Goblin();
            Goblin gobbo4 = new Goblin();
            Goblin gobbo5 = new Goblin();
            Goblin gobbo6 = new Goblin();
            Goblin gobbo7 = new Goblin();
            Goblin gobbo8 = new Goblin();
            Goblin gobbo9 = new Goblin();
            Bear bur = new Bear();
            Bear bur1 = new Bear();
            Bear bur2 = new Bear();
            List<Enemy> enemies = new List<Enemy>();
            enemies.Add(gobbo);
            enemies.Add(bur);
            enemies.Add(bur1);
            enemies.Add(gobbo1);
            List<Enemy> enemies2 = new List<Enemy>();
            enemies2.Add(gobbo2);
            enemies2.Add(gobbo3);
            enemies2.Add(gobbo4);
            enemies2.Add(gobbo5);
            enemies2.Add(gobbo6);
            enemies2.Add(gobbo7);
            List<Enemy> enemies3 = new List<Enemy>();
            enemies3.Add(bur2);
            enemies3.Add(gobbo8);
            enemies3.Add(gobbo9);
            List<Enemy> enemies4 = new List<Enemy>();
            List<List<Enemy>> masterMonsterList = new List<List<Enemy>>();
            masterMonsterList.Add(enemies);
            masterMonsterList.Add(enemies2);
            masterMonsterList.Add(enemies3);
            masterMonsterList.Add(enemies4);
            List<Encounter> temp = new List<Encounter>();
            Encounter cave = new Encounter()
            {
                difficultyToRun = 12,
                pC = mainCharacter,
                isNoticed = false,
                isTown = false,
                locationDescription = "Stepping into a cave, you leave behind the outside world's brightness and warmth. \nAs your eyes adjust to the dim light, the temperature drops, and you feel a cool, damp air brushing against your skin. \nThe ground beneath your feet becomes uneven, and the echo of your footsteps fills the enclosed space. \nThe scent of earth and minerals lingers in the air, and the mysterious darkness ahead beckons you to explore further.",
                fromAfar = "A large Cave mouth looming wide",
                enemies = GetRandomEnemies(masterMonsterList)
            };
            Encounter meadow = new Encounter()
            {
                difficultyToRun = 6,
                pC = mainCharacter,
                isNoticed = true,
                isTown = false,
                locationDescription = "Walking into a meadow, you step into a vast expanse of open space. \nSunlight bathes the area, warming your skin and brightening the surroundings. \nThe ground is covered with soft, knee-high grasses and wildflowers that sway gently in the breeze. \nThe air is filled with the scent of earth and blossoms. \nIn the distance, you might hear the chirping of birds or the buzzing of insects. \nIt's a peaceful and open landscape, inviting you to take in the natural beauty all around.",
                fromAfar = "A welcoming meadow, dotted with flowers and small plants",
                enemies = GetRandomEnemies(masterMonsterList)
            };
            Encounter field = new Encounter()
            {
                difficultyToRun = 12,
                pC = mainCharacter,
                isNoticed = true,
                isTown = false,
                locationDescription = "Walking into a field, you enter a spacious landscape with ground covered by short grasses and crops.\n Sunlight bathes the area, and the surroundings are open with a distant horizon or trees in the periphery. \nThe air carries the earthy scent of vegetation, and you can hear the rustling of leaves, \nthe chirping of birds, and the gentle swaying of plants in the wind.",
                fromAfar = "A field with rolling hills",
                enemies = GetRandomEnemies(masterMonsterList)
            };
            Encounter forest = new Encounter()
            {
                difficultyToRun = 12,
                pC = mainCharacter,
                isNoticed = true,
                isTown = false,
                locationDescription = "Walking into a forest, you step into a dense and verdant environment. \nThe ground is covered with fallen leaves, twigs, and soft soil. \nTall trees rise around you, their branches forming a natural canopy overhead, dimming the light. \nThe air is cool, and the scent of earth and moss surrounds you. \nThe forest is alive with the chirping of birds, rustling of small animals, and the occasional crackling of branches. \nIt's a serene and mysterious realm, inviting you to explore its depths.",
                fromAfar = "A field with rolling hills",
                enemies = GetRandomEnemies(masterMonsterList)
            };
            temp.Add(cave);
            temp.Add(meadow);
            temp.Add(field);
            temp.Add(forest);
            return temp;
        }
        static void Main(string[] args)
        {
            List<Encounter> mainListOfEncounters = new List<Encounter>();
            Encounter currentEncounter = new Encounter();
            Console.WriteLine(@"  _____        _____                _                 _                     _____                      ");
            Console.WriteLine(@" |  __ \      |  __ \      /\      | |               | |                   / ____|                     ");
            Console.WriteLine(@" | |  | |_ __ | |  | |    /  \   __| |_   _____ _ __ | |_ _   _ _ __ ___  | |  __  __ _ _ __ ___   ___ ");
            Console.WriteLine(@" | |  | | '_ \| |  | |   / /\ \ / _` \ \ / / _ \ '_ \| __| | | | '__/ _ \ | | |_ |/ _` | '_ ` _ \ / _ \");
            Console.WriteLine(@" | |__| | | | | |__| |  / ____ \ (_| |\ V /  __/ | | | |_| |_| | | |  __/ | |__| | (_| | | | | | |  __/");
            Console.WriteLine(@" |_____/|_| |_|_____/  /_/    \_\__,_| \_/ \___|_| |_|\__|\__,_|_|  \___|  \_____|\__,_|_| |_| |_|\___|");
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("In this game you will adventure through the wilderness collecting gold.");
            Console.WriteLine("As you adventure you will come across a wide variety of situations.");
            Console.WriteLine("You can retire anytime when in town and stop your adventure, but have you collected enough?");
            Console.WriteLine("Have you really fulfilled your ambitions yet?");
            Console.WriteLine("Only you can answer these questions while balancing peril and reward.");
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("You wake up, head throbbing, with no recollection of who, or where you are.");
            Console.WriteLine("Groggily you look around and see nothing but dense woods in your immediate surroundings.");
            Console.WriteLine("Something feels off, and as you rub your eyes and sit up, you realize that you're not in your own body");
            Console.WriteLine("Supressing your rising horror you examine this new form.  Looking down at yourself, what do you see?");
            Console.WriteLine("type h for Human Bard, d for dwarf Barbarian, e for Elf Rogue\nnote default is a human Bard");
            bool moveOn = false;
            BasicCharacter mainCharacter = new Human();
            while (!moveOn)
            {
                string response = Console.ReadLine();
                switch (response)
                {
                    case "h":
                        mainCharacter = new Human();
                        break;
                    case "d":
                        mainCharacter = new Dwarf();
                        break;
                    case "e":
                        mainCharacter = new Elf();
                        break;
                    default: 
                        Console.WriteLine("not an option so you are a human!");
                        mainCharacter = new Human();
                        break;
                }
                mainCharacter.CheckAttributes();
                Console.WriteLine("Would you like to continue? y/n");
                string response1 = Console.ReadLine();
                if (response1.Equals("y"))
                {
                    moveOn = true;
                }
                else
                {
                    Console.WriteLine("pick a different adventurer");
                }
            }
            Console.WriteLine("Some memory stirs in the back of your mind: a name, YOUR name");
            Console.WriteLine($"You let loose with a primal roar: {mainCharacter.name}, your name is {mainCharacter.name}.");
            Console.WriteLine("Quietly, after your outburst, you start taking stock of what you have; other that a ringing headache that is.");
            Console.WriteLine("You look down and see tattered clothes and thankfully a health potion in your pocket, nothing to tip you off though");
            Console.WriteLine("On the ground about ten feet away you see a backpack");

            //making the list of encounters

            mainListOfEncounters = makeFourEnvironmentsAndPopulate(mainCharacter);

            Console.WriteLine("Do you want to examine the bag? y/n");
            string userInput = Console.ReadLine();
            if (userInput.Equals("y"))
            {
                Console.WriteLine("examining the pack you find one health potion");
                Items healthPotion = new HealthPotion();
                mainCharacter.Inventory.Add(healthPotion);
                Thread.Sleep(1000);
                mainCharacter.CheckInventory();
            }
            Continue();
            Console.WriteLine($"By your feet you see a {mainCharacter.weapon}. Slowly you pick up the {mainCharacter.weapon}.");
            Console.WriteLine("Just in time! as you stand back up you hear a loud rustling in the branches to your left.");
            Thread.Sleep(5000);
            Console.WriteLine("Out pops a goblin!");
            Thread.Sleep(3000);
            Goblin firstEnemy = new Goblin();
            List<Enemy> enemies = new List<Enemy> { firstEnemy };
            Console.WriteLine("he attacks!");
            Combat firstCombat = new Combat(mainCharacter, enemies);
            if (mainCharacter is Human || mainCharacter is Dwarf)
            {
                firstCombat.EnemyAttackFirst();
            }
            else
            {
                firstCombat.YouhaveRangedWeapon();
            }
            Thread.Sleep(1000);
            Console.WriteLine("Whew that was a close one! Good thing it was just a goblin! A little loot never hurt anyone either!");
            Thread.Sleep(3000);
            Continue();
            Console.WriteLine("After this harrowing experience you take a better look around and you can see:");
            Thread.Sleep(3000);
            Console.WriteLine("Searching......");
            Thread.Sleep(5000);
            Console.WriteLine("After careful examination of your surroundings you see game trails leading, roughly, to the North, South, East and West.");
            currentEncounter = Encounter.ChooseDirection(mainListOfEncounters);
            while (!currentEncounter.isTown)
            {
                currentEncounter.doWhat();
                List<Encounter> possibleEnvironments = GetRandomEncounters(mainListOfEncounters);
                currentEncounter = Encounter.ChooseDirection(possibleEnvironments);
            }
        }
    }
}