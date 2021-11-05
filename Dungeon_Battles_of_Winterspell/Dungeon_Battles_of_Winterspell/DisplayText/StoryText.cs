using System;
using System.Collections.Generic;
using System.Text;
using Dungeon_Battles_of_Winterspell;
using DungeonBattles_Of_Winterspell;

namespace DungeonBattles_Of_Winterspell.DisplayText
{
    public class StoryText
    {
        //private UserInterface UI = new UserInterface();

        /// <summary>
        /// Begins the story and game.
        /// </summary>
        public void OpeningStoryText()
        {
            TypeEffect typingOutText = new TypeEffect();
            //InquiriesToPlayer inquiries = new InquiriesToPlayer();
            // Begin the story if game is commenced
            typingOutText.TypedText("Winterspell has been overtaken by the Goblins of the North, among other foul creatures of the deep.", true);
            //Wait for user to click enter to continue to next line. (This works but if user clicks enter while first line is being typed, it does not wait.
            Console.ReadLine();
            typingOutText.TypedText("They mean to destroy our resources, harbinge our foes and swallow our townsfolk.", true);
            Console.ReadLine();
            typingOutText.TypedText("Winter is come. We yet have been able to scurge the unholy creatures.....", true);
            Console.ReadLine();
            typingOutText.TypedText("Will you help fight? And save the town of Winterspell?(y/n): ", true);
            //inquiries.PlayerFightInquiry();
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
