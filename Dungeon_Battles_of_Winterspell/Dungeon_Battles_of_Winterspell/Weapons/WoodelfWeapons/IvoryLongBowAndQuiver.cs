using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell.Weapons.WoodelfWeapons
{
    public class IvoryLongBowAndQuiver : IPlayerWeapon
    {
        public WeaponType WeaponType
        {
            get
            {
                return WeaponType.IvoryLongBowAndQuiver;
            }
        }

        public string Name
        {
            get
            {
                return "Ivory Long Bow and Quiver";
            }
        }
        public Attack BuildAttack1(EnemyCharacter targetEnemy)
        {
            // attack type is strike of thunder and steel
            Attack attack = new Attack(AttackType.SnipersMark,
                "Snipers Mark",
                "a highly precise shot to the head which never misses it's mark",
                100, 99..100, 100, false);
            return attack; // Based on info passed in, the attack class should calculate the damage total and such. Crit will occur if the attack hits and the dmg is relavant.
        }
        public Attack BuildAttack2(EnemyCharacter targetEnemy)
        {
            // attack type is strike of thunder and steel
            Attack attack = new Attack(AttackType.MajesticVolley,
                "Majestic Volley",
                "a majestic volley of arrows are shot up and rain down from above.",
                16, 10..16, 50, false);
            return attack; // Based on info passed in, the attack class should calculate the damage total and such. Crit will occur if the attack hits and the dmg is relavant.
        }
    }
}
