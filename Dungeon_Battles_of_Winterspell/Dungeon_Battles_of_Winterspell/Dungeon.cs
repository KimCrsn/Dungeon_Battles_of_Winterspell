using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell
{
    public enum CurrentDungeon
    {
        // make enumerable list of dungeons, that way the state will be saved as current dungeon and just scroll through to the
    }
    public class Dungeon
    {
        public CurrentDungeon CurrentDungeon { get; set; }
        public int RoomCount { get; set; } = 10;


        /// <summary>
        /// Generates a dictionary of ints 1 - 5 and a new dungeon per element.
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, Dungeon> GenerateDungeons()
        {
            Dictionary<int, Dungeon> dungeons = new Dictionary<int, Dungeon>();
            for (int i = 1; i < 6; i++)
            {
                dungeons[i] = new Dungeon();
            }
            return dungeons;
        }

        //public Dictionary<int, Dungeon> NewDungeon (CurrentDungeon currDungeon)
        //{
            
        //}

    }
}
