using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayToHeal.Source
{
    public class Item
    {
        private string name;
        private int level;
        private bool usable;

        public string Name { get { return name; } set { name = value; } }
        public bool Usable { get { return usable; } set { usable = value; } }
        public int Level { get { return level; } }

        // routine de mise a jour à chaque fin de partie

    }
}
