using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell.Weapons.EnchantressWeapons
{
    public class OakCarvedWand : IPlayerWeapon
    {
        public WeaponType WeaponType
        {
            get
            {
                return WeaponType.OakCarvedWand;
            }
        }

        public string Name
        {
            get
            {
                return "Oak Carved Wand";
            }
        }

        public Attack BuildAttack1(EnemyCharacter targetEnemy)
        {
            // attack type is strike of thunder and steel
            Attack attack = new Attack(AttackType.DarkCharm,
                "Dark Charm",
                "a highly precise and powerful slash to a single enemy target",
                100, 99..100, 100, false);
            return attack; // Based on info passed in, the attack class should calculate the damage total and such. Crit will occur if the attack hits and the dmg is relavant.
        }
        public Attack BuildAttack2(EnemyCharacter targetEnemy)
        {
            // attack type is strike of thunder and steel
            Attack attack = new Attack(AttackType.AncientIncantation,
                "Ancient Incantation",
                "a practice of the lessons, taught by the elders of the homeland.",
                30, 22..30, 60, false);
            return attack; // Based on info passed in, the attack class should calculate the damage total and such. Crit will occur if the attack hits and the dmg is relavant.
        }
    }
}
