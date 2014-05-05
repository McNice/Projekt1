using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class Ladder : Tile
    {
        public Ladder(Vector2 pos, string texName)
            : base(pos, texName)
        {
            tex = Game1.mediaManager.Texture(texName);
        }

        public override Rectangle Bounds()
        {
            return new Rectangle((int)pos.X + 24, (int)pos.Y, 2, Game1.TILESIZE);
        }
    }
}
