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
            game = new GameWindow(800, 480, "Island Junkies", null, Update);
            gameWorld = new World(1000, 256);

            game.Construct();
            game.SetCam(gameWorld.Cam);
        }

        private static void Update()
        {
            gameWorld.CenterCam(game.Size, 0, 0, 40);
            game.SetCam(gameWorld.Cam);
        }
    }
}
