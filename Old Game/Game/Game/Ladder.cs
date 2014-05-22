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
        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, pos, null, Color.White, 0, Vector2.Zero, 0.48f, SpriteEffects.None, 0.4f);
        }
        public override Rectangle Bounds()
        {
            return new Rectangle((int)pos.X + 22, (int)pos.Y, 4, Game1.TILESIZE);
        }
    }
}
