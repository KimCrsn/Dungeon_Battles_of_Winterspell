using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dungeon_Battles_of_Winterspell.Weapons;
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

        Queue<ICharacter> TurnOrder { get; set; }

        public ICharacter CurrentCombatCharacter { get; private set; }

        private PlayerCharacter player = new PlayerCharacter();
        private IPlayerWeapon weapon;
        private WeaponProvider weaponProvider = new WeaponProvider();
        private Dungeon dungeon = new Dungeon();
        private World newWorld = new World();
        private Room room = new Room();
        private CombatSystem combatSystem = new CombatSystem();

        /// <summary>
        /// Sets the local class method Dungeons equal to a list of generated dungeons. This is called once at the beginning of the game.
        /// </summary>
        public void GenerateDungeons()
        {
            // This sets up the property of the class to be equal only once to this generator
            this.Dungeons = dungeon.GenerateDungeonsManually();
        }

        public PlayerCharacter PlayerCharacter { get; set; }

        /// <summary>
        /// The CharacterType is retrieved from UI when the UI calls this method. It passes it in the current character type. The method then sets the local field player to the new character which
        /// the property of CharacterType has been set. Many derrived properties can be set with the this charType.
        /// </summary>
        /// <param name="charType"></param>
        public void CreateCharacter(CharacterType charType)
        {
            player = new PlayerCharacter(charType);
            PlayerCharacter = player;

            // Setting some properties for the new character. Would set properties within the class to defaults, but that involves setting them to readonlys.
            player.CheckSwiftness();
            player.EstablishHealth();
            player.EstablishAllTraits();

            // Generate a list of weapon choices by taking in which character was chosen
            weaponProvider.GetWeaponChoices(charType);

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
                case GameState.Combat:
                    StateCombat();
                    break;
                case GameState.PlayerTurn:
                    StatePlayerTurn();
                    break;
                case GameState.EnemyTurn:
                    StatePlayerTurn();
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
                Queue<ICharacter> turnQueue = room.SpawnedEnemies(player); // Gets the list of enemies and player in a turn queue.
                this.TurnOrder = turnQueue;
                storyText.NewRoomDepiction(turnQueue);
                CheckGameStates(GameState.Combat);
            }
        }

        public void StateCombat()
        {
            // begin fight text

            // Who's turn is it?
            foreach (ICharacter character in TurnOrder)  // property contains the current turn queue
            {
                this.CurrentCombatCharacter = character;
                if (character.IsPlayer) // if the current ICharacter in the list is the player
                {
                    CheckGameStates(GameState.PlayerTurn);
                }
                else
                {
                    CheckGameStates(GameState.EnemyTurn);
                }
            }
        }

            // don't forget to create readonly or established enemy health and weapon and stuff
            // create attack class and take in player which should have weapon equipped property
            // get the turn queue, if it is enemy first says "the {} has used his club to perform a gorund smack for __ damage
            // maybe a loading calculation or something lol. It effects the players health and a health check is performed fro death on player
            // next turn... when it is players, present user with an attack menu. different attacks, different abilities, readding manual contaisn info
            // also have a 2 phase turn for player and if they drink potion, ptoions -= 1 and health += 25
            // player chooses from turn queue, after player attacks enemy, the dead enemy checkwer will look at if it is dead, if so, remove from queue
            // once queue.count == 0, combat phase complete and switch to loot phase. player may find 1-3 rng items around the room. They might be
            //hp potions or gold or cool pieces of lore.
            // the player can of course use the hp filler here too
            //also dungeon -= 1 room and room cleared
            // new room and text for it do this until rooms remainging ii 0 at which point offer new dungeon.
        
        public void StatePlayerTurn()
        {
            // present player with options of attack, potion or flee
            // take in user input adn based on which attack do player.attack1 or 2(pass in their target)
            //once it goes there it will build the attack and pass the info on to the attack method in attack calss
        }

        //public void StateEnemyTurn()
        //{
        //    // text to represent attack preface
        //    combatSystem.InflictDamage(player, CurrentCombatCharacter); // No targeting required as there is only one player

        //    //player.IsDeadCheck()
        //}
    }
}
