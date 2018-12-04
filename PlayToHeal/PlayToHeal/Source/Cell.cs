using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayToHeal.Source
{
    public class Cell
    {
        private int value;
        private bool north;
        private bool south;
        private bool west;
        private bool east;
        private int x;
        private int y;

        public int Value { get { return value; } set { this.value = value; } }
        public bool North { get { return north; } set { north = value; } }
        public bool South { get { return south; } set { south = value; } }
        public bool West { get { return west; } set { west = value; } }
        public bool East { get { return east; } set { east = value; } }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public Cell()
        {
            north = true;
            south = true;
            east = true;
            west = true;
        }

    }

}
