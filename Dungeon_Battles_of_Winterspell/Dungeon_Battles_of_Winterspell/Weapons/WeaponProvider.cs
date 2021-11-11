using Dungeon_Battles_of_Winterspell.Weapons.EnchantressWeapons;
using Dungeon_Battles_of_Winterspell.Weapons.WoodelfWeapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell.Weapons
{
    public class WeaponProvider
    {
        /// <summary>
        /// Returns an ICollection<IWeapon> which will be a list of 3 weapons.
        /// The outcome of the list will depend on the character chosen.
        /// It then sends the dictionary built from the list over to display in the UI.
        /// </summary>
        /// <param name="charType"></param>
        /// <returns></returns>
        public void GetWeaponChoices(CharacterType charType)
        {
            List<IPlayerWeapon> weaponList = new List<IPlayerWeapon>();
            Dictionary<int, IPlayerWeapon> weaponChoices = new Dictionary<int, IPlayerWeapon>();
            switch (charType)
            {
                case CharacterType.Dwarf:
                    weaponList.Add(new DoubleBladedAxe());
                    weaponList.Add(new SteelSplitHammer());
                    weaponList.Add(new OrnateShortSword());
                    break;
                case CharacterType.Enchantress:
                    weaponList.Add(new OakCarvedWand());
                    weaponList.Add(new GnarledBranchStaff());
                    weaponList.Add(new DualEtherealDaggers());
                    break;
                case CharacterType.Woodelf:
                    weaponList.Add(new ShortErnestBowAndQuiver());
                    weaponList.Add(new IvoryLongBowAndQuiver());
                    weaponList.Add(new ElvenLongsword());
                    break;
            }
            // Int included in the dictionary to represent the number to select. Setting the property of WeaponChoices = to a dictionary of the choices for the specific character and int values for idents.
            int i = 1;
            foreach (IPlayerWeapon weapon in weaponList)
            {
                weaponChoices[i] = weapon;
                i++;
            }
            // Display the weapon choices
            UserInterface ui = new UserInterface();
            ui.DisplayWeaponsAndSelect(weaponChoices); // Takes in a dictionary in order to display them along with their key.
        }
    }
}
