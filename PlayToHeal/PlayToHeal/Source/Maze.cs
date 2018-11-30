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

        public Maze(int height, int weight)
        {
            boardGame = new Cell[height, weight];

            for (int i = 0; i < boardGame.GetLength(0); i++)
            {
                for (int j = 0; j < boardGame.GetLength(1); j++)
                {
                    boardGame[i, j].X = i;
                    boardGame[i, j].Y = j;
                }
            }

            List<Cell> CellsToVisit = null;
            Cell c = ChooseRandomCell(boardGame);
            CellsToVisit.Add(c);    // we add it to our list of visited cells

            boardGame = CreatePathToRandomNeighbor(c, boardGame, CellsToVisit);

        }

        public Cell ChooseRandomCell(Cell[,] boardGame)
        {
            Random rnd = new Random();
            int x = rnd.Next(boardGame.GetLength(0));   //we take a random cell in a board game
            int y = rnd.Next(boardGame.GetLength(1));

            return boardGame[x, y];
        }

        public Cell[,] CreatePathToRandomNeighbor(Cell c, Cell[,] boardGame, List<Cell> CellsToVisit)
        {

            if (CellsToVisit != null)
            {

                bool found_direction = false;

                while (!found_direction)
                {
                    Random rnd = new Random();
                    int direction = rnd.Next(1, 5);   //we choose a random direction for our cell
                    switch (direction)
                    {
                        case 1:
                            if (c.North)    //if the north of the cell is a wall
                            {
                                if (c.X != 0)    //if it is not the extreme north of the plate
                                {
                                    found_direction = true;     //go out of the switch
                                    c.North = false;        //declare it as a path
                                    Cell cNeighbor = boardGame[c.X - 1, c.Y];
                                    CellsToVisit.Add(cNeighbor);    //we add the neighbor to the list
                                    return CreatePathToRandomNeighbor(boardGame[c.X - 1, c.Y], boardGame, CellsToVisit);
                                }
                            }
                            break;

                        case 2:
                            if (c.East)    //if the east of the cell is a wall
                            {
                                if (c.Y != boardGame.GetLength(1))
                                {
                                    found_direction = true;
                                    c.East = false;
                                    Cell cNeighbor = boardGame[c.X, c.Y + 1];
                                    CellsToVisit.Add(cNeighbor);    //we add the neighbor to the list
                                    return CreatePathToRandomNeighbor(cNeighbor, boardGame, CellsToVisit);
                                }

                            }
                            break;

                        case 3:
                            if (c.South)    //if the south of the cell is a wall
                            {
                                if (c.Y != boardGame.GetLength(1))
                                {
                                    found_direction = true;
                                    c.South = false;
                                    Cell cNeighbor = boardGame[c.X + 1, c.Y];
                                    CellsToVisit.Add(cNeighbor);    //we add the neighbor to the list
                                    return CreatePathToRandomNeighbor(cNeighbor, boardGame, CellsToVisit);
                                }
                            }
                            break;

                        case 4:
                            if (c.West)    //if the west of the cell is a wall
                            {
                                if (c.Y != 0)
                                {
                                    found_direction = true;
                                    c.West = false;
                                    Cell cNeighbor = boardGame[c.X, c.Y - 1];
                                    CellsToVisit.Add(cNeighbor);    //we add the neighbor to the list
                                    return CreatePathToRandomNeighbor(cNeighbor, boardGame, CellsToVisit);
                                }
                            }
                            break;

                        default:
                            CellsToVisit.Remove(c);         //delete the actual cell from list
                            c = ChooseRandomCell(boardGame);        //if all path is already taken choose a new random cell
                            return CreatePathToRandomNeighbor(c, boardGame, CellsToVisit);
                    }
                }
                return boardGame; //to make an return access on all part of the code
            }
            else
            {
                return boardGame;//REAL RETURN  
            }
        }
    }
}
