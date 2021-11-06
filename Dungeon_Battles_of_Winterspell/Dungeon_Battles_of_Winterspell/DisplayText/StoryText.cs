using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Dungeon_Battles_of_Winterspell;
using DungeonBattles_Of_Winterspell;

namespace DungeonBattles_Of_Winterspell.DisplayText
{
    public class StoryText
    {
        //private UserInterface UI = new UserInterface();

        public void LoadingScreen()
        {
            bool repeat = true;
            int times = 0;
            while (repeat)
            {
                if (times == 2)
                {
                    repeat = false;
                }
                string text = "Loading.......";
                foreach (char character in text)
                {
                    //write out the characters to the screen.
                    Console.Write(character);
                    //speed of it beging typed out effect.
                    Thread.Sleep(200);
                }
                times++;
                Console.Clear();
            }
           
        }

        /// <summary>
        /// Begins the story and game. Asks a user if they wish to fight, returns a bool true for yes or false for no.
        /// </summary>
        public bool OpeningStoryText()
        {
            TypeEffect typingOutText = new TypeEffect();
            // Begin the story if game is commenced
            typingOutText.TypedText("Hello traveler! The Town of Winterspell has been overtaken by the dark creatures of the North, Goblins, the Undying and Trolls... Among other foul creatures of the deep.", true);
            //Wait for user to click enter to continue to next line. (This works but if user clicks enter while first line is being typed, it does not wait.
            Console.ReadLine();
            typingOutText.TypedText("They mean to destroy our resources, harbinge our foes and swallow our townsfolk.", true);
            Console.ReadLine();
            typingOutText.TypedText("Winter is come. We yet have been able to scurge the unholy creatures.....", true);
            Console.ReadLine();

            bool userInput;
            return userInput = CLIHelper.GetBool("Will you help fight? And save the town of Winterspell?(y/n): ");
        }

        public void WhoAreYou()
        {
            TypeEffect typingOutText = new TypeEffect();

            typingOutText.TypedText("Pray tell... Who are you?", true);
            Console.ReadLine();
            //UI.DisplayCharacterChoices();
        }

        public void ChooseWeapon()
        {
            TypeEffect typingOutText = new TypeEffect();
            Console.Clear();
            typingOutText.TypedText("Now, you can't go around fight gobgobs and the undead with just your bare hands...", true);
            Console.ReadLine();
        }

        public void PrepareForBattle()
        {
            TypeEffect typingOutText = new TypeEffect();
            Console.Clear();
            typingOutText.TypedText("Time for battle, off to the dugneons, here is your map: ", true);
            
        }

        public void NewRoom(ICollection<ICharacter> turnQueue)
        {
            TypeEffect typingOutText = new TypeEffect();
            Console.Clear();
            // make how you entered a new room rng between different options.
            typingOutText.TypedText($"You have stumbled into a new room where you have discovered a ", true);
            foreach(ICharacter character in turnQueue)
            {
                // check that there is still a next character otherwise must not have an a at the end.
                typingOutText.TypedText($"{character.Name}, a", true);
            }
            typingOutText.TypedText("Combat begins...", true);
        }

    }
}
