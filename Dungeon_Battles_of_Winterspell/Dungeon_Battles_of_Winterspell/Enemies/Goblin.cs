using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell.Enemies
{
    public class Goblin : ICharacter
    {
        public CharacterType CharacterType
        {
            get
            {
               return CharacterType.Goblin;
            }
        }
        public bool IsPlayer
        {
            get
            {
                return false;
            }
        }
        public bool HasSwiftness
        {
            get
            {
                return false;
            }
        }
        public string Name
        {
            get
            {
                return "Goblin";
            }
        }
        public string NameDepiction
        {
            get
            {
                return "a Goblin";
            }
        }
        public string NameReference
        {
            get
            {
                return "the Goblin";
            }
        }
    }
}
