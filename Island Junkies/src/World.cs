using Island_Junkies.obj;
using Raylib_cs;
using System.Numerics;

namespace Island_Junkies
{
    class World
    {
        public int MaxWidth;
        public int MaxHeight;
        public Camera2D Cam = new Camera2D();

        public Vector2 Size;

        public Block[,] WorldData;

        public void CenterCam(Vector2 windowSize, int x, int y, float zoom)
        {
            Cam.target = io.ScreenToWorld.CameraFocusToWorld(windowSize, Size, new Vector2(x, y), zoom);
            Cam.zoom = zoom;
        }

        public (int, int) CenterZeroToArrayZero(int x, int y)
        {
            return (x + (MaxWidth / 2), y + (MaxHeight / 2));
        }
        public Vector2 CenterZeroToArrayZeroArr(int x, int y)
        {
            return new Vector2(x + (MaxWidth / 2), y + (MaxHeight / 2));
        }

        public World(int maxX, int maxY)
        {
            if (maxX % 2 != 0) maxX++;
            if (maxY % 2 != 0) maxY++;
            
            MaxWidth = maxX;
            MaxHeight = maxY;

            Size = new Vector2(MaxWidth, MaxHeight);

            WorldData = IslandGenerator.GenerateIsland(this);
        }
    }
}
