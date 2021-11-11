using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell.Enemies
{
    public class Firespitter : EnemyCharacter, ICharacter
    {
        public EnemyType EnemyType
        {
            get
            {
                return EnemyType.Troll;
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
                return true;
            }
        }
        public string Name
        {
            get
            {
                return "Firespitter";
            }
        }
        public string NameDepiction
        {
            get
            {
                return "a Firespitter";
            }
        }
        public string NameReference
        {
            get
            {
                return "the Firespitter";
            }
        }
    }
}
