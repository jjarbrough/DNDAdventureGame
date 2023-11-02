using System.Runtime.Remoting;
using System.Security.Cryptography.X509Certificates;
using System.Media;
using System.Numerics;
using DnDAdventureGame.Enemys;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace DnDAdventureGame
{
    public class Program
    {

        //End screen
        public static void EndGameScreen(BasicCharacter character, SoundPlayer player)
        {
            Console.WriteLine(@" __     ______  _    _    _____ _    _ _______      _________      ________ _____  _ _ ");
            Thread.Sleep(500);
            Console.WriteLine(@" \ \   / / __ \| |  | |  / ____| |  | |  __ \ \    / /_   _\ \    / /  ____|  __ \| | |");
            Thread.Sleep(500);
            Console.WriteLine(@"  \ \_/ / |  | | |  | | | (___ | |  | | |__) \ \  / /  | |  \ \  / /| |__  | |  | | | |");
            Thread.Sleep(500);
            Console.WriteLine(@"   \   /| |  | | |  | |  \___ \| |  | |  _  / \ \/ /   | |   \ \/ / |  __| | |  | | | |");
            Thread.Sleep(500);
            Console.WriteLine(@"    | | | |__| | |__| |  ____) | |__| | | \ \  \  /   _| |_   \  /  | |____| |__| |_|_|");
            Thread.Sleep(500);
            Console.WriteLine(@"    |_|  \____/ \____/  |_____/ \____/|_|  \_\  \/   |_____|   \/   |______|_____/(_|_)");
            Thread.Sleep(500);
            int option = character.gold;
            if (option < 0)
            {
                Console.WriteLine("You retire destitute owing money all over town. You die alone and friendless.");
            }
            else if (option >= 0 && option <50)
            {
                Console.WriteLine("You retire as a peasant. It's an honest living");
            }
            else if (option >= 50 && option < 100)
            {
                Console.WriteLine("While not poor by any means, you constantly think about your adventuring days and what could have been.");
            }
            else if (option >= 100 && option < 150)
            {
                Console.WriteLine("You use your money adventuring to buy inventory, become a merchant and retire comfortably");
            }
            else
            {
                player.SoundLocation = "466133__humanoide9000__victory-fanfare.wav";
                player.Load();
                player.PlayLooping();
                Console.WriteLine("You made your fortune adventuring, you have bought your way into nobility retiring as a pampered lord");
            }
            Thread.Sleep (15000);
            System.Environment.Exit(1);
        }


        //takes the encounter master list and returns a new random list of encounters
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


        //takes a list of monster lists randomly picks one then returns it
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


        //almost a pause on the dialogue, just to let them catch up
        public static void Continue()
        {
            bool moveOn = false;
            while (!moveOn)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Are you ready to continue? y/n");
                Console.ForegroundColor = ConsoleColor.White;
                string response = Console.ReadLine();
                if (response.Equals("y"))
                {
                    moveOn = true;
                }
            }
        }


        //random number generator
        public static int DieRoller(int number)
        {
            Random rnd = new Random();
            int num = rnd.Next(1, (number + 1));
            return num;
        }

        //random enemy populator returns a random list of enemies
        public static List<Enemy> EnemyPopulator(IEnumerable<Enemy> baseEnemyList)
        {
            List<Enemy> enemyList = new List<Enemy>();
            int count = (Program.DieRoller(5) - 1);
            for (int i = 0; i < count; i++)
            {
                int baddy = Program.DieRoller(5);
                if (baddy == 1)
                {
                    Enemy bear = new Enemy();
                    foreach (Enemy baddie in baseEnemyList)
                    {
                        if (baddie.idEnemies == 1)
                        {
                            bear = baddie;
                            bear.isAlive = true;
                        }
                    }
                    enemyList.Add(bear);
                }
                else if (baddy == 2)
                {
                    Enemy goblin = new Enemy();
                    foreach (Enemy baddie in baseEnemyList)
                    {
                        if (baddie.idEnemies == 2)
                        {
                            goblin = baddie;
                            goblin.isAlive = true;
                        }
                    }
                    enemyList.Add(goblin);
                }
                else if (baddy == 3)
                {
                    Enemy kobold = new Enemy();
                    foreach (Enemy baddie in baseEnemyList)
                    {
                        if (baddie.idEnemies == 3)
                        {
                            kobold = baddie;
                            kobold.isAlive = true;
                        }
                    }
                    enemyList.Add(kobold);
                }
                else if (baddy == 4)
                {
                    Enemy troll = new Enemy();
                    foreach (Enemy baddie in baseEnemyList)
                    {
                        if (baddie.idEnemies == 4)
                        {
                            troll = baddie;
                            troll.isAlive = true;
                        }
                    }
                    enemyList.Add(troll);
                }
            }
            return enemyList;
        }

        //populates a list with items randomly
        public static List<Items> ItemPopulator()
        {
            List<Items> itemList = new List<Items>();
            int count = DieRoller(10);
            if (count == 10)
            {
                HealthPotion healthPotion = new HealthPotion();
                itemList.Add(healthPotion);
            }
            else if (count == 9 || count == 8)
            { 
                SackOfGold sack = new SackOfGold();
                itemList.Add(sack);
            }
            else if (count == 7)
            {
                FiveSword sword = new FiveSword();
                itemList.Add(sword);
            }
            else if (count == 6)
            {
                Bow bow = new Bow();
                itemList.Add(bow);
            }
            else if (count == 5)
            {
                BattleAxe battle = new BattleAxe();
                itemList.Add(battle);
            }
            else if (count == 4)
            {
                Longsword longsword = new Longsword();
                itemList.Add(longsword);
            }
            return itemList;
        }

        //making the spotted by enemies a 50/50 chance
        public static bool isSpotted()
        {
            int count = DieRoller(2);
            if (count == 1) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //populating the lists
        public static List<Encounter> makeEnvironmentsAndPopulate(BasicCharacter mainCharacter, List<Enemy> enemyList)
        {
            List<List<Enemy>> masterMonsterList = new List<List<Enemy>>();
            for (int i = 0; i < 1000; i++)
            {
                List<Enemy> holder = Program.EnemyPopulator(enemyList);
                masterMonsterList.Add(holder);

            }
            Dragon dragon = new Dragon();
            List<Enemy> dragonList = new List<Enemy>();
            dragonList.Add(dragon);
            List<Encounter> temp = new List<Encounter>();
            Encounter cave = new Encounter()
            {
                soundEffects = "246230__andreangelo__squelchy-mouth-cave-hq.wav",
                loot = ItemPopulator(),
                difficultyToRun = 12,
                pC = mainCharacter,
                isNoticed = isSpotted(),
                isTown = false,
                locationDescription = "Stepping into a cave, you leave behind the outside world's brightness and warmth. \nAs your eyes adjust to the dim light, the temperature drops, and you feel a cool, damp air brushing against your skin. \nThe ground beneath your feet becomes uneven, and the echo of your footsteps fills the enclosed space. \nThe scent of earth and minerals lingers in the air, and the mysterious darkness ahead beckons you to explore further.",
                fromAfar = "A large Cave mouth looming wide",
                enemies = GetRandomEnemies(masterMonsterList)
            };
            Encounter meadow = new Encounter()
            {
                soundEffects = "378209__felixblume__the-sounds-of-the-meadow-gran-sabana-venezuela.wav",
                loot = ItemPopulator(),
                difficultyToRun = 6,
                pC = mainCharacter,
                isNoticed = isSpotted(),
                isTown = false,
                locationDescription = "Walking into a meadow, you step into a vast expanse of open space. \nSunlight bathes the area, warming your skin and brightening the surroundings. \nThe ground is covered with soft, knee-high grasses and wildflowers that sway gently in the breeze. \nThe air is filled with the scent of earth and blossoms. \nIn the distance, you might hear the chirping of birds or the buzzing of insects. \nIt's a peaceful and open landscape, inviting you to take in the natural beauty all around.",
                fromAfar = "A welcoming meadow, dotted with flowers and small plants",
                enemies = GetRandomEnemies(masterMonsterList)
            };
            Encounter field = new Encounter()
            { 
                soundEffects = "135472__kvgarlic__summeropenfielddusk.wav",
                loot = ItemPopulator(),
                difficultyToRun = 5,
                pC = mainCharacter,
                isNoticed = isSpotted(),
                isTown = false,
                locationDescription = "Walking into a field, you enter a spacious landscape with ground covered by short grasses and crops.\n Sunlight bathes the area, and the surroundings are open with a distant horizon or trees in the periphery. \nThe air carries the earthy scent of vegetation, and you can hear the rustling of leaves, \nthe chirping of birds, and the gentle swaying of plants in the wind.",
                fromAfar = "A field with rolling hills",
                enemies = GetRandomEnemies(masterMonsterList)
            };
            Encounter forest = new Encounter()
            {
                soundEffects = "531724__klankbeeld__forest-summer-roond-021-200619_0186.wav",
                loot = ItemPopulator(),
                difficultyToRun = 10,
                pC = mainCharacter,
                isNoticed = isSpotted(),
                isTown = false,
                locationDescription = "Walking into a forest, you step into a dense and verdant environment. \nThe ground is covered with fallen leaves, twigs, and soft soil. \nTall trees rise around you, their branches forming a natural canopy overhead, dimming the light. \nThe air is cool, and the scent of earth and moss surrounds you. \nThe forest is alive with the chirping of birds, rustling of small animals, and the occasional crackling of branches. \nIt's a serene and mysterious realm, inviting you to explore its depths.",
                fromAfar = "A Dense and gloomy forest",
                enemies = GetRandomEnemies(masterMonsterList)
            };
            Encounter town = new Encounter()
            {
                soundEffects = "423119__ogsoundfx__medieval-city-sample.wav",
                difficultyToRun = 12,
                pC = mainCharacter,
                isNoticed = false,
                isTown = true,
                locationDescription = "Walking into town narrow cobblestone streets wind between centuries-old stone buildings. \nOverhanging timber-framed houses line the lanes, and the air is filled with the scent of opportunity. \nThe town bustles with activity as villagers go about their daily routines. \nYou hear the clip-clop of horses' hooves, merchants haggling at market stalls, and the distant chime of a church bell.",
                fromAfar = "A town peeking over the hills in the distance",
                enemies = GetRandomEnemies(masterMonsterList)
            };
            Encounter bog = new Encounter()
            {   
                soundEffects = "399744__inspectorj__ambience-florida-frogs-gathering-a.wav",
                loot = ItemPopulator(),
                difficultyToRun = 15,
                pC = mainCharacter,
                isNoticed = isSpotted(),
                isTown = false,
                locationDescription = "As you step into the bog, the ground beneath your feet gives way, sinking into a squelchy, muddy morass. \nThe air is thick with a damp, earthy aroma, and the dense fog conceals much of the landscape. \nWaterlogged plants with twisted, moss-covered branches reach out from the murky waters, and the eerie chorus of croaking frogs and buzzing insects fills the air. \nYour every step is accompanied by a sucking sound as your boots struggle to break free from the mire, \nmaking each movement a slow and cautious endeavor in this eerie, desolate wetland.",
                fromAfar = "What appears to be wetlands covered in fog",
                enemies = GetRandomEnemies(masterMonsterList)
            };
            Encounter mountain = new Encounter()
            {
                soundEffects = "543449__kostas17__howling-wind.wav",
                loot = ItemPopulator(),
                difficultyToRun = 6,
                pC = mainCharacter,
                isNoticed = isSpotted(),
                isTown = false,
                locationDescription = "Walking up to a mountain is a gradual journey of ascending terrain. \nAs you approach the mountain, the landscape becomes steeper, and the air grows crisper. \nThe path typically leads through forests, meadows, or rocky trails, with each step offering a closer view of the majestic peak ahead. \nThe mountain looms larger and more imposing as you get nearer, and the anticipation of the climb ahead intensifies with each stride.",
                fromAfar = "majestic mountain peaks disappearing into the clouds",
                enemies = GetRandomEnemies(masterMonsterList)
            };
            Encounter river = new Encounter()
            {
                soundEffects = "584595__tosha73__mountain-river.wav",
                loot = ItemPopulator(),
                difficultyToRun = 6,
                pC = mainCharacter,
                isNoticed = isSpotted(),
                isTown = false,
                locationDescription = "Approaching a river, you see the glistening water ahead. \nThe gentle sound of flowing water fills the air, and the earthy scent of the surrounding nature surrounds you. \nYou walk toward the riverbank, feeling the cool breeze and the soft, uneven ground underfoot. \nThe lush greenery and wildlife along the river's edge add to the tranquil atmosphere, making it a serene and inviting spot.",
                fromAfar = "A river winding its way in the distance",
                enemies = GetRandomEnemies(masterMonsterList)
            };
            Encounter volcano = new Encounter()
            {
                art = @"
                 ___====-_  _-====___
           _--^^^#####//      \\#####^^^--_
        _-^##########// (    ) \\##########^-_
       -############//  |\^^/|  \\############-
     _/############//   (@::@)   \\############\_
    /#############((     \\//     ))#############\
   -###############\\    (oo)    //###############-
  -#################\\  / VV \  //#################-
 -###################\\/      \//###################-
_#/|##########/\######(   /\   )######/\##########|\#_
|/ |#/\#/\#/\/  \#/\##\  |  |  /##/\#/  \/\#/\#/\#| \|
`  |/  V  V  `   V  \#\| |  | |/#/  V   '  V  V  \|  '
   `   `  `      `   / | |  | | \   '      '  '   '
                    (  | |  | |  )
                   __\ | |  | | /__
                  (vvv(VVV)(VVV)vvv)",
                soundEffects = "415608__rtb45__mud-volcano-field-salton-sea.wav",
                loot = ItemPopulator(),
                difficultyToRun = 20,
                pC = mainCharacter,
                isNoticed = isSpotted(),
                isTown = false,
                locationDescription = "Approaching a volcano involves a noticeable shift in landscape and temperature, with the scent of sulfur in the air. \nThe terrain becomes rugged and barren, and you hear the sounds of volcanic activity. \nReaching the summit offers a view of the crater and its billowing smoke, a striking reminder of the Earth's power. \nAt the center of this volcano you see a dragon curled up on a hoard of gold",
                fromAfar = "A fiery volcano with a dragon circling overhead (WARNING: BOSS LEVEL)",
                enemies = dragonList
            };
            temp.Add(cave);
            temp.Add(meadow);
            temp.Add(field);
            temp.Add(forest);
            temp.Add(town);
            temp.Add(bog);
            temp.Add(mountain);
            temp.Add(river);
            temp.Add(volcano);
            return temp;
        }

        //Main running the program
        static void Main(string[] args)
        {

            //The database hookup
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperEnemyRepository(conn);
            var badguys = repo.GetEnemies().ToList();


            List<Encounter> mainListOfEncounters = new List<Encounter>();
            Encounter currentEncounter = new Encounter();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"  _____        _____                _                 _                     _____                      ");
            Console.WriteLine(@" |  __ \      |  __ \      /\      | |               | |                   / ____|                     ");
            Console.WriteLine(@" | |  | |_ __ | |  | |    /  \   __| |_   _____ _ __ | |_ _   _ _ __ ___  | |  __  __ _ _ __ ___   ___ ");
            Console.WriteLine(@" | |  | | '_ \| |  | |   / /\ \ / _` \ \ / / _ \ '_ \| __| | | | '__/ _ \ | | |_ |/ _` | '_ ` _ \ / _ \");
            Console.WriteLine(@" | |__| | | | | |__| |  / ____ \ (_| |\ V /  __/ | | | |_| |_| | | |  __/ | |__| | (_| | | | | | |  __/");
            Console.WriteLine(@" |_____/|_| |_|_____/  /_/    \_\__,_| \_/ \___|_| |_|\__|\__,_|_|  \___|  \_____|\__,_|_| |_| |_|\___|");
            Console.WriteLine("\n\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.White;

            //plays background music
            //if (OperatingSystem.IsWindows())
            //{
                SoundPlayer player = new SoundPlayer("676787__stevenmaertens__blinking-forest-acoustic.wav");
            //    player.Load();
            //   player.PlayLooping();
            //}


            Console.WriteLine("In this game you will adventure through the wilderness collecting gold.");
            Console.WriteLine("As you adventure you will come across a wide variety of situations.");
            Console.WriteLine("You can retire anytime when in town and stop your adventure, but have you collected enough?");
            Console.WriteLine("Have you really fulfilled your ambitions yet?");
            Console.WriteLine("Only you can answer these questions while balancing peril with reward.");
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("You wake up, head throbbing, with no recollection of who, or where you are.");
            Console.WriteLine("Groggily you look around and see nothing but dense woods in your immediate surroundings.");
            Console.WriteLine("Something feels off, and as you rub your eyes and sit up, you realize that you're not in your own body");
            Console.WriteLine("Supressing your rising horror you examine this new form.  Looking down at yourself, what do you see?");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("type h for Human Bard, d for dwarf Barbarian, e for Elf Rogue \nDefault is a human");
            Console.ForegroundColor = ConsoleColor.White;

            //character selection

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
                        Console.WriteLine("not an option! Default race is a human");
                        mainCharacter = new Human();
                        break;
                }
                mainCharacter.CheckAttributes();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Would you like to continue? y/n");
                Console.ForegroundColor = ConsoleColor.White;
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

            mainListOfEncounters = makeEnvironmentsAndPopulate(mainCharacter, badguys);

            //backpack and health potion

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Do you want to examine the bag? y/n");
            Console.ForegroundColor = ConsoleColor.White;
            string userInput = Console.ReadLine();
            if (userInput.Equals("y"))
            {
                Console.WriteLine("examining the pack you find one health potion");
                Console.WriteLine("You take the pack with you thinking it might be useful");
                mainCharacter.hasPack = true;
                Items healthPotion = new HealthPotion();
                mainCharacter.AddToPack(healthPotion, mainCharacter);
                Thread.Sleep(1000);
                mainCharacter.CheckInventory();
            }
            Continue();
            Console.WriteLine($"By your feet you see a {mainCharacter.weapon.name}. Slowly you pick up the {mainCharacter.weapon.name}.");
            Console.WriteLine("Just in time! as you stand back up you hear a loud rustling in the branches to your left.");

            //first combat

            Thread.Sleep(5000);
            Console.WriteLine("Out pops a goblin!");
            Thread.Sleep(3000);
            Enemy firstEnemy = new Enemy();
            for (int i = 0; i < badguys.Count; i++)
            {
                if (badguys[i].idEnemies == 2)
                {
                    firstEnemy = badguys[i];
                }
            }
            List<Enemy> enemies = new List<Enemy> { firstEnemy };
            Console.WriteLine("he attacks!");
            Combat firstCombat = new Combat(mainCharacter, enemies);
            if (mainCharacter is Human || mainCharacter is Dwarf)
            {
                firstCombat.EnemyAttackFirst(player);
            }
            else
            {
                firstCombat.YouhaveRangedWeapon(player);
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

            //Main Gameplay Loop

            currentEncounter = Encounter.ChooseDirection(mainListOfEncounters);
            while (true)
            {
                while (!currentEncounter.isTown)
                {      
                    //playing the sound effects for the environments
                        player.SoundLocation = currentEncounter.soundEffects;
                        //player.Load();
                        //player.PlayLooping();
                    
                    currentEncounter.doWhat(mainCharacter, player);
                    List<Encounter> possibleEnvironments = GetRandomEncounters(makeEnvironmentsAndPopulate(mainCharacter, badguys));
                    currentEncounter = Encounter.ChooseDirection(possibleEnvironments);
                }
                bool adventuring = false;
                while (!adventuring)
                {
                    player.SoundLocation = currentEncounter.soundEffects;
                    //player.Load();
                    //player.PlayLooping();
                    adventuring = currentEncounter.doTown(mainCharacter, player);
                }
                currentEncounter = Encounter.ChooseDirection(mainListOfEncounters);
            }
        }
    }
}