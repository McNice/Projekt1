using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game
{
    public class Tile
    {
        Texture2D tex;
        string texName = "astroid";
        public Vector2 pos;
        public int type;
        public Tile(string Texture)
        {
            texName = Texture;
            LoadContent();
        }
        public Tile() { LoadContent(); }
        public void LoadContent()
        {
            tex = Game1.textureManager.Texture(texName);
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, pos, Color.White);
        }
    }
}
