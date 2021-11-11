using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell.Enemies
{
    public class Troll : ICharacter 
    {
        public CharacterType CharacterType
        {
            get
            {
                return CharacterType.Troll;
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
                return "Troll";
            }
        }
        public string NameDepiction
        {
            get
            {
                return "a Troll";
            }
        }
        public string NameReference
        {
            get
            {
                return "the Troll";
            }
        }
    }
}
