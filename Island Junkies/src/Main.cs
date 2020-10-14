using Raylib_cs;
using CowEngine;
using System.Numerics;

namespace Island_Junkies
{
    class IslandJunkies
    {
        private static GameWindow game;

        public static void Main()
        {
            game = new GameWindow(new Vector2(800, 480), "Island Junkies", Color.BLACK);

            game.Open();
        }
    }
}
