using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell
{
    public enum EnemyType
    {
        Goblin,
        Troll,
        Firespitter,
        Undead,
        HauntingSpirit,
        UndeadWolf,
        DungeonDweller
    }
    public class EnemyCharacter : ICharacter
    {
        public bool IsPlayer
        {
            get
            {
                return false;
            }
        }
        public virtual int Health { get; set; } = 40;

        // Swiftness is true for Firespitter and Undeadwolves
        public virtual bool HasSwiftness { get; } = false;

        /// <summary>
        /// Derived property of the type of attack which is dependent on the enemy type.
        /// </summary>
        public AttackType Attack { get; }
        public string Name { get; }

//        public void method()
//        {
//            List<Func<GameEnemy>> enemyCreationFunctions = new List<Func<GameEnemy>>();
//​
//            enemyCreationFunctions.Add(() => new Goblin());
//                        enemyCreationFunctions.Add(() => new Dorkwad());
//            // ...
//            ​
//            int index = myExistingRandomIDefinitelyDidntCreateInThisSameFunction.Next(enemyCreationFunctions.Count);
//            ​
//            Func<GameEnemy> creator = enemyCreationFunctions[index];
//            ​
//            GameEnemy enemy = creator(); // maybe creator.Invoke()?
//            ​
//            return enemy;
//        }

        // Enemy type is randomized each time a new enemy is created
        public EnemyType CharacterType
        {
            get
            {
                EnemyType[] enemies = new EnemyType[7]; // new array to store each enum EnemyType
                int i = 0;
                foreach (EnemyType enemy in (EnemyType[])Enum.GetValues(typeof(EnemyType))) // Looping over an enum
                {
                    enemies[i] = enemy; // Adding the current enemy loooped into the i index array element
                    i++;
                }

                Random rnd = new Random();
                int rngNum = rnd.Next(0, 7); // Creates a number between 0 and 7 inclusive representing indexes of the arrays.
                EnemyType enemyType = enemies[rngNum]; // Equates the EnemyType enum to what a random index is the array of options for enemy types.
                return enemyType;
            }
        }


        // Depending on the name of the enemy, when describing them in the game, it must use either a or an
        //public string NameDepiction
        //{
        //    get
        //    {
        //        string name = "";
        //        if (Name == "Dungeon Dweller"
        //            || Name == "Firespitter"
        //            || Name == "Goblin"
        //            || Name == "Haunting Spirit"
        //            || Name == "Troll")
        //        {
        //            name = "a " + this.Name;
        //        }
        //        else if (Name == "Undead" || Name == "Undead Wolf")
        //        {
        //            name = "an " + this.Name;
        //        }
        //        return name;
        //    }
        //} // This is for the inital description of the room
        //public string NameReference
        //{
        //    get
        //    {
        //        string name = "the " + this.Name;
        //        return name;
        //    }
        //} // This is for refering to the enemies in combat mode

        //public bool IsSkipped { get; set; } = false;
    }
}
