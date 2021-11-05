using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dungeon_Battles_of_Winterspell
{
    public class Room
    {
        /// <summary>
        /// Returns a list of new EnemyCharacters which are randomized, and the amount of enemies in the list is rng between 1 and 4 inclusive. This will be taken in for queing purposes.
        /// This should be called once the game state is new room, as enemies must be spawned in it. characters represents enemies spawned and the addition of the player character.
        /// </summary>
        /// <returns></returns>
        public ICollection<ICharacter> SpawnedEnemies(PlayerCharacter player) // This will only occur when a new room is entered. Taking in player purely for the purpose of passing into next method.
        {
            List<ICharacter> characters = new List<ICharacter>(); // Empty list to add spawened enemies to.
            Random rnd = new Random();
            int rngNum = rnd.Next(1, 6);  // creates a number between 1 and 5 inclusive. Only want 4 enemies to appear MAX.
            for (int i = 0; i < rngNum; i++)
            {
                characters.Add(new EnemyCharacter()); // This enemy should be random
            }
            characters.Add(player); // Throw the player into the list.
            TurnBasedQueue(characters); // Passing the list of rng enemies into the turn queue.
            return characters;
        }

        /// <summary>
        /// The turnQueue returns a queue, which represents the order in which characters can have their turn in turn-based combat.
        /// Takes a list of enemies that spawened in a room (randomly generated type and quantity - 1-4), and the player, it generates first a list which is randomized. Then a queue is created adding first characters it sees which have swiftness.
        /// characters is not a list of enenmies or player specifically, it is the combination of both where their similarities are that they are both characters and can have swiftness.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemiesToFight"></param>
        /// <returns></returns>
        public Queue<ICharacter> TurnBasedQueue(ICollection<ICharacter> characters) // Expect to take a rng load of enemies, return them. Equate them to a list and then add them into a queue along with the character.
        {
            Queue<ICharacter> turnQueue = new Queue<ICharacter>(); // to return
            List<ICharacter> charactersToAdd = new List<ICharacter>(); // empty list of characters without swiftness, to be added into the queue after the swift characters are added.

            // First randomize the list, so radomizing does not need done after the queuing process.
            Random random = new Random();
            characters.OrderBy(i => random.Next());

            // Second, add the queue first players which have swiftness.
            foreach (ICharacter character in characters)
            {
                // Check for which characters have swiftness. Add to the queue first randomly.
                if (character.HasSwiftness)
                {
                    turnQueue.Enqueue(character); // add current character to the queue.
                }
                else
                {
                    charactersToAdd.Add(character);
                }
            }

            // Add the remaining
            foreach (ICharacter character in charactersToAdd)
            {
                turnQueue.Enqueue(character);
            }

            return turnQueue;
        }
    }
}
