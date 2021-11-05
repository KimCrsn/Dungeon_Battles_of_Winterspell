using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell
{
    /// <summary>
    /// The purpose of this interface is so that there can be a tie between enemies and the player. One use case is for turn based queue to be generated which includes both players and enemies in a shuffle.
    /// </summary>
    public interface ICharacter
    {
        public bool HasSwiftness { get; }
        public string Name { get; }
    }
}
