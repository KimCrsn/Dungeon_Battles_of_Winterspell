using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell
{
    public enum WeaponType
    {
        Sword,
        Bow,
        Axe
    }
    public class Weapon
    {
        /// <summary>
        /// Constructor will take in the character itself so it can determine it's type (enum). It will equate this to a property called player, so that it can base it's weapon list off of the character type.
        /// </summary>
        /// <param name="characterType"></param>
        public Weapon (PlayerCharacter characterType)
        {

        }
        
        public PlayerCharacter Character { get; }

        // WeaponType should be derrived based upon the Character.CharacterType
        //public WeaponType WeaponType
        //{
        //    get
        //    {
        //        if (Character.)
        //    }
        //}
        // A collection of different weapons which will be created, and then added based on the character choice.
        public IEnumerable<Weapon> WeaponChoices { get; set; }
    }
}
