using Raylib_cs;
using CowEngine.io;

namespace CowEngine
{
    //Repetable and simpler objects for a cow engine game

    public class GameObject
    {
        public io.Transform transform = new io.Transform(0, 0, 1, 1);

        public GameObject() { }

        public GameObject(int x, int y, int sx, int sy)
        {
            transform = new io.Transform(x, y, sx, sy);
        }

        public virtual int Update() { return 1; }
        public virtual int Draw() { return 1; }
    }
}
