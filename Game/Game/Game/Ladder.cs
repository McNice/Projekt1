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
            return new Rectangle((int)pos.X, (int)pos.Y, Game1.TILESIZE, Game1.TILESIZE);
        }
    }
}
