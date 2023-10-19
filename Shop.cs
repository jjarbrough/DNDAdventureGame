using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    public class Shop
    {
        public static BasicCharacter character {  get; set; }
        public static List<Items> shopInventory = new List<Items>();

        //selection statement for if they choose a stat boost
        public void atrributeIncrease(BasicCharacter character)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Which stat would you like to boost?\n s for strength, i for intelligence, d for dexterity, c for constitution, w for wisdom, h for charisma");
            Console.ForegroundColor = ConsoleColor.White;
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

        //shop options and purchasing
        public Shop(BasicCharacter pC)
        {
            character = pC;
            Items healthPotion = new HealthPotion();
            Items statBoost = new StatBoost();
            Items pack = new Pack();
            shopInventory.Add(healthPotion);
            shopInventory.Add(statBoost);
            shopInventory.Add(pack);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("As you push open the creaking wooden door, a gust of cool, musty air greets you. \nThe dimly lit interior of the shop is filled with an array of curious and rustic items. \nWooden shelves groan under the weight of handcrafted leather goods, pottery, and pewter mugs. \nThe flickering glow of oil lamps casts dancing shadows on the rough-hewn stone walls. \nThe shopkeeper stands behind a weathered oak counter, ready to assist you with a warm, welcoming smile. \nThe faint scent of herbs and spices wafts from a corner, where dried herbs hang from the ceiling");
            pC.CheckInventory();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"The shopkeeper has the following items for sale:");
            for (int i = 0; i < shopInventory.Count(); i++)
            {
                Console.WriteLine($"{shopInventory[i].name} for ({2 * (shopInventory[i].goldAmount - (character.chaScore * 3))})");
            }
            bool finished = false;
            while (!finished)
                {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("h for health potion, a for attribute boost, b for back pack, s to sell, e to exit");
                Console.ForegroundColor = ConsoleColor.White;
                string input = Console.ReadLine();
                    switch (input)
                    {
                        case "h":
                        if (character.gold >= healthPotion.goldAmount)
                        {
                            character.AddToPack(healthPotion, pC);
                            character.gold -= (healthPotion.goldAmount - (character.chaScore * 3) * 2);
                        }
                        else
                        {
                            Console.WriteLine("you can't afford this");
                        }
                            break;
                        case "a":
                        if (character.gold >= statBoost.goldAmount)
                        {
                            atrributeIncrease(pC);
                            character.gold -= (statBoost.goldAmount - (character.chaScore * 3) * 2);
                            Console.WriteLine("You feel more powerful");
                        }
                        else
                        {
                            Console.WriteLine("you can't afford this");
                        }
                            break;
                        case "b":
                        if (character.gold >= pack.goldAmount)
                        {
                            character.gold -= (pack.goldAmount - (character.chaScore * 3) * 2);
                            Console.WriteLine("You now have a pack to hold items you find");
                            character.hasPack = true;
                        }
                        else
                        {
                            Console.WriteLine("you can't afford this");
                        }
                        break;
                        case "s":
                        for(int i = (pC.Inventory.Count()-1); i >= 0; i--)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"Do you want to sell {pC.Inventory[i].name} for {(pC.Inventory[i].goldAmount + (3*character.chaScore))} gold? yes/no");
                            Console.ForegroundColor = ConsoleColor.White;
                            string response = Console.ReadLine();
                            if (response == "yes")
                            {
                                pC.gold += (pC.Inventory[i].goldAmount + (3 * character.chaScore));
                                pC.Inventory.Remove(pC.Inventory[i]);
                            }
                            else if (response == "no")
                            {
                                Console.WriteLine($"You are keeping {pC.Inventory[i].name}");
                            }
                            else
                            {
                                Console.WriteLine("The shopkeeper didnt understand you so you keep the item");
                            }

                        }
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

