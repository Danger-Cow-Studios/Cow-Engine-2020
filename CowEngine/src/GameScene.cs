using Raylib_cs;
using System.Collections.Generic;
using System.Data;
using static Raylib_cs.Raylib;

namespace CowEngine
{
    public class GameScene
    {
        #region >----Varibles and settings----<
        //GameWindow that holds this scene
        public GameWindow Parrent;

        //Scene settings
        public Color SceneBackground;

        //Scene controll
        private List<GameObject> Objects = new List<GameObject>();
        public bool DeleteWhenUnloaded = true;
        #endregion

        #region >----Methods----<
        public GameObject AddObjectToStack(GameObject obj) { Objects.Add(obj); return obj; }
        public GameObject DeleteObjectFromStack(GameObject obj) { Objects.Remove(obj); return obj; }
        #endregion

        #region >----Virutal methods----<
        //TODO: optimse calls for gameobjects
        public virtual void GameLoop()
        {
            //Call update
            Update();
            foreach (GameObject obj in Objects) obj.Update();

            //Prepare to draw, call draw then stop drawing
            Parrent.PrepDraw(SceneBackground);
            Draw();
            foreach (GameObject obj in Objects) obj.Draw();
            EndDrawing();
        }

        public virtual void Start() { }

        public virtual void Update() { }

        public virtual void Draw() { }
        #endregion

        #region >----Constructors----<
        public GameScene(bool deleteWhenUnloaded = true)
        {
            DeleteWhenUnloaded = deleteWhenUnloaded;
        }
        #endregion
    }
}
