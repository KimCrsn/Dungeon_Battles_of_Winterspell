using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell
{
    // All of the player character options
    public enum CharacterType
    {
        Enchantress,
        Dwarf,
        Woodelf
    }
    public enum EnemyType
    {
        Goblin,
        CaveBrute,
        FireSpitter,
        Gremlin
    }

    /// <summary>
    /// This class identifies the player and contains idle and updating properties to represent the character. The defaults will vary depended upon the player type enum passed into the constructor.
    /// </summary>
    public class PlayerCharacter
    {
        /// <summary>
        /// Upon player having picked a character with user input, the enum of character type will be set. This will be passed into the character when created.
        /// PlayerCharacter knowing the CharacterType will determine every other aspect of calculation for the char.
        /// </summary>
        /// <param name="playerType"></param>
        public PlayerCharacter (CharacterType playerType)
        {
            this.PlayerType = playerType;
        }

        // Current and updating health of character
        public int Health { get; set; }

        // If true, player has the ability to be added to a turn queue of turn phase
        public bool HasSwiftness { get; set; }

        // Readonly so it can be passed in when the character is created using user input.
        public CharacterType PlayerType { get; }

        // What is the weapon object of the player?
        public Weapon Weapon { get; set; }

        public int PotionCount { get; set; } = 1; // By default a player has 1 potion. A player can have up to 3 potions.

        /// <summary>
        /// All attributes have default values determined by their character type.
        /// </summary>
        public int Strength // Dwarf is most skilled in strength.
        {
            get
            {
                int strength = 0;
                switch (PlayerType)
                {
                    case CharacterType.Dwarf:
                        strength = 4;
                        break;
                    case CharacterType.Enchantress:
                        strength = 0;
                        break;
                    case CharacterType.Woodelf:
                        strength = 1;
                        break;
                    default:
                        return 0; // This should never be reached.
                }
                return strength;
            }
        }
        public int Intelligence // Enchantress is most skilled in intelligence (magic).
        {
            get
            {
                int intelligence = 0;
                switch (PlayerType)
                {
                    case CharacterType.Dwarf:
                        intelligence = 0;
                        break;
                    case CharacterType.Enchantress:
                        intelligence = 3;
                        break;
                    case CharacterType.Woodelf:
                        intelligence = 0;
                        break;
                    default:
                        return 0; // This should never be reached.
                }
                return intelligence;
            }
        }
        public int Dexterity // Woofelf is most skilled in Dexterity.
        {
            get
            {
                int dexterity = 0;
                switch (PlayerType)
                {
                    case CharacterType.Dwarf:
                        dexterity = 0;
                        break;
                    case CharacterType.Enchantress:
                        dexterity = 1;
                        break;
                    case CharacterType.Woodelf:
                        dexterity = 3;
                        break;
                    default:
                        return 0; // This should never be reached.
                }
                return dexterity;
            }
        }

        /// <summary>
        /// When a character takes damage from another character, the health is checked to verify if dead is true or false, and also sets the current health.
        /// </summary>
        /// <param name="attack"></param>
        public void DamageTaken(Attack attack)
        {
            int currHealth = this.Health - attack.DamageInflicted;
            IsDead(currHealth); // Checks if the player is dead or not.
        }

        /// <summary>
        /// Checks that the current health of the player when damage is taken, is not at or below 0. If it is not, return false. If yes, return true.
        /// </summary>
        /// <param name="currentHealth"></param>
        /// <returns></returns>
        public bool IsDead(int currentHealth)
        {
            if (currentHealth <= 0)
            {
                return true;
            }
            else
            {
                // if the player is still alive, set the health = to the current health.
                this.Health = currentHealth;
                return false;
            }
        }
    }
}
