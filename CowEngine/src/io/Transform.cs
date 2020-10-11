using System;

namespace CowEngine.io
{
    public struct Transform
    {
        public int x, y;
        public int sx, sy;

        public Transform(int x, int y, int sx, int sy)
        {
            this.x = x;
            this.y = y;
            this.sx = sx;
            this.sy = sy;
        }
    }
}
