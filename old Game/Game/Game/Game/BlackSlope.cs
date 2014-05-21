using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class BlackSlope : Slope
    {
        public BlackSlope(Vector2 pos, string texName, int SlopeType)
            : base(pos, texName, SlopeType)
        {   }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, pos, null, Color.Black, 0, Vector2.Zero, 0.48f, SpriteEffects.None, 1);
        }
    }
}
