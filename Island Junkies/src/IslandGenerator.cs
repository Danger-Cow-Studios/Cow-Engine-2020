using CowEngine;
using Island_Junkies.obj;

namespace Island_Junkies
{
    class IslandGenerator
    {
        public static Block[,] GenerateIsland(World world)
        {
            Block[,] Resualt = new Block[world.MaxWidth,world.MaxHeight];

            int x = world.CenterZeroToArrayZero(0, 0).Item1;
            int y = world.CenterZeroToArrayZero(0, 0).Item2;

            Block b = new Block(x, y);

            Resualt[x, y] = b;
            GameWindow.MainWindow.StackGameObject(b);

            return Resualt;
        }
    }
}
