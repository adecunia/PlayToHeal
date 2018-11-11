using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayToHeal.Source
{
    public class Account
    {
        private int id;
        private string name;
        private List<Game> games;
        private int world;

        public Account(int id, string name, List<Game> games, int world)
        {
            this.id = id;
            this.name = name;
            this.games = games;
            this.world = world;
        }

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public List<Game> Games { get { return games; } set { games = value; } }
        public int World { get { return world; } set { world = value; } }

        public void AddGame(Game game)
        {
            games.Add(game);
        }
    }
}
