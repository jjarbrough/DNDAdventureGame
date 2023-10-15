using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    internal class Shop
    {
        public static BasicCharacter character {  get; set; }
        public static List<Items> shopInventory = new List<Items>();

        public void atrributeIncrease(BasicCharacter character)
        {
            Console.WriteLine("Which stat would you like to boost?\n s for strength, i for intelligence, d for dexterity, c for constitution, w for wisdom, h for charisma");
            string input = Console.ReadLine();
            bool correctInput = false;
            while (!correctInput)
            {
                switch (input)
                {
                    case "s":
                        character.strScore++;
                        Console.WriteLine($"your strength is now {character.strScore}");
                        correctInput = true;
                        break;
                    case "i":
                        character.intScore++;
                        Console.WriteLine($"your intelligence is now {character.intScore}");
                        correctInput = true;
                        break;
                    case "d":
                        character.dexScore++;
                        Console.WriteLine($"your dexterity is now {character.dexScore}");
                        correctInput = true;
                        break;
                    case "c":
                        character.conScore++;
                        Console.WriteLine($"your constitution is now {character.conScore}");
                        correctInput = true;
                        break;
                    case "w":
                        character.wisScore++;
                        Console.WriteLine($"your wisdom is now {character.wisScore}");
                        correctInput = true;
                        break;
                    case "h":
                        character.chaScore++;
                        Console.WriteLine($"your charisma is now {character.chaScore}");
                        correctInput = true;
                        break;
                    default:
                        Console.WriteLine("not an available option");
                        break;
                }
            }
        }

        public Shop(BasicCharacter pC)
        {
            character = pC;
            Items healthPotion = new HealthPotion();
            Items statBoost = new StatBoost();
            shopInventory.Add(healthPotion);
            shopInventory.Add(statBoost);
            Console.WriteLine($"The shopkeeper has the following items for sale:");
            for (int i = 0; i < shopInventory.Count(); i++)
            {
                Console.WriteLine($"{shopInventory[i].name} for {shopInventory[i].goldAmount}");
            }
            bool finished = false;
            while (!finished)
                {
                Console.WriteLine("h for health potion, a for attribute boost, e to exit");
                string input = Console.ReadLine();
                    switch (input)
                    {
                        case "h":
                            character.Inventory.Add(healthPotion);
                            character.gold -= healthPotion.goldAmount;
                            break;
                        case "a":
                            atrributeIncrease(pC);
                            character.gold -= statBoost.goldAmount;
                            Console.WriteLine("You feel more powerful");
                            break;
                        case "e":
                            finished = true;
                        break;
                        default: 
                        Console.WriteLine("Thats not an option");
                        break;
                    };
             }  }
        }
    }

