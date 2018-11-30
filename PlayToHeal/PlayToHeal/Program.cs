using PlayToHeal.Source;
using System;

namespace PlayToHeal
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            Maze m = new Maze(10, 10);
            

            /*using (Game1 game = new Game1())
            {
                game.Run();
            }*/
        }
    }
#endif
}

