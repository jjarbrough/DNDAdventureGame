namespace DnDAdventureGame
{
    internal class Encounter
    {
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

        public bool doTown(BasicCharacter character)
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine($"you have {character.gold} gold");
            Console.WriteLine("press r for retire, s for shop, l for a long rest, or a to keep adventuring ");
            string input = Console.ReadLine();
            switch (input) 
            {
                case "r":
                    Program.EndGameScreen(character);
                    return false;
                case "l":
                    Console.WriteLine("You spend the night in an inn, this costs you 15 gold");
                    Console.WriteLine("You waken feeling refreshed, and your health has been returned to maximum");
                    character.health = character.maxHealth;
                    character.gold -= 15;
                    return false;
                case "a":
                    Console.WriteLine("Eager to get back to adventuring you head out of town");
                    Console.WriteLine("======================  in case a, returning true ++++++++++++++++++++++++");
                    return true;
                case "s":
                    Shop store = new Shop(character);
                    return false;
                default:
                    Console.WriteLine("not an option");
                    return false;
            };

        }

        public void doWhat()
        {
            bool correctInput = false;
            while (!correctInput)
            {
                Console.WriteLine($"{locationDescription}");
                Console.WriteLine($"you see {enemies.Count} enemies");
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("f for fight, r for run or u for use item");
                string input = Console.ReadLine();
                if (input.Equals("f"))
                {
                    Stay();
                    correctInput = true;
                }
                else if (input.Equals("r"))
                {
                    correctInput = true;
                    if (!TryRun())
                    {
                        Console.WriteLine("You tried to run but couldnt get away!");
                        Thread.Sleep(3000);
                        Stay();
                    }
                }
                else if (input.Equals("u"))
                {
                    correctInput = true;
                    UseItem();
                    Stay();
                }
                else
                {
                    Console.WriteLine("Not an option");
                }
            }
        }

        public void OutDescription()
        {
            Console.WriteLine($"{locationDescription}");
        }

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
        public void Stay() 
        {
            if (enemies.Count > 0)
            { 
                Combat newCombat = new Combat(pC, enemies);
                if (isNoticed)
                {

                    if (pC is Human || pC is Dwarf)
                    {
                        newCombat.EnemyAttackFirst();
                    }
                    else
                    {
                        newCombat.YouhaveRangedWeapon();
                    }
                }
                else
                {
                    if (pC is Human || pC is Dwarf)
                    {
                        newCombat.YouAttackFirst();
                    }
                    else
                    {
                        newCombat.YouhaveRangedWeapon();
                    }
                }
                SurvivedEncounter();
            }
        }
        public void UseItem()
        {
            pC.CheckInventory();
            bool finished = false;
            while (!finished)
            {
                Console.WriteLine("What would you like to use? Type h for health potion or e to exit");
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
        public void SurvivedEncounter()
        {
            Console.WriteLine("You take a deep breath and look around you, relishing the sweet taste of victory");
            Console.WriteLine("searching around the area you find:");
            if (loot.Count() == 0)
            {
                Console.WriteLine("Searching...");
                int num = Program.DieRoller(10001);
                Thread.Sleep(num);
                Console.WriteLine("Nothing...........absolutely nothing.");
            }
            else
            {
                foreach (var Items in loot)
                {
                    Console.WriteLine($"{Items.name}");
                    Thread.Sleep(2000);
                    pC.Inventory.Add(Items);
                }
                Console.WriteLine("You have added these items to your inventory");
            }
        }

        public static Encounter ChooseDirection(List<Encounter> directions)
        {
            bool correctFeedback = false;
            var currentEncounter = new Encounter();
            while (!correctFeedback)
            {
                Console.WriteLine($"To the North you see: {directions[0].fromAfar}");
                Console.WriteLine($"To the South lies: {directions[1].fromAfar}");
                Console.WriteLine($"East of you, you see:{directions[2].fromAfar}");
                Console.WriteLine($"Westways lies:{directions[3].fromAfar}");
                Console.WriteLine("Which general direction would you like to head?\nn/s/e/w");
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
