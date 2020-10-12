using CowEngine;
using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace VOXOX
{
    /// <summary>
    /// GameScene that has a customizable voxel world in it by default
    /// </summary>
    public class VoxleWorld : GameScene
    {
        public Vector2 MaxDimentions;
        private Camera2D Camera = new Camera2D();

        public Block[,] WorldData;
        private IslandGenerator WorldGenerator = new IslandGenerator();

        public override void Start()
        {
            WorldGenerator.GenerateIsland(this);
        }

        public override void Update()
        {
            Camera.target = FocusCameraToCenterCords(new Vector2(0, 0), 30);
            Camera.zoom = 30;
        }

        public override void PrepDraw(Color clearColor)
        {
            BeginDrawing();
            ClearBackground(clearColor);
            BeginMode2D(Camera);
        }

        public VoxleWorld(int WorldWidth, int WorldHeight, IslandGenerator gen = null)
        {
            MaxDimentions = new Vector2(WorldWidth, WorldHeight);
            WorldData = new Block[WorldWidth, WorldHeight];

            if (gen != null) WorldGenerator = gen;
        }

        #region IO
        public Block AddBlock(Block b)
        {
            if (WorldData[b.transform.x, b.transform.y] != null) DeleteObjectFromStack(WorldData[b.transform.x, b.transform.y]);
            WorldData[b.transform.x, b.transform.y] = b;
            AddObjectToStack(b);

            return b;
        }

        /// <summary>
        /// Calculate transform needed to focus on something in center anchored cordinates
        /// </summary>
        /// <param name="focus">Where to foucus on</param>
        /// <param name="zoom"></param>
        /// <returns></returns>
        public Vector2 FocusCameraToCenterCords(Vector2 focus, float zoom)
        {
            Vector2 center = new Vector2((Parrent.WindowSize.X / zoom) / 2, (Parrent.WindowSize.Y / zoom) / 2);
            float transformX = (MaxDimentions.X / 2) - center.X;
            float transformY = (MaxDimentions.Y / 2) - center.Y;

            return new Vector2(transformX + focus.X, transformY + focus.Y);
        }
        /// <summary>
        /// Transform center anchored cordinates to top left anchored cordinates
        /// </summary>
        /// <param name="pos">Center cordiantes</param>
        /// <returns>Zero, zero cordiantes</returns>
        public Vector2 CenterToZero(Vector2 pos)
        {
            return new Vector2(pos.X + (MaxDimentions.X / 2), pos.Y + (MaxDimentions.Y / 2));
        }
        /// <summary>
        /// Transform top left anchored cordinates to center anchored cordinates
        /// </summary>
        /// <param name="pos">Zero, zero cordinates</param>
        /// <returns>Centerr cordiantes</returns>
        public Vector2 ZeroToCenter(Vector2 pos)
        {
            return new Vector2(pos.X - (MaxDimentions.X / 2), pos.Y - (MaxDimentions.Y / 2));
        }
        #endregion
    }
}
