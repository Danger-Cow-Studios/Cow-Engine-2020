using Raylib_cs;
using CowEngine;
using System.Numerics;
using VOXOX;

namespace Island_Junkies
{
    class IslandJunkies
    {
        private static GameWindow game;

        public static void Main()
        {
            game = new GameWindow(new Vector2(800, 480), "Island Junkies", Color.BLACK);
            VoxleWorld test = new VoxleWorld(1000, 255);

            game.SetCurrentScene(test);

            game.Open();
        }
    }
}
