using System;
using System.Numerics;

namespace VOXOX
{
    public class IslandGenerator
    {
        public virtual void GenerateIsland(VoxleWorld world)
        {
            Block b = new Block(world.CenterToZero(new Vector2(0, 0)));

            world.AddBlock(b);
        }
    }
}
