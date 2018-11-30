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

        public int Value { get { return value; } set { this.value = value; } }
        public bool North { get { return north; } set { north = value; } }
        public bool South { get { return south; } set { south = value; } }
        public bool West { get { return west; } set { west = value; } }
        public bool East { get { return east; } set { east = value; } }

        public Cell()
        {
            north = true;
            south = true;
            east = true;
            west = true;
        }
    }

}
