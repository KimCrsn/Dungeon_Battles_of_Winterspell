using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonBattles_Of_Winterspell.DisplayText;

namespace Dungeon_Battles_of_Winterspell
{
    // States of the game itself
    public enum GameState
    {
        Idle,
        NewDungeon,
        NewRoom,
        Combat,
        EnemyTurn,
        PlayerTurn,
        PostBattle
    }
    // Moves that can be performed during the player's turn
    public enum PlayerMove
    {
        Attack1,
        Attack2,
        DrinkPotion,
        Flee
    }

    // Moves that can be performed during the enemy's turn
    public enum EnemyMove
    {
        Attack
    }

    /// <summary>
    /// This class is responsible for the executing and the creation of the character based upon player choice by calling initial establishments.
    /// It is responsible mainly for handling the different game states, and calling to most classes to accomplish methods by which to acheive new states.
    /// Most instantiations will be done in this class.
    /// </summary>
    public class Game
    {
        public GameState CurrentGameState { get; private set; }

        public List<Dungeon> Dungeons { get; private set; }
        
        public Dungeon CurrentDungeon { get; set; }

        private PlayerCharacter player = new PlayerCharacter();
        private Weapon weapon = new Weapon();
        private Dungeon dungeon = new Dungeon();
        private World newWorld = new World();
        private Room room = new Room();

        /// <summary>
        /// Sets the local class method Dungeons equal to a list of generated dungeons. This is called once at the beginning of the game.
        /// </summary>
        public void GenerateDungeons()
        {
            // This sets up the property of the class to be equal only once to this generator
            this.Dungeons = dungeon.GenerateDungeonsManually();
        }

        /// <summary>
        /// The CharacterType is retrieved from UI when the UI calls this method. It passes it in the current character type. The method then sets the local field player to the new character which
        /// the property of CharacterType has been set. Many derrived properties can be set with the this charType.
        /// </summary>
        /// <param name="charType"></param>
        public void CreateCharacter(CharacterType charType)
        {
            player = new PlayerCharacter(charType);

            // Setting some properties for the new character. Would set properties within the class to defaults, but that involves setting them to readonlys.
            player.CheckSwiftness();
            player.EstablishHealth();
            player.EstablishAllTraits();

            // Generate a list of weapon choices by taking in which character was chosen
            weapon.GetWeaponChoices(charType);

            bool leaveMenu = false;
            while (!leaveMenu)
            {
                UserInterface ui = new UserInterface();

                leaveMenu = ui.AllocateAttributes(player);
                if (leaveMenu)
                {
                    // Begin 
                    BeginJourney();
                }
            }
        }

        public void BeginJourney()
        {
            StoryText storyText = new StoryText();

            storyText.PrepareForBattle();
            GenerateDungeons(); // Sneaking this in the perform the first and only dungeon generating.
            CheckGameStates(GameState.NewDungeon);
        }
        
        public void CheckGameStates(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.NewDungeon:
                    StateNewDungeon(); // 
                    CheckGameStates(GameState.NewRoom);
                    break;
                case GameState.NewRoom:
                    StateNewRoom();
                    break;
            }
        }




        /// <summary>
        /// Handles the process for checking which is the current dungeon and reveals its name accordingly. It calls to check state again, setting the game state to new room.
        /// </summary>
        public void StateNewDungeon()
        {
            UserInterface ui = new UserInterface();
            // set the next dungeon to current. This line allows for whichever is the current dungeon, for this  property to now represent that dungeon.
            this.CurrentDungeon = dungeon.CheckCurrentDungeon(Dungeons); // This calls the method which will allow for dungeon class to perform functionality of checking the dungeon states. Gets the proeprty of dungeons.
            // Calls to the UI to display the dungeons
            ui.Map(Dungeons, newWorld.ToString());
            CheckGameStates(GameState.NewRoom);
            Console.ReadKey();
        }

        // Sets up the new room for the player. Spawns enemies, creates a combat queue. Checks that the dungeon is complete or not.
        public void StateNewRoom()
        {
            UserInterface ui = new UserInterface();
            StoryText storyText = new StoryText();

            // Check that there are more rooms to generate for the dungeon.
            if (dungeon.RoomsRemaining == 0) // Knowing that dungeon is the current dungeon as it was set as such
            {
                ui.DungeonComplete();
                // set dungeon to complete how to find specific dungeon we are on?
                dungeon.Completed = true;
            }
            else
            {
                dungeon.RoomsRemaining -= 1; // This changes the current count of rooms remaining on the dungoen
                ICollection<ICharacter> turnQueue = room.SpawnedEnemies(player); // Gets the list of enemies and player in a turn queue.
                storyText.NewRoom(turnQueue);
            }
        }
    }
}
