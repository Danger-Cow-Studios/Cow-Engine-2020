using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Remoting.Messaging;

namespace CowEngine
{
    //Window and basic game loop of a cow engine game
    public class GameWindow
    {
        #region >----Varibles and settings----<
        //The first constructed window
        public static GameWindow MainWindow;

        //Window settings
        public Vector2 WindowSize;
        public string WindowName;
        public Color WindowBackground;

        //GameControll
        private List<GameObject> MainSceneObjects = new List<GameObject>();
        private List<GameScene> Scenes = new List<GameScene>();

        public GameScene CurrentScene = null;

        public delegate void UpdateCall();
        public UpdateCall Update;
        public delegate void DrawCall();
        public DrawCall Draw;
        #endregion

        #region >----Methods----<

        /// <summary>
        /// Create window and run game
        /// </summary>
        /// <returns>This game window</returns>
        public GameWindow Open()
        {
            //Create window with raylib
            InitWindow((int)WindowSize.X, (int)WindowSize.Y, WindowName);

            //Run gameloop, close gamewindow when finished
            while (!WindowShouldClose()) {
                if (CurrentScene == null) MainSceneGameLoop();
                else CurrentScene.GameLoop();
            }

            CloseWindow();

            return this;
        }

        //>----IO----<
        public GameScene SetCurrentScene(GameScene scn) {
            if (CurrentScene != null && CurrentScene.DeleteWhenUnloaded) Scenes.Remove(CurrentScene);
            CurrentScene = scn;
            if (!Scenes.Contains(scn)) Scenes.Add(scn);

            CurrentScene.Parrent = this;
            CurrentScene.Start();
            return scn; 
        }
        public GameScene RemoveSceneFromStack(GameScene scn) {
            if (CurrentScene == scn) CurrentScene = null;
            Scenes.Remove(scn);
            return scn;
        }
        public GameObject AddObjectToStack(GameObject obj) { MainSceneObjects.Add(obj); return obj; }
        public GameObject DeleteObjectFromStack(GameObject obj) { MainSceneObjects.Remove(obj); return obj; }

        #endregion

        #region >----Virtual methods----<

        //TODO: optimse calls for gameobjects
        public virtual void MainSceneGameLoop()
        {
            //Call update
            Update?.Invoke();
            foreach (GameObject obj in MainSceneObjects) obj.Update();

            //Prepare to draw, call draw then stop drawing
            PrepDraw(WindowBackground);
            Draw?.Invoke();
            foreach (GameObject obj in MainSceneObjects) obj.Draw();
            EndDrawing();
        }

        public virtual void PrepDraw(Color clearColor)
        {
            BeginDrawing();
            ClearBackground(clearColor);
        }

        #endregion

        #region >----Constructors----<

        public GameWindow(Vector2 size, string name, Color backgroundColor, UpdateCall globalUpdate = null, DrawCall globalDraw = null)
        {
            WindowSize = size;
            WindowName = name;
            WindowBackground = backgroundColor;
            Update = globalUpdate;
            Draw = globalDraw;
        }

        #endregion
    }
}
