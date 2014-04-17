using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class Block : Tile
    {
        public Rectangle boundingBox;
        protected Texture2D tex;
        public Block(Vector2 pos, string Texture) :base(pos, Texture)
        {
            tex = Game1.textureManager.Texture(Texture);
            boundingBox = new Rectangle(0, 0, tex.Width, tex.Height);
        }
    }
}
