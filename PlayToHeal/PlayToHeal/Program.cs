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
            Maze m = new Maze(5, 5);
            Console.WriteLine("Maze ok\n");
            Console.WriteLine(m.toString());
            Console.ReadKey();

            /*using (Game1 game = new Game1())
            {
                game.Run();
            }*/
        }
    }
#endif
}

