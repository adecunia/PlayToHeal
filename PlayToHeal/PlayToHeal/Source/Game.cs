using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayToHeal.Source
{
    public class Game
    {
        private int progression;
        private Maze maze;
        private Player player;
        private int time;

        public int Progression { get { return progression; } set { progression = value; } }
        public Maze Maze { get { return maze; } set { maze = value; } }
        public Player Player { get { return player; } set { player = value; } }
        public int Time { get { return time; } set { time = value; } }

        // mise a jour à la fin d'une partie
    }
}
