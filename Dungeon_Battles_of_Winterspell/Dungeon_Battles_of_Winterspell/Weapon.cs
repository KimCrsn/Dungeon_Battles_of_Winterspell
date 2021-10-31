using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell
{
    public enum WeaponType
    {
        SteelSplitHammer,
        DoubleBladedAxe,
        OrnateShortSword,
        OakCarvedWand,
        GnarledBranchStaff,
        DualEtherealDaggers,
        ShortErnestBowAndQuiver,
        IvoryLongBowAndQuiver,
        ElvenLongsword,
        Uknown
    }
    public class Weapon
    {
        /// <summary>
        /// Constructor will take in the character itself so it can determine it's type (enum). It will equate this to a property called player, so that it can base it's weapon list off of the character type.
        /// </summary>
        /// <param name="characterType"></param>
        public Weapon(WeaponType weaponType)
        {
            this.WeaponType = weaponType;
        }

        public WeaponType WeaponType { get; }

        /// <summary>
        /// Returns an ICollection<Weapon> which will be a list of 3 weapons.
        /// The outcome of the list will depend on the character chosen.
        /// </summary>
        /// <param name="charType"></param>
        /// <returns></returns>
        public void GetWeaponChoices(CharacterType charType)
        {
            List<Weapon> weaponList = new List<Weapon>();
            Dictionary<int, Weapon> weaponChoices = new Dictionary<int, Weapon>();
            switch (charType)
            {
                case CharacterType.Dwarf:
                    weaponList.Add(new Weapon(WeaponType.DoubleBladedAxe));
                    weaponList.Add(new Weapon(WeaponType.SteelSplitHammer));
                    weaponList.Add(new Weapon(WeaponType.OrnateShortSword));
                    break;
                case CharacterType.Enchantress:
                    weaponList.Add(new Weapon(WeaponType.OakCarvedWand));
                    weaponList.Add(new Weapon(WeaponType.GnarledBranchStaff));
                    weaponList.Add(new Weapon(WeaponType.DualEtherealDaggers));
                    break;
                case CharacterType.Woodelf:
                    weaponList.Add(new Weapon(WeaponType.ShortErnestBowAndQuiver));
                    weaponList.Add(new Weapon(WeaponType.IvoryLongBowAndQuiver));
                    weaponList.Add(new Weapon(WeaponType.ElvenLongsword));
                    break;
            }
            // Int included in the dictionary to represent the number to select. Setting the property of WeaponChoices = to a dictionary of the choices for the specific character and int values for idents.
            int i = 1;
            foreach (Weapon weapon in weaponList)
            {
                weaponChoices[i] = weapon;
                i++;
            }
            // Display the weapon choices
            UserInterface ui = new UserInterface();
            ui.DisplayWeaponsAndSelect(weaponChoices); // Takes in a dictionary in order to display them along with their key.
        }

        public override string ToString()
        {
            return $"   {WeaponType.ToString()}";
        }

    }
}
