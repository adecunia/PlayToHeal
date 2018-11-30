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
            List<Cell> CellsToVisit = null;

            CellsToVisit.Add(ChooseRandomCell(boardGame));    // we add it to our list of visited cells

            while (CellsToVisit != null)
            {

            }


            return BoardGame;

        }

        public Cell ChooseRandomCell(Cell[,] boardGame)
        {
            Random rnd = new Random();
            int x = rnd.Next(boardGame.GetLength(0));   //we take a random cell in a board game
            int y = rnd.Next(boardGame.GetLength(1));

            return boardGame[x, y];
        }

        public void CreatePathToRandomNeighbor(Cell c, Cell[,] boardGame,List<Cell> CellsToVisit)
        {
            bool found_direction = false;
            while (!found_direction)
            {
                Random rnd = new Random();
                int direction = rnd.Next(1,5);   //we choose a random direction for our cell
                switch (direction)
                {
                    case 1: 
                        if(c.North)    //if the north of the cell is a wall
                        {
                            found_direction = true;
                        }
                        break;

                    case 2:
                        if (c.East)    //if the north of the cell is a wall
                        {
                            found_direction = true;
                        }
                        break;

                    case 3:
                        if (c.South)    //if the north of the cell is a wall
                        {
                            found_direction = true;
                        }
                        break;

                    case 4:
                        if (c.West)    //if the north of the cell is a wall
                        {
                            found_direction = true;
                        }
                        break;

                    default:
                        c = ChooseRandomCell(boardGame);        //if all path is already taken choose a new random cell
                        break;

                }
            }

            

        }

    }
}
