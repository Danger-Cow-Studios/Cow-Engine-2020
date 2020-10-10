using System;
using Raylib_cs;
using CowEngine;

namespace Island_Junkies
{
    class IslandJunkies
    {
        public static void Main()
        {
            GameWindow game = new GameWindow(800, 480, "Test Game", Update, Draw);
        }

        private static void Update() { }

        private static void Draw()
        {
            Raylib.DrawText("Hello World!", 12, 12, 20, Color.WHITE);
        }
    }
}
