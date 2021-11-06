using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell
{
    public enum EnemyType
    {
        Goblin,
        Troll,
        Firespitter,
        Undead,
        HauntingSpirit,
        UndeadWolf,
        DungeonDweller,
    }
    public class EnemyCharacter : ICharacter
    {
        // Swiftness is true for Firespitter and Undeadwolves
        public bool HasSwiftness
        {
            get
            {
                if (EnemyType == EnemyType.Firespitter || EnemyType == EnemyType.UndeadWolf)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // Enemy type is randomized each time a new enemy is created
        public EnemyType EnemyType
        {
            get
            {
                EnemyType[] enemies = new EnemyType[7]; // new array to store each enum EnemyType
                int i = 0;
                foreach (EnemyType enemy in (EnemyType[])Enum.GetValues(typeof(EnemyType))) // Looping over an enum
                {
                    enemies[i] = enemy; // Adding the current enemy loooped into the i index array element
                    i++;
                }

                Random rnd = new Random();
                int rngNum = rnd.Next(0, 8); // Creates a number between 0 and 7 inclusive representing indexes of the arrays.
                EnemyType enemyType = enemies[rngNum]; // Equates the EnemyType enum to what a random index is the array of options for enemy types.
                return enemyType;
            }
        }

        public string Name
        {
            get
            {
                string name = EnemyType.ToString().Substring(0,);
            }
        }

        public string Name
        {
            get
            {
                switch (EnemyType)
                {
                    case EnemyType.DungeonDweller:
                        return "Dungeon Dweller";
                    case EnemyType.Firespitter:
                        return "Firespitter";
                    case EnemyType.Goblin:
                        return "Goblin";
                    case EnemyType.HauntingSpirit:
                        return "Haunting Spirit";
                    case EnemyType.Troll:
                        return "Troll";
                    case EnemyType.Undead:
                        return "Undead";
                    case EnemyType.UndeadWolf:
                        return "Undead Wolf";
                    default:
                        return null;
                }
            }
        } // Varies per character type enum

    }
}
