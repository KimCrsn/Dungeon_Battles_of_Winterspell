using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell
{
    public class SteelSplitHammer : IPlayerWeapon
    {
        public WeaponType WeaponType
        {
            get
            {
                return WeaponType.SteelSplitHammer;
            }
        }

        public string Name
        {
            get
            {
                return "Steel Split Hammer";
            }
        }
        public Attack BuildAttack1 (EnemyCharacter targetEnemy)
        {
            // attack type is strike of thunder and steel
            Attack attack = new Attack(AttackType.StrikeOfThunderAndSteele,
                "Strike of Thunder and Steel",
                "a powerful and mighty blow of a heavy steel to the ground infront of the enemy's feet." +
                "This attack is powerful enough to effect the target enemy and one surrounding enemy on either side.", 
                12, 8..12, 80, true);
            return attack; // Based on info passed in, the attack class should calculate the damage total and such. Crit will occur if the attack hits and the dmg is relavant.
        }
        public Attack BuildAttack2(EnemyCharacter targetEnemy)
        {
            // attack type is strike of thunder and steel
            Attack attack = new Attack(AttackType.WoundingSkullCruncher,
                "Wounding Skull Cruncher",
                "a disturbing and heavy fall of his hammer, to the enemy's head, where, if it hits at it's mightiest," +
                " the contact will surely destroy the enemy from head to toe.",
                40, 33..40, 60, false);
            return attack; // Based on info passed in, the attack class should calculate the damage total and such. Crit will occur if the attack hits and the dmg is relavant.
        }

    }
}
