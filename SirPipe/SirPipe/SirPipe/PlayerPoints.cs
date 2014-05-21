using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using MAHArcadeSystem;

namespace SirPipe
{
    public class PlayerPoints
    {
        public Vector2 left1, left2, right1, right2, top, bottom, groundCheck;

        public PlayerPoints(Vector2 left1, Vector2 left2, Vector2 right1, Vector2 right2, Vector2 top, Vector2 bottom)
        {
            this.left1 = left1;
            this.left2 = left2;
            this.right1 = right1;
            this.right2 = right2;
            this.top = top;
            this.bottom = bottom;
            groundCheck = bottom;
            groundCheck.Y += 1;
        }      
    }
}
