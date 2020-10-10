using Raylib_cs;
using System;

namespace CowEngine
{
    public class GameWindow
    {
        public int Width, Height;
        public string Name;

        public Color ClearColor;

        public delegate void Update();
        public Update UpdateCall;
        public delegate void Draw();
        public Draw DrawCall;

        private void ConstructWindow()
        {
            Raylib.InitWindow(Width, Height, Name);

            //Game loop
            while (!Raylib.WindowShouldClose())
            {
                //Call update event
                UpdateCall();

                //Call draw event
                Raylib.BeginDrawing();
                Raylib.ClearBackground(ClearColor);

                DrawCall();

                Raylib.EndDrawing();
            }
        }

        public GameWindow(int width, int height, string name, Update updateCall, Draw drawCall, Color clearColor)
        {
            Width = width;
            Height = height;
            Name = name;
            ClearColor = clearColor;

            UpdateCall = updateCall;
            DrawCall = drawCall;

            ConstructWindow();
        }

        public GameWindow(int width, int height, string name, Update updateCall, Draw drawCall)
        {
            Width = width;
            Height = height;
            Name = name;
            ClearColor = Color.BLACK;

            UpdateCall = updateCall;
            DrawCall = drawCall;

            ConstructWindow();
        }
    }
}
