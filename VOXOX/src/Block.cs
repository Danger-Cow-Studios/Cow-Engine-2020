using CowEngine;
using Raylib_cs;
using System;
using System.Numerics;

namespace VOXOX
{
    /// <summary>
    /// A single voxel
    /// </summary>
    public class Block : GameObject
    {
        public override void Draw()
        {
            Raylib.DrawRectangle(transform.x, transform.y, 1, 1, Color.RED);
        }

        public Block(Vector2 pos)
        {
            transform.x = (int)pos.X;
            transform.y = (int)pos.Y;
        }
    }
}
