﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell
{
    public class UserInterface
    {
        private Game game = new Game();
        private Weapon weapon = new Weapon(WeaponType.Uknown);

        public void BeginGame()
        {
            // Story Text, then...
            DisplayCharacterSelect();
        }

        // Displays the menu of character choices, once a player has selected a character, there will be output text and a character type will be set.
        public CharacterType DisplayCharacterSelect()
        {
            // Establishing the type of character the player chooses. Starts in an uknown state. Changes based upon player selection.
            CharacterType charType = CharacterType.Uknown;

            bool valid = true;
            while (valid)
            {
                int userInput = CLIHelper.GetInteger("    Choose your class\n\n    1 - Dwarf    2 - Enchantress    3 - Woodelf:   ");
                switch (userInput)
                {
                    case 1:
                        charType = CharacterType.Dwarf;
                        Console.WriteLine("Aw, what an adoarable gnome!");
                        Console.ReadKey();
                        Console.WriteLine("Okay, okay calm down, I was only jesting!");
                        Console.ReadKey();
                        valid = false;
                        break;
                    case 2:
                        charType = CharacterType.Enchantress;
                        Console.WriteLine("You posses the Thaumaturgy of the ancient world within you.");
                        Console.ReadKey();
                        valid = false;
                        break;
                    case 3:
                        charType = CharacterType.Woodelf;
                        Console.WriteLine("From the Halls of Miritar, you venture, where the ruins of Myth Drannor await your return.");
                        Console.ReadKey();
                        valid = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please take this seriously.");
                        valid = true;
                        break;
                }
            }
            game.CreateCharacter(charType);
            return charType;
        }

        public Weapon DisplayWeaponsAndSelect(Dictionary<int, Weapon> weapons)
        {
            Console.Clear();
            // A while loop to continue redisplaying weapon options and the request of a choice if the user would make an incorrect int.
            bool valid = true;
            while (valid)
            {
                Console.WriteLine($"    Choose your weapon");
            foreach(KeyValuePair<int, Weapon> weapon in weapons)
            {
                // weapon.Key represents and int 1 - 3 for the value of player selection.
                Console.WriteLine($"    {weapon.Key})   {weapon.Value}");
            }
                int userInput = CLIHelper.GetInteger($"    Your weapon sire:  ");
                switch (userInput)
                {
                    // Each weapons[i], i represents the key to correspond with the int input. That equates the local field weapon variable to become the Weapon value associated with that key.
                    case 1:
                        weapon = weapons[1]; // Same as Weapon weapon = new Weapon(); weapon is now = to the user selected weapon from the dictionary.
                        valid = false;
                        break;
                    case 2:
                        weapon = weapons[2];
                        valid = false;
                        break;
                    case 3:
                        weapon = weapons[3];
                        valid = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("These are the only weapons fit for you from the armoury, please make your choice.");
                        valid = true;
                        break;
                }
            }
            Console.WriteLine("An ardent choice!");
            // The player has made their choice.
            return weapon;
        }

        /// <summary>
        /// Here, the player will allocate 10 skill points and choose which attributes to add them to as well as how many.
        /// Takes in a player, so player object stays the same, and player attribute properties can be updated according to user input.
        /// </summary>
        /// <param name="player"></param>
        public bool AllocateAttributes(PlayerCharacter player)
        {
            Console.Clear();
            int remainingPoints = 10; // The remaining points regardless of the user's input. Declared at 10 but updates based on math within the while statement.
            int currAttributeStatus; // This is the player's attribute (str, int, dex points) property within the PlayerCharacter class, represented as an int.
            // int defaultAttributeStat; // This is the players default standard point amount, this is to enforce that however many points were origonally allocated, cannot be taken away. Doesn't work for now as const is not viable here yet.
            // While the user still has points to spend, continue to prompt which attribute to allocate points to, and how many. CLI Helper will take care of the validity of the points.
            while (remainingPoints != 0) // This screen reapears after each allocation of points, but the variables in the strings will be updated. This is for viewing clarity and lack of clutter on screen.
            {
                Console.WriteLine($"    You have {remainingPoints} points left to allocate into each attribute, please assign your skill points");
                Console.WriteLine();
                Console.WriteLine($"    1) Strength: {player.Strength}        2) Intelligence: {player.Intelligence}         3) Dexterity: {player.Dexterity}"); // Each attribute will reveal the updated PlayerCharacter attribute prop count.

                int userInput = CLIHelper.GetInteger("    Which attribute would you like to assign points to?:   "); // User choses from the attribute list of str, int or dex to where to assign points.

                switch (userInput)
                {
                    case 1: // Strength
                        currAttributeStatus = player.Strength; // THE PLAYER'S CURRENT STR ATTRIBUTE AMOUNT. (**  For later purposes - a note - When this is first read, it will be the default of the player's attribute. Passing it into a new constant int.)
                       
                        // A dictionary holding KEY: updated remaining points, VALUE: userInput (as an int).                                                            //const int defaultStrength = currAttributeStatus; NOT A WAY TO FIND THE DEFAULT STRENGTH UNLESS AN ACCESSIBLE PROPERTY IS PROVIDED IN CLASS.
                        Dictionary<int, int> strPointsBookRS = CLIHelper.GetPoints("    How much would you like to assign to strength?:   ", currAttributeStatus, remainingPoints, "strength"); // remaining points was 10 at the start.
                        int strInput = 0; // Declaring purposes to pull the value of the user input from the pointsBook and add it to the strength attribute.
                        foreach (KeyValuePair<int, int> allocation in strPointsBookRS) // Looping through dictionary to pull the key/value into their own variables for updaing purposes.
                        {
                            player.Strength += allocation.Value; // Updating player strength.
                            remainingPoints = allocation.Key; // Updating remaining points local variable.
                            strInput = allocation.Value; // Updating user's int input into variable.
                        }
                            Console.WriteLine();
                            Console.WriteLine($"    You have chosen to allocte {strInput} points into strength. You have {remainingPoints} points left to spend.");
                        
                        Console.ReadKey();
                        Console.Clear();
                        break;


                    case 2: // Intellegence
                        currAttributeStatus = player.Intelligence; // THE PLAYER'S CURRENT INT ATTRIBUTE AMOUNT.

                        Dictionary<int, int> intPointsBookRS = CLIHelper.GetPoints("    How much would you like to assign to intelligence?:   ", currAttributeStatus, remainingPoints, "intellegence");
                        int intInput = 0; // Declaring purposes to pull the value of the user input from the pointsBook and add it to the strength attribute.
                        foreach (KeyValuePair<int, int> allocation in intPointsBookRS) // Looping through dictionary to pull the key/value into their own variables for updaing purposes.
                        {
                            player.Intelligence += allocation.Value; // Updating player strength.
                            remainingPoints = allocation.Key; // Updating remaining points local variable.
                            intInput = allocation.Value; // Updating user's int input into variable.
                        }
                            Console.WriteLine();
                            Console.WriteLine($"    You have chosen to allocte {intInput} points into intellegence. You have {remainingPoints} points left to spend.");

                        Console.ReadKey();
                        Console.Clear();
                        break;


                    case 3: // Dexterity
                        currAttributeStatus = player.Dexterity; // THE PLAYER'S CURRENT DEX ATTRIBUTE AMOUNT.

                        Dictionary<int, int> dexPointsBookRS = CLIHelper.GetPoints("    How much would you like to assign to dexterity?:   ", currAttributeStatus, remainingPoints, "dexterity");
                        int dexInput = 0; // Declaring purposes to pull the value of the user input from the pointsBook and add it to the strength attribute.
                        foreach (KeyValuePair<int, int> allocation in dexPointsBookRS) // Looping through dictionary to pull the key/value into their own variables for updaing purposes.
                        {
                            player.Dexterity += allocation.Value; // Updating player strength.
                            remainingPoints = allocation.Key; // Updating remaining points local variable.
                            dexInput = allocation.Value; // Updating user's int input into variable.
                        }
                            Console.WriteLine();
                            Console.WriteLine($"    You have chosen to allocte {dexInput} points into dexterity. You have {remainingPoints} points left to spend.");
                        
                        Console.ReadKey();
                        Console.Clear();
                        break;


                    default:
                        Console.Clear();
                        Console.WriteLine("    Please choose an attribute to adjust"); // This will cause the message to display above and have the user re-enter their choice.
                        break;
                }
            }

            Console.WriteLine($"    Strength: {player.Strength}     Intellegence: {player.Intelligence}     Dexterity: {player.Dexterity}");
            bool userHappy = CLIHelper.GetBool("    These are your current skill point totals, are you happy with them? Y/N:  ");
            
            if (userHappy)
            {
                return true;
            }
            else
            {
                // Erase history of method. 
                player.EstablishDexterity();
                player.EstablishIntelligence();
                player.EstablishStrength();
                Console.WriteLine("    You may start again.");
                Console.ReadKey();
                return false; // This represents a return of false, to NOT leave menu. When the last method read sees the return, it will  restart the last menu and let the user redo everything.
            }
        }


        public void DungeonDisplay()
        {
            Console.WriteLine($"Your journey begins, here is your map of dungeons. You may have yet to discover some!\n\n");
        }
    }
}
