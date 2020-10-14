using Raylib_cs;
using CowEngine.io;
using System.Numerics;

namespace CowEngine
{
    public class GameObject
    {
        public Vector2 position;

        public GameObject() { }

        public GameObject(int x, int y)
        {
            position = new Vector2(x, y);
        }

        public virtual void Update() { }
        public virtual void Draw() { }
    }
}
