using System.Media;

namespace DnDAdventureGame
{
    public class Encounter
    {
        public string soundEffects { get; set; } = "";
        public bool isNoticed {  get; set; }
        public BasicCharacter pC {  get; set; }
        public int difficultyToRun { get; set; }
        public bool isTown { get; set; }

        public List<Enemy> enemies = new List<Enemy>();

        public List<BasicCharacter> friends = new List<BasicCharacter>();

        public List<Items> loot = new List<Items>();
        public string fromAfar { get; set; }
        public string locationDescription { get; set; }

        public Encounter()
        {

        }
        public Encounter (BasicCharacter playerCharacter)
        {
            pC = playerCharacter;
        }
        public Encounter(List<BasicCharacter> friendlies, List<Enemy> baddies, BasicCharacter pC)
        {
            enemies = baddies;
            friends = friendlies;
            this.pC = pC;
        }

        //the loop of options while in town
        public bool doTown(BasicCharacter character, SoundPlayer player)
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine($"you have {character.gold} gold");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("press r for retire, s for shop, l for a long rest, or a to keep adventuring ");
            Console.ForegroundColor = ConsoleColor.White;
            string input = Console.ReadLine();
            switch (input) 
            {
                case "r":
                    Program.EndGameScreen(character, player);
                    return false;
                case "l":
                    Console.WriteLine("You spend the night in an inn, this costs you 15 gold");
                    Console.WriteLine("You waken feeling refreshed, and your health has been returned to maximum");
                    character.health = character.maxHealth;
                    character.gold -= 15;
                    return false;
                case "a":
                    Console.WriteLine("Eager to get back to adventuring you head out of town");
                    return true;
                case "s":
                    Shop store = new Shop(character);
                    return false;
                default:
                    Console.WriteLine("not an option");
                    return false;
            };

        }

        //loop of options while adventuring
        public void doWhat(BasicCharacter character, SoundPlayer player)
        {
            bool correctInput = false;
            while (!correctInput)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{locationDescription}");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(10000);
                Console.WriteLine($"you see:");
                if(enemies.Count == 0)
                {
                    Console.WriteLine("no enemies in your current vicinity");

                    Thread.Sleep(3000);
                }
                if (enemies.Count() >0 && !enemies[0].isAlive)
                {
                    Console.WriteLine("You see the following corpses strewn around");
                    foreach (Enemy badguy in enemies)
                    {
                        Console.WriteLine($"{badguy.name}");
                    }
                }
                else
                {
                    foreach (Enemy enemy in enemies)
                    {
                        Console.WriteLine($"{enemy.name}");
                        Thread.Sleep(1000);
                    }
                }
                if (!isNoticed)
                {
                    Console.WriteLine("You havent been spotted.... yet.");
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine("A sudden Noise gives you away, drawing the attention of anyone in the vicinity");
                    Thread.Sleep(1000);
                }
                Console.WriteLine("What do you want to do?");
                if (enemies.Count() > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("f for fight, r for run or u for use item");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("f for forage, r for run or u for use item");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                string input = Console.ReadLine();
                if (input.Equals("f"))
                {
                    Stay(character, player);
                    correctInput = true;
                }
                else if (input.Equals("r"))
                {
                    correctInput = true;
                    if (!TryRun())
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You tried to run but couldnt get away!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(3000);
                        Stay(character, player);
                    }
                }
                else if (input.Equals("u"))
                {
                    correctInput = true;
                    UseItem();
                    Stay(character, player);
                }
                else
                {
                    Console.WriteLine("Not an option");
                }
            }
        }

        //checking to see if you got away
        public bool TryRun()
        {
            if (pC.dexScore + Program.DieRoller(20) >= difficultyToRun)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //if you stay and fight
        public void Stay(BasicCharacter character, SoundPlayer player) 
        {
            if (enemies.Count > 0)
            { 
                Combat newCombat = new Combat(pC, enemies);
                if (isNoticed)
                {

                    if (pC is Human || pC is Dwarf)
                    {
                        newCombat.EnemyAttackFirst(player);
                    }
                    else
                    {
                        newCombat.YouhaveRangedWeapon(player);
                    }
                }
                else
                {
                    if (pC is Human || pC is Dwarf)
                    {
                        newCombat.YouAttackFirst(player);
                    }
                    else
                    {
                        newCombat.YouhaveRangedWeapon(player);
                    }
                }
                SurvivedEncounter(character);
            }
            else
            {
                SurvivedEncounter(character);
            }
        }

        //if you use an item
        public void UseItem()
        {
            pC.CheckInventory();
            bool finished = false;
            while (!finished)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("What would you like to use? Type h for health potion or e to exit");
                Console.ForegroundColor = ConsoleColor.White;
                string holder = Console.ReadLine();
                if (holder.Equals("h"))
                {
                    pC.Heal();
                }
                else if (holder.Equals("e"))
                {
                    finished = true;
                }
                else
                {
                    Console.WriteLine("Thats not an option");
                }
            }
        }
        //when you survive an encounter
        public void SurvivedEncounter(BasicCharacter character)
        {
            Console.WriteLine("You take a deep breath and look around you, relishing the sweet taste of victory");
            Console.WriteLine("searching around the area you find:");
            if (loot.Count() == 0)
            {
                Console.WriteLine("Searching...");
                int num = Program.DieRoller(10000);
                Thread.Sleep(num);
                Console.WriteLine("Nothing...........absolutely nothing.");
                Thread.Sleep(5000);
            }
            else
            {
                foreach (var items in loot)
                {
                    Console.WriteLine($"{items.name}");
                    Thread.Sleep(2000);
                    if (items is FiveSword)
                    {
                        Console.WriteLine("Finding this magical sword you immediately equip it");
                        character.AddToPack(character.weapon, character);
                        character.weapon = new FiveSword();
                        character.Inventory.Remove(items);
                    }
                    pC.AddToPack(items, character);
                    if (items is FiveSword && (!(character.weapon is FiveSword)))
                    {
                        character.Inventory.Remove(items);
                    }
                }
                Console.WriteLine("You have added these items to your inventory");
            }
        }

        //finding which direction you want to go
        public static Encounter ChooseDirection(List<Encounter> directions)
        {
            bool correctFeedback = false;
            var currentEncounter = new Encounter();
            while (!correctFeedback)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"To the North you see: {directions[0].fromAfar}");
                Console.WriteLine($"To the South lies: {directions[1].fromAfar}");
                Console.WriteLine($"East of you, you see:{directions[2].fromAfar}");
                Console.WriteLine($"Westways lies:{directions[3].fromAfar}");
                Console.WriteLine("Which general direction would you like to head?\nn/s/e/w");
                Console.ForegroundColor = ConsoleColor.White;
                string input = Console.ReadLine();
                if (input.Equals("n"))
                {
                    currentEncounter = directions[0];
                    correctFeedback = true;
                }
                else if (input.Equals("s"))
                {
                    currentEncounter = directions[1];
                    correctFeedback = true;
                }
                else if (input.Equals("e"))
                {
                    currentEncounter = directions[2];
                    correctFeedback = true;
                }
                else if (input.Equals("w"))
                {
                    currentEncounter = directions[3];
                    correctFeedback = true;
                }
                else
                {
                    Console.WriteLine("Thats not an option");
                }
            }
            return currentEncounter;
        }
    }
}
