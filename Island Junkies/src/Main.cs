using Raylib_cs;
using CowEngine;
using Island_Junkies.io;
using System.Numerics;

namespace Island_Junkies
{
    class IslandJunkies
    {
        private static GameWindow game;
        private static World gameWorld;

        public static void Main()
        {
            game = new GameWindow(new Vector2(800, 480), "test", Color.BLACK);
            game.Open();
        }

        private static void Update()
        {
            
        }
    }
}
