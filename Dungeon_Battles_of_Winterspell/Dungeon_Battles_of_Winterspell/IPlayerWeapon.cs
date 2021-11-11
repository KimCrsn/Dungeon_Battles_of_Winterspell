using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell
{
    public interface IPlayerWeapon
    {
        public WeaponType WeaponType { get; }
        public string Name { get; }
        public Attack BuildAttack1(EnemyCharacter targetEnemy);
        public Attack BuildAttack2(EnemyCharacter targetEnemy);

    }
}
