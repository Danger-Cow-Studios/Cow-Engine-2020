using Raylib_cs;
using CowEngine;
using Transform = CowEngine.io.Transform;

namespace Island_Junkies.obj
{
    class Block : GameObject
    {
        public override int Draw()
        {
            Raylib.DrawRectangle(transform.x, transform.y, transform.sx, transform.sy, Color.RED);
            return 1;
        }

        public Block(int x, int y)
        {
            transform = new Transform(x, y, 1, 1);
        }
    }
}
