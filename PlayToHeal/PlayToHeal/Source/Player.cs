using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayToHeal.Source
{
    public class Player
    {
        private int level;
        private Position position;
        private List<Item> inventory;

        public int Level { get { return level; } }
        public Position Position { get { return position; } set { position = value; }  }
        public List<Item> Inventory { get { return inventory; } }

        public void LevelUp() { level++; }
        public void AddInventory(Item item) { inventory.Add(item); }

        // mise à jour à la fin d'une partie
    }
}
