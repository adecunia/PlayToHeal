using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayToHeal.Source
{
    public class Maze
    {
        private Cell[,] boardGame;
        private int seed;

        public Cell[,] BoardGame { get { return boardGame; } set { boardGame = value; } }
        public int Seed { get { return seed; } set { seed = value; } }


        // BoardGame Generation (To do)
        public Cell[,] GenerateBoardGame()
        {
            return boardGame;
        }

        public Cell[,] RandomMazeGeneration(int height, int weight)
        {
            boardGame = new Cell[height, weight];
            List<Cell> VisitedCells;




            return BoardGame;

        }

    }
}
