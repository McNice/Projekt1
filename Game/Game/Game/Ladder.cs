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
        Texture2D tex;
        public Ladder(Vector2 pos, string texName)
            : base(pos, texName)
        {
            tex = Game1.textureManager.Texture(texName);
        }
    }
}
