using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayToHeal.Source
{
    public class Maze
    {
        private char[][] boardGame;
        private int seed;

        public char[][] BoardGame { get { return boardGame; } set { boardGame = value; } }
        public int Seed { get { return seed; } set { seed = value; } }


        // BoardGame Generation (To do)
        public Cell[,] GenerateBoardGame(int h, int w)
        {
            Cell[,] boardGame = new Cell[h, w];
            boardGame = properCellInitialisation(boardGame);

            List<Cell> path = new List<Cell>();

            //Select a random cell
            path.Add(randomCell(boardGame));
            Cell actual = path[0];
            int actualIndex = 0;

            while(!hasNoUnvisitedNb(path[path.Count - 1]))
            {
                path.Add(selectOneUnvisited(actual, boardGame));

                if (hasNoUnvisitedNb(actual))
                {
                    actual = path[actualIndex + 1];
                    actualIndex++;
                }
            }



            return boardGame;
        }

        // Choose random cell
        public Cell randomCell(Cell[,] boardGame)
        {
            Random rnd = new Random();
            int x = rnd.Next(boardGame.GetLength(0));
            int y = rnd.Next(boardGame.GetLength(1));

            return boardGame[x, y];
        }

        public Cell selectOneUnvisited(Cell cell, Cell[,] boardGame)
        {
            int count = 0;

            if(cell.West == false) { count++;  };
            if(cell.East == false) { count++; };
            if(cell.North == false) { count++; };
            if(cell.South == false) { count++; };

            Random rnd = new Random();
            int i = rnd.Next(count);

            switch (i)
            {
                case 0: //Case West
                    cell.West = true;
                    return boardGame[cell.X, cell.Y - 1];
                case 1: //Case East
                    cell.East = true;
                    return boardGame[cell.X, cell.Y + 1];
                case 2: //Case North
                    cell.North = true;
                    return boardGame[cell.X + 1, cell.Y];
                case 3: //Case South
                    cell.South = true;
                    return boardGame[cell.X - 1, cell.Y];
            }

            //Si erreur
            return cell;
        }

        public bool hasNoUnvisitedNb(Cell cell)
        {
            if(cell.West && cell.East && cell.North && cell.South)
            {
                return true;
            }
            return false;
        }

        public Cell[,] properCellInitialisation(Cell[,] board)
        {
            for(int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    //If first row => North unavailable
                    if (i == 0)
                    {
                        board[i, j].North = true;
                    }
                    //If last row => south unavailable
                    if (i == board.GetLength(0))
                    {
                        board[i, j].South = false;
                    }
                    //If first column => West unavailable
                    if (j == 0)
                    {
                        board[i, j].West = true;
                    }
                    //If last colum => East unavailable
                    if(j == board.GetLength(1))
                    {
                        board[i, j].East = true;
                    }

                    //Initialize coordinates
                    board[i, j].X = i;
                    board[i, j].Y = j;
                }
            }

            return board;
        }
    }
}
