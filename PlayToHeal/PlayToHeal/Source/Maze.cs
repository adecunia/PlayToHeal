using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayToHeal.Source
{
    public class Maze
    {
        private int[,] boardGame;
        private int seed;

        public int[,] BoardGame { get { return boardGame; } set { boardGame = value; } }
        public int Seed { get { return seed; } set { seed = value; } }


        // BoardGame Generation (To do)
        public int[,] GenerateBoardGame()
        {
            return boardGame;
        }
    }
}
