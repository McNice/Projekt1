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
        protected string texName;
        public Vector2 pos;
        public Rectangle tileBox;
        public Tile(Vector2 pos,string texName)
        {
            this.pos = pos;
            this.texName = texName;
            LoadContent();
        }

        public void LoadContent()
        {
            tex = Game1.mediaManager.Texture(texName);
        }
        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, pos, null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None,1);
            //sb.Draw(tex, Bounds(),null, Color.White);
        }

        public virtual Rectangle Bounds()
        {
            return new Rectangle((int)pos.X, (int)pos.Y, 50, 50);
        }
    }
}
