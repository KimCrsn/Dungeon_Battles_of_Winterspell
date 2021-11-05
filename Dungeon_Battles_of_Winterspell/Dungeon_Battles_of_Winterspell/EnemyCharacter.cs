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
        Unknown
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
        public EnemyType EnemyType { get; set; } = EnemyType.Unknown;

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
