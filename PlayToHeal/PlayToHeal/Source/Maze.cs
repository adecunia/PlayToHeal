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
                    boardGame[i, j] = new Cell();
                    boardGame[i, j].X = i;
                    boardGame[i, j].Y = j;
                }
            }

            List<Cell> CellsToVisit = new List<Cell>();
            Cell c = ChooseRandomCellOnBoardGame(boardGame);
            CellsToVisit.Add(c);    // we add it to our list of visited cells

            boardGame = CreatePathToRandomNeighbor(c, boardGame, CellsToVisit);

        }

        public Cell ChooseRandomCellOnBoardGame(Cell[,] boardGame)
        {
            Random rnd = new Random();
            int x = rnd.Next(1, boardGame.GetLength(0) - 1);   //we take a random cell in a board game
            int y = rnd.Next(1, boardGame.GetLength(1) - 1);

            return boardGame[x, y];
        }

        public Cell ChooseRandomCellonListCell(List<Cell> VisitedCell)
        {
            Random rnd = new Random();
            if (VisitedCell.Count > 1)
            {
                int index = rnd.Next(1, VisitedCell.Count);
                return VisitedCell[index];
            }//we take a random cell in our list of cell
            else
            {
                return VisitedCell.First();
            }

        }

        public Cell[,] CreatePathToRandomNeighbor(Cell c, Cell[,] boardGame, List<Cell> CellsToVisit)
        {

            bool found_direction = false;

            Random rnd = new Random();
            int direction = rnd.Next(1, 5);   //we choose a random direction for our path
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
                            c = ChooseRandomCellonListCell(CellsToVisit);   //choose a random cell from the list to start again
                            return CreatePathToRandomNeighbor(c, boardGame, CellsToVisit);
                        }
                        else
                        {
                            Random choice = new Random();
                            int changedirection = rnd.Next(1, 3);
                            if(changedirection==1)
                            {
                                goto case 2;        //if it the extreme north go to east
                            }
                            else
                            {
                                goto case 4;    //else go to west
                            }  
                        }
                    }
                    break;

                case 2:
                    if (c.East)    //if the east of the cell is a wall
                    {
                        if (c.Y != boardGame.GetLength(1) - 1)
                        {
                            found_direction = true;
                            c.East = false;
                            Cell cNeighbor = boardGame[c.X, c.Y + 1];
                            CellsToVisit.Add(cNeighbor);    //we add the neighbor to the list
                            c = ChooseRandomCellonListCell(CellsToVisit);   //choose a random cell from the list to start again
                            return CreatePathToRandomNeighbor(c, boardGame, CellsToVisit);
                        }
                        else
                        {
                            Random choice = new Random();
                            int changedirection = rnd.Next(1, 3);
                            if (changedirection == 1)
                            {
                                goto case 1;        //if it the extreme north go to north
                            }
                            else
                            {
                                goto case 3;    //go to south
                            }
                        }
                    }
                    break;

                case 3:
                    if (c.South)    //if the south of the cell is a wall
                    {
                        if (c.X != boardGame.GetLength(0) - 1)
                        {
                            found_direction = true;
                            c.South = false;
                            Cell cNeighbor = boardGame[c.X + 1, c.Y];
                            CellsToVisit.Add(cNeighbor);    //we add the neighbor to the list
                            c = ChooseRandomCellonListCell(CellsToVisit);   //choose a random cell from the list to start again
                            return CreatePathToRandomNeighbor(c, boardGame, CellsToVisit);
                        }
                        else
                        {
                            Random choice = new Random();
                            int changedirection = rnd.Next(1, 3);
                            if (changedirection == 1)
                            {
                                goto case 2;        //if it the extreme north go to east
                            }
                            else
                            {
                                goto case 4;    //else go to west
                            }
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
                            c = ChooseRandomCellonListCell(CellsToVisit);   //choose a random cell from the list to start again
                            return CreatePathToRandomNeighbor(c, boardGame, CellsToVisit);
                        }
                        else
                        {
                            Random choice = new Random();
                            int changedirection = rnd.Next(1, 3);
                            if (changedirection == 1)
                            {
                                goto case 1;        //if it the extreme north go to north
                            }
                            else
                            {
                                goto case 3;    //go to south
                            }
                        }
                    }
                    break;

            }

            if (!found_direction)
            {
                if(VisitedNeighbor(c,boardGame,CellsToVisit))   //if all the neigborhood of the cell has been visited
                {
                    CellsToVisit.Remove(c);
                    if (CellsToVisit.Count != 0)
                    {
                        c = ChooseRandomCellonListCell(CellsToVisit);
                        return CreatePathToRandomNeighbor(c, boardGame, CellsToVisit);
                    }
                    else
                    {
                        return boardGame;
                    }
                }

                else
                {
                    return CreatePathToRandomNeighbor(c, boardGame, CellsToVisit); //same operation with other direction
                }

            }
            return boardGame; //to make an return access on all part of the code

        }

        public bool VisitedNeighbor(Cell c, Cell[,] boardGame,List<Cell> CellTovisit)   //check if all the neigborhood of a cell was already visited
        {
             if(c.X!=0 && c.X!=boardGame.GetLength(0)-1 && c.Y!=0 && c.Y!=boardGame.GetLength(1) - 1)
            {
                if (CellTovisit.Contains(boardGame[c.X + 1, c.Y]) && CellTovisit.Contains(boardGame[c.X - 1, c.Y]) && CellTovisit.Contains(boardGame[c.X, c.Y - 1]) && CellTovisit.Contains(boardGame[c.X, c.Y + 1]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else
            {
                if(c.X==0)
                {
                    if(c.Y==0)
                    {
                        if (CellTovisit.Contains(boardGame[c.X + 1, c.Y]) && CellTovisit.Contains(boardGame[c.X, c.Y + 1]))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if(c.Y != boardGame.GetLength(1) - 1)
                        {
                            if (CellTovisit.Contains(boardGame[c.X + 1, c.Y]) && CellTovisit.Contains(boardGame[c.X, c.Y - 1]))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (CellTovisit.Contains(boardGame[c.X + 1, c.Y]) && CellTovisit.Contains(boardGame[c.X, c.Y - 1]) && CellTovisit.Contains(boardGame[c.X, c.Y + 1]))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }

                if(c.X == boardGame.GetLength(0)-1)
                {
                    if(c.Y==0)
                    {
                        if (CellTovisit.Contains(boardGame[c.X - 1, c.Y]) && CellTovisit.Contains(boardGame[c.X, c.Y + 1]))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    else
                    {
                        if(c.Y == boardGame.GetLength(1)-1)
                        {
                            if (CellTovisit.Contains(boardGame[c.X - 1, c.Y]) && CellTovisit.Contains(boardGame[c.X, c.Y - 1]))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (CellTovisit.Contains(boardGame[c.X - 1, c.Y]) && CellTovisit.Contains(boardGame[c.X, c.Y - 1]) && CellTovisit.Contains(boardGame[c.X, c.Y + 1]))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }

                if(c.Y==0)
                {
                    if(c.X!=0 && c.X!=boardGame.GetLength(0)-1)
                    {
                        if (CellTovisit.Contains(boardGame[c.X + 1, c.Y]) && CellTovisit.Contains(boardGame[c.X - 1, c.Y]) && CellTovisit.Contains(boardGame[c.X, c.Y + 1]))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

                if(c.Y == boardGame.GetLength(1) - 1)
                {
                    if (c.X != 0 && c.X != boardGame.GetLength(0) - 1)
                    {
                        if (CellTovisit.Contains(boardGame[c.X + 1, c.Y]) && CellTovisit.Contains(boardGame[c.X - 1, c.Y]) && CellTovisit.Contains(boardGame[c.X, c.Y - 1]))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;           //for all path returned
        }

        public string toString()
        {
            string maze = "";

            for (int i = 0; i < boardGame.GetLength(0); i++)
            {
                for (int j = 0; j < boardGame.GetLength(1); j++)
                {
                    if (j != boardGame.GetLength(1) - 1)
                    {
                        if (boardGame[i, j].North)
                        {
                            maze += " _ ";
                        }
                        else
                        {
                            maze += "   ";
                        }
                    }

                    else
                    {
                        maze += "\n";
                    }
                }

                for (int j = 0; j < boardGame.GetLength(1); j++)
                {
                    if (j != boardGame.GetLength(1) - 1)
                    {
                        if (boardGame[i, j].West && boardGame[i, j].East)
                        {
                            maze += "[ ]";
                        }
                        else
                        {
                            if (boardGame[i, j].West)
                            {
                                maze += "[  ";

                            }
                            else
                            {
                                if (boardGame[i, j].East)
                                {
                                    maze += "  ]";
                                }
                                else
                                {
                                    maze += "   ";
                                }
                            }
                        }
                    }

                    else
                    {
                        maze += "\n";
                    }

                }

                for (int j = 0; j < boardGame.GetLength(1); j++)
                {
                    if (j != boardGame.GetLength(1) - 1)
                    {
                        if (boardGame[i, j].South)
                        {
                            maze += " ═ ";
                        }
                        else
                        {
                            maze += "   ";
                        }
                    }

                    else
                    {
                        maze += "\n";
                    }
                }

            }
            return maze;
        }
    }
}
