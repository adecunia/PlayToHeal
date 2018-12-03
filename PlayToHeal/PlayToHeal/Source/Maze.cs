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

        //Initialize the maze
        // We considered that a non initialized cell is caracterized by its value (-1 = non initialized)
        public void Initialize(int width, int heigh)
        {
            boardGame = new Cell[width, heigh];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < heigh; y++)
                {
                    boardGame[x, y].Value = -1;
                }
            }
        }

        // BoardGame Generation (To do)
        public void GenerateBoardGame()
        {

        }

        public void GenerateMaze_NewestMethod()
        {
            int width = boardGame.GetLength(0);
            int heigh = boardGame.GetLength(1);
            int dimenstion = width * heigh;

            // Initialize the list of unverified visited cells
            int[][] tabUnverifiedVisitedCell = new int[2][];
            int indextab = 0;

            // Choose randomly a cell in the maze
            int[] current_cell = new int[] { width, heigh };
            tabUnverifiedVisitedCell[indextab] = current_cell;

            while(tabUnverifiedVisitedCell.Length > 0)
            {
                current_cell = GetNextCell(tabUnverifiedVisitedCell);
                if(current_cell != tabUnverifiedVisitedCell[indextab])
                {
                    indextab++;
                    tabUnverifiedVisitedCell[indextab] = current_cell;
                }
                else
                {
                    //We passed twice on a cell
                    //the cell is now initialized
                    boardGame[current_cell[0], current_cell[1]].Value = 0;
                    tabUnverifiedVisitedCell[indextab] = null;
                    indextab--;
                }
            }
        }


        //-------------------------------------------------------------------------------------------
        // METHODS IMPLEMENTED FOR THE NEWEST METHOD
        //-------------------------------------------------------------------------------------------

       
        //Get Random Number
        public int GetRandomNumber(double maximum)
        {
            Random random = new Random();
            return (int)(random.NextDouble() * maximum);
        }

        //Put A Wall Methods
        public void PutWallWest(Cell cell)
        {
            cell.West = true;
        }
        public void PutWallNorth(Cell cell)
        {
            cell.North = true;
        }
        public void PutWallEast(Cell cell)
        {
            cell.East = true;
        }
        public void PutWallSouth(Cell cell)
        {
            cell.South = true;
        }
        
        // Get the Next Cell (change to random the way to select the orientation)
        // Verify if there is a need to put a wall ( if so, put one)
        public int[] GetNextCell(int[][] list)
        {
            int[] next_cell = new int[2];
            int[] actual_cell = list.ElementAt(list.Count() - 1);
            int[] last_cell = list.ElementAt(list.Count() - 2);
            int x = actual_cell[0];
            int y = actual_cell[1];

            int[] coordinates = new int[]{x-1,y};
            if (IsInTheList(list, coordinates) && coordinates!=last_cell){
                PutWallWest(boardGame[x, y]);
            }
            else
            {
                if (!IsInitialized(coordinates))
                {
                    next_cell = coordinates;
                }
            }

            coordinates = new int[] { x + 1, y };
            if (IsInTheList(list, coordinates) && coordinates != last_cell)
            {
                PutWallEast(boardGame[x, y]);
            }
            else
            {
                if (!IsInitialized(coordinates))
                {
                    next_cell = coordinates;
                }
            }

            coordinates = new int[] { x , y -1 };
            if (IsInTheList(list, coordinates) && coordinates != last_cell)
            {
                PutWallSouth(boardGame[x, y]);
            }
            else
            {
                if (!IsInitialized(coordinates))
                {
                    next_cell = coordinates;
                }
            }

            coordinates = new int[] { x , y + 1 };
            if (IsInTheList(list, coordinates) && coordinates != last_cell)
            {
                PutWallNorth(boardGame[x, y]);
            }
            else
            {
                if (!IsInitialized(coordinates))
                {
                    next_cell = coordinates;
                }
            }

            return next_cell;

        }
        
        // Verify if a cell is in the list
        public bool IsInTheList(int[][] list, int[] coordinates)
        {
            bool isinthelist = false;
            foreach(int[] coord in list)
            {
                if(coord == coordinates)
                {
                    isinthelist = true;
                }
            }
            return isinthelist;
        }

        // Verify if the cell is already initialized
        public bool IsInitialized(int[] coordinates)
        {
            bool isInitialized = false;
            if(boardGame[coordinates[0],coordinates[1]].Value == 0)
            {
                isInitialized = true;
            }
            return isInitialized;
        }
        

    }
}
