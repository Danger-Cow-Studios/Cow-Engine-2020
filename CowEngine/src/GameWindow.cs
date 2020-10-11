using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Collections.Generic;
using System.Numerics;

namespace CowEngine
{
    //Window and basic game loop of a cow engine game

    public class GameWindow
    {
        public static GameWindow MainWindow;

        public int Width, Height;
        public string Name;

        public Camera2D cam;
        public bool UseCam = false;
        public Vector2 Size;

        public Color ClearColor;

        public delegate void Update();
        public Update UpdateCall;
        public delegate void Draw();
        public Draw DrawCall;

        private List<GameObject> objects = new List<GameObject>();

        public void Construct()
        {
            Raylib.InitWindow(Width, Height, Name);

            Size = new Vector2(Width, Height);

            //Game loop
            while (!Raylib.WindowShouldClose())
            {
                //Call update event
                foreach (GameObject obj in objects) { obj.Update(); }
                UpdateCall?.Invoke();

                //Call draw event
                Raylib.BeginDrawing();
                Raylib.ClearBackground(ClearColor);
                if (UseCam) BeginMode2D(cam);

                foreach (GameObject obj in objects) { obj.Draw(); }
                DrawCall?.Invoke();

                Raylib.EndDrawing();
            }
        }

        public void SetCam(Camera2D cam)
        {
            this.cam = cam;
            UseCam = true;
        }

        public GameObject StackGameObject(GameObject obj)
        {
            if (MainWindow == null) MainWindow = this;

            objects.Add(obj);
            return obj;
        }

        public GameWindow(int width, int height, string name, Update updateCall, Draw drawCall, Color clearColor)
        {
            if (MainWindow == null) MainWindow = this;

            Width = width;
            Height = height;
            Name = name;
            ClearColor = clearColor;

            UpdateCall = updateCall;
            DrawCall = drawCall;
        }

        public GameWindow(int width, int height, string name, Update updateCall, Draw drawCall)
        {
            if (MainWindow == null) MainWindow = this;

            Width = width;
            Height = height;
            Name = name;
            ClearColor = Color.BLACK;

            UpdateCall = updateCall;
            DrawCall = drawCall;
        }

        public GameWindow(int width, int height, string name)
        {
            if (MainWindow != null) MainWindow = this;

            Width = width;
            Height = height;
            Name = name;
            ClearColor = Color.BLACK;
        }
    }
}
