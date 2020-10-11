using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Island_Junkies.io
{
    class ScreenToWorld
    {
        public static Vector2 CameraFocusToWorld(Vector2 camSize, Vector2 worldSize, Vector2 focus, float zoom)
        {
            Vector2 center = new Vector2((camSize.X / zoom) / 2, (camSize.Y / zoom) / 2);
            int transformX = (int)((worldSize.X / 2) - center.X);
            int transformY = (int)((worldSize.Y / 2) - center.Y);

            return new Vector2(transformX + focus.X, transformY + focus.Y);
        }
    }
}
