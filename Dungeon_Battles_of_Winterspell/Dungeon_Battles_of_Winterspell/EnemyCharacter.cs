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
        DungeonDweller
    }
    public class EnemyCharacter : ICharacter
    {
        public bool CanAttack { get; set; } = true;
        public bool HasSwiftness { get; set; } = false;
    }
}
