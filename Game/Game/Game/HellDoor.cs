using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class HellDoor : Animated
    {
        public HellDoor(Vector2 pos, string texName, float animationSpeed, int channel)
            : base(pos, texName, animationSpeed, channel)
        {   }

        public override Rectangle Rec()
        {
            return new Rectangle(recX, 0, 100, 200);
        }
    }
}
