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
            boardGame = GenerateBoardGame(height, weight);
        }

        // BoardGame Generation (To do)
        public Cell[,] GenerateBoardGame(int h, int w)
        {
            Cell[,] board = new Cell[h, w];

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = new Cell();
                    board[i, j].X = i;
                    board[i, j].Y = j;
                }
            }

            List<Cell> path = new List<Cell>();

            Cell actual = randomCell(board);
            actual.Visited = true;
            path.Add(actual);

            while (path.Count != 0)
            {
                //On vérifie si la cellule n'est pas "entièrement" visitée i.e que tous ses voisins n'ont pas été visités
                if (fullyVisited(actual, board))
                {
                    path.RemoveAt(0);
                }
                //Méthode oldest => On travaille tjs sur la plus vielle cellule visitée
                else
                {
                    actual = path[0];

                    //On choisit une direction (parmis les dispo) aléatoire
                    Cell nextCell = selectOneUnvisited(actual, board);
                    path.Add(nextCell);
                }

            }


            return board;
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

        // Choose random cell
        public Cell randomCell(Cell[,] boardGame)
        {
            Random rnd = new Random();
            int x = rnd.Next(boardGame.GetLength(0));
            int y = rnd.Next(boardGame.GetLength(1));

            return boardGame[x, y];
        }

        public Cell selectOneUnvisited(Cell cell, Cell[,] board)
        {
            Random rnd = new Random();
            int direction = rnd.Next(1, 5);
            Cell defaultCell = new Cell();

            switch (direction)
            {
                case 1:
                    if (cell.North && cell.X != 0)    //if the north of the cell is a wall
                    {
                        cell.North = false; //on fait tomber le mur nord
                        Cell newCell = board[cell.X - 1, cell.Y];
                        newCell.South = false; //On fait tomber le mur sud de la cell nord
                        return newCell;
                        
                    }
                    else
                    {
                        Random choice = new Random();
                        int changedirection = rnd.Next(1, 4);
                        if (changedirection == 1)
                        {
                            goto case 2;        //if it the extreme north go to east
                        }
                        if (changedirection == 2)
                        {
                            goto case 3;    //else go to west
                        }
                        if (changedirection == 3)
                        {
                            goto case 4;
                        }
                    }
                    break;
                case 2:
                    if (cell.East && cell.Y != board.GetLength(1) - 1)    //if the east of the cell is a wall
                    {
                        cell.East = false; 
                        Cell newCell = board[cell.X, cell.Y + 1];
                        newCell.West = false;
                        return newCell;
                    }
                    else
                    {
                        Random choice = new Random();
                        int changedirection = rnd.Next(1, 4);
                        if (changedirection == 1)
                        {
                            goto case 1;        //if it the extreme north go to east
                        }
                        if (changedirection == 2)
                        {
                            goto case 3;    //else go to west
                        }
                        if (changedirection == 3)
                        {
                            goto case 4;
                        }
                    }
                    break;
                case 3:
                    if (cell.South && cell.X != board.GetLength(0) - 1)    //if the south of the cell is a wall
                    {
                        cell.South = false;
                        Cell newCell = board[cell.X - 1, cell.Y];
                        newCell.North = false;
                        return newCell;
                    }
                    else
                    {
                        Random choice = new Random();
                        int changedirection = rnd.Next(1, 4);
                        if (changedirection == 1)
                        {
                            goto case 1;        //if it the extreme north go to east
                        }
                        if (changedirection == 2)
                        {
                            goto case 2;    //else go to west
                        }
                        if (changedirection == 3)
                        {
                            goto case 4;
                        }
                    }
                    break;

                case 4:
                    if (cell.West && cell.Y != 0)    //if the west of the cell is a wall
                    {
                        cell.West = false;
                        Cell newCell = board[cell.X, cell.Y - 1];
                        newCell.East = false;
                        return newCell;
                    }
                    else
                    {
                        Random choice = new Random();
                        int changedirection = rnd.Next(1, 4);
                        if (changedirection == 1)
                        {
                            goto case 1;        //if it the extreme north go to east
                        }
                        if (changedirection == 2)
                        {
                            goto case 2;    //else go to west
                        }
                        if (changedirection == 3)
                        {
                            goto case 3;
                        }
                    }
                    break;
            }

            return defaultCell;
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
