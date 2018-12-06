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

            boardGame = GenerateBoardGame();
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

        public Cell[,] GenerateBoardGame()
        {
            List<Cell> VisitingCells = new List<Cell>();
            Cell c = ChooseRandomCellOnBoardGame(boardGame);
            VisitingCells.Add(c);
            c.Visited = true;

            while (VisitingCells.Count != 0)
            {
                Console.Clear();
                Console.WriteLine(toString());
                Console.ReadKey();

                if (!fullyVisited(c, boardGame))
                {
                    Random rnd = new Random();
                    int direction = rnd.Next(1, 5);   //we choose a random direction for our path

                    switch (direction)
                    {
                        case 1:

                            if (c.North && c.X != 0)    //if the north of the cell is a wall and  //if it is not the extreme north of the plate
                            {
                                Cell NorthCell = boardGame[c.X - 1, c.Y];

                                if (NorthCell.Visited == false)
                                {
                                    c.North = false;        //declare it as a path
                                    VisitingCells.Add(NorthCell);    //we add the neighbor to the list
                                    NorthCell.South = false;    //we define the opposite direction of our cell as a path
                                    NorthCell.Visited = true;
                                }

                                c = ChooseRandomCellonListCell(VisitingCells);   //choose a random cell from the list to start again
                            }
                            else
                            {
                                Random choice = new Random();
                                int changedirection = rnd.Next(1, 4);

                                if (changedirection == 1)
                                {
                                    goto case 2;        //if it the extreme north go to east
                                }
                                else
                                {
                                    if (changedirection == 2)
                                    {
                                        goto case 3;
                                    }
                                    else
                                    {
                                        goto case 4;    //else go to west
                                    }

                                }
                            }
                            break;

                        case 2:

                            if (c.East && c.Y != boardGame.GetLength(1) - 1)    //if the east of the cell is a wall
                            {
                                Cell EastCell = boardGame[c.X, c.Y + 1];
                                if (EastCell.Visited == false)
                                {
                                    c.East = false;
                                    VisitingCells.Add(EastCell);    //we add the neighbor to the list
                                    EastCell.Visited = true;
                                    EastCell.West = false;
                                }

                                c = ChooseRandomCellonListCell(VisitingCells);   //choose a random cell from the list to start again


                            }
                            else
                            {
                                int changedirection = rnd.Next(1, 4);

                                if (changedirection == 1)
                                {
                                    goto case 1;        //if it the extreme north go to east
                                }
                                else
                                {
                                    if (changedirection == 2)
                                    {
                                        goto case 3;
                                    }
                                    else
                                    {
                                        goto case 4;    //else go to west
                                    }
                                }
                            }
                            break;

                        case 3:

                            if (c.South && c.X != boardGame.GetLength(0) - 1)    //if the south of the cell is a wall
                            {
                                Cell SouthCell = boardGame[c.X + 1, c.Y];

                                if (SouthCell.Visited == false)
                                {

                                    c.South = false;
                                    VisitingCells.Add(SouthCell);    //we add the neighbor to the list
                                    SouthCell.Visited = true;
                                    SouthCell.North = false;
                                }

                                c = ChooseRandomCellonListCell(VisitingCells);   //choose a random cell from the list to start again


                            }
                            else
                            {
                                int changedirection = rnd.Next(1, 4);

                                if (changedirection == 1)
                                {
                                    goto case 1;        //if it the extreme north go to east
                                }
                                else
                                {
                                    if (changedirection == 2)
                                    {
                                        goto case 2;
                                    }
                                    else
                                    {
                                        goto case 4;    //else go to west
                                    }
                                }
                            }
                            break;

                        case 4:

                            if (c.West && c.Y != 0)    //if the west of the cell is a wall
                            {
                                Cell WestCell = boardGame[c.X, c.Y - 1];
                                if (WestCell.Visited == false)
                                {
                                    c.West = false;
                                    VisitingCells.Add(WestCell);    //we add the neighbor to the list
                                    WestCell.Visited = true;
                                    WestCell.East = false;
                                }

                                c = ChooseRandomCellonListCell(VisitingCells);   //choose a random cell from the list to start again


                            }
                            else
                            {
                                int changedirection = rnd.Next(1, 4);

                                if (changedirection == 1)
                                {
                                    goto case 1;        //if it the extreme north go to east
                                }
                                else
                                {
                                    if (changedirection == 2)
                                    {
                                        goto case 2;
                                    }
                                    else
                                    {
                                        goto case 3;    //else go to west
                                    }
                                }
                            }
                            break;
                    }
                }
                else
                {
                    VisitingCells.Remove(c);
                    if (VisitingCells.Count != 0)
                    {
                        c = ChooseRandomCellonListCell(VisitingCells);
                    }
                }
            }

            return boardGame;
        }

        public bool fullyVisited(Cell cell, Cell[,] board)
        {
            int boardWidth = board.GetLength(0) - 1;
            int boardHeigth = board.GetLength(1) - 1;

            if (cell.X != 0) //N'est pas sur la première ligne (North indisp)
            {
                if (!board[cell.X - 1, cell.Y].Visited)
                {
                    return false;
                }
            }
            if (cell.X != boardHeigth) //N'est pas sur la dernière ligne (South indisp)
            {
                if (!board[cell.X + 1, cell.Y].Visited)
                {
                    return false;
                }
            }
            if (cell.Y != 0) //N'est pas sur la première colonne (West indisp)
            {
                if (!board[cell.X, cell.Y - 1].Visited)
                {
                    return false;
                }
            }
            if (cell.Y != boardWidth) //N'est pas sur la dernière colonne (East indisp)
            {
                if (!board[cell.X, cell.Y + 1].Visited)
                {
                    return false;
                }
            }

            return true;
        }


        public string toString()
        {
            string maze = "";

            for (int i = 0; i < boardGame.GetLength(0); i++)
            {
                for (int j = 0; j < boardGame.GetLength(1); j++)
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
                maze += "\n";

                for (int j = 0; j < boardGame.GetLength(1); j++)
                {

                    if (boardGame[i, j].West && boardGame[i, j].East)
                    {
                        maze += "[ ]";
                    }
                    else
                    {
                        if (boardGame[i, j].West && !boardGame[i, j].East)
                        {
                            maze += "[  ";

                        }
                        else
                        {
                            if (boardGame[i, j].East && !boardGame[i, j].West)
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
                maze += "\n";

                for (int j = 0; j < boardGame.GetLength(1); j++)
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
                maze += "\n";
            }
            return maze;
        }
    }
}
